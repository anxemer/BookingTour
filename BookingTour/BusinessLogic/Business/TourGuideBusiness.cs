using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using BusinessLogic.Utiliti;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class TourGuideBusiness
    {
        private readonly IRepository<TourGuide, int> _repository;
        private readonly IRepository<Ticket, int> _ticketRepository;
        private readonly IMapper _mapper;

        public TourGuideBusiness(IRepository<TourGuide, int> repository, IRepository<Ticket, int> ticketRepository, IMapper mapper)
        {
            _repository = repository;
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<List<TourGuideModel>> GetAllTourGuide()
        {
            var touiG = _repository.GetAll();
            var tourGList = _mapper.Map<List<TourGuideModel>>(touiG);
            return tourGList;
        }
        public async Task<TourGuideModel> GetTourGuideById(int id)
        {
            var tourGuide = await _repository.GetByIdAsync(id);
            if (tourGuide == null)
            {
                throw new NotFoundException("Tour Guide Not Found");
            }
            var rs = _mapper.Map<TourGuideModel>(tourGuide);
            return rs;
        }
        public async Task<TourGuideModel> GetTourGuideByName(string name)
        {
            var tourGuide = await _repository.FindByCondition(tg => tg.Fullname == name.Trim()).FirstOrDefaultAsync();
            if (tourGuide == null)
            {
                throw new NotFoundException("Tour Guide Not Found");
            }
            var rs = _mapper.Map<TourGuideModel>(tourGuide);
            return rs;
        }
        public async Task<bool> CreateTourGuide(int adminId, CreateTourGuideModel createTourGuide)
        {
            var tgExist = await _repository.FindByCondition(tg => tg.Fullname == createTourGuide.Fullname).FirstOrDefaultAsync();
            if (tgExist != null)
            {
                throw new BadRequestException("Tour Guide has exist");
            }
            var newTourGuide = new TourGuide
            {
                Email = createTourGuide.Email,
                Fullname = createTourGuide.Fullname,
                Phone = createTourGuide.Phone,
                Status = SD.ACTIVE,
                CreateBy = adminId,
                ModifyBy = adminId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            _repository.AddAsync(newTourGuide);
            var rs = await _repository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateTourGuide(int id, UpdateTourGuideModel updateTourGuide, int adminId)
        {
            var tgExist = await _repository.GetByIdAsync(id);
            if (tgExist == null)
            {
                throw new NotFoundException("Tour Guide Not Found");
            }
            tgExist.UpdatedAt = DateTime.UtcNow;
            tgExist.Status = updateTourGuide.Status;
            tgExist.Email = updateTourGuide.Email;
            tgExist.Fullname = updateTourGuide.Fullname;
            tgExist.Phone = updateTourGuide.Phone;
            _repository.Update(tgExist);
            var rs = await _repository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateTicketForTourGuide(int id, int ticketId, int adminId)
        {
            var tgExist = await _repository.GetByIdAsync(id);
            if (tgExist == null)
            {
                throw new NotFoundException("Tour Guide not found");
            }
            var ticketExist = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticketExist == null)
            {
                throw new NotFoundException($"Ticket not found");
            }
            tgExist.ModifyBy = adminId;
            tgExist.UpdatedAt = DateTime.UtcNow;
            tgExist.TicketId = ticketId;
            _repository.Update(tgExist);
            var rs = await _repository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> ChangeStatusTourGuide(int id, string status, int adminId)
        {
            var tgExist = await _repository.GetByIdAsync(id);
            if (tgExist == null)
            {
                throw new NotFoundException("Tour Guide not found");
            }
            tgExist.UpdatedAt = DateTime.UtcNow;
            tgExist.ModifyBy = adminId;
            tgExist.Status = status;
            _repository.Update(tgExist);
            var rs = await _repository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
    }
}
