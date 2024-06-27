using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using BusinessLogic.Utiliti;
using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class TicketBusiness
    {
        private readonly IRepository<Ticket, int> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<User, int> _userRepository;
        private readonly IRepository<Tour, int> _tourRepository;
        private readonly IRepository<TourDetail, int> _detailRepository;

        public TicketBusiness(IRepository<Ticket,int> repository,IMapper mapper,IRepository<User,int> userRepository,
            IRepository<Tour,int> tourRepository,IRepository<TourDetail,int> detailRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            _tourRepository = tourRepository;
            _detailRepository = detailRepository;
        }
        public async Task<List<TicketModel>> GetAllTicket()
        {
            var ticket = _repository.GetAll();
            var ticketList = _mapper.Map<List<TicketModel>>(ticket);
            return ticketList;
        }
        public async Task<TicketModel> GetTicketById(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            if(ticket == null)
            {
                throw new NotFoundException("Ticket Not Found");
            }
            var ticketM = _mapper.Map<TicketModel>(ticket);
            return ticketM;
        }
        public async Task<List<TicketModel>> GetAllTicketOfUser(int userId)
        {
            var userExist = await _userRepository.GetByIdAsync(userId);
            if(userExist == null)
            {
                throw new NotFoundException("User not found");
            }
            var ticket = _repository.GetAll().Where(t => t.UserId == userId);
            var ticketList = _mapper.Map<List<TicketModel>>(ticket);
            return ticketList;
        }
        public async Task<bool> CreateTicket(CreateTicketModel ticketModel,int userId)
        {
            var userExist = await _userRepository.GetByIdAsync(userId);
            if(userExist == null)
            {
                throw new NotFoundException("User not found");
            }
            var tourExist = await _tourRepository.GetByIdAsync(ticketModel.TourId);
            if(tourExist == null)
            {
                throw new NotFoundException("Tour Not found");
            }
            var tourDetail = _detailRepository.FindByCondition(td => td.TourId == ticketModel.TourId).FirstOrDefault();
            if(ticketModel.AmoutPeople > tourDetail.AvailableSlot)
            {
                throw new BadRequestException("Amount of people exceeds available slots.");
            }
            var newTicket = new Ticket
            {
                AmoutPeople = tourDetail.AvailableSlot,
                BookingDate = DateTime.UtcNow,
                Email = ticketModel.Email,
                FullName = ticketModel.FullName,
                PaymentMethod = ticketModel.PaymentMethod,
                PaymentStatus = SD.PM_Pending,
                PhoneNumber = ticketModel.PhoneNumber,
                TourId = ticketModel.TourId,
                UserId = userId,
                TotalBill = ticketModel.AmoutPeople * tourDetail.PricePerPerson,

            };
            await _repository.AddAsync(newTicket);
            var rs = await _repository.Commit();
            if(rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> ChangeStatusTicket(int id,string status,int adminId)
        {
            var ticketExist = await _repository.GetByIdAsync(id);
            if(ticketExist == null)
            {
                throw new NotFoundException("Ticket Not Found");
            }
            ticketExist.PaymentStatus = status;
            ticketExist.ModifyBy = adminId;
            ticketExist.UpdateAt = DateTime.UtcNow;
            _repository.Update(ticketExist);
            var rs = await _repository.Commit();
            if( rs > 0 )
            {
                return true;
            }

            return false;
        }
    }
}
