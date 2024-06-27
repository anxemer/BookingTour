using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class TourDetailBusiness
    {
        private readonly IRepository<TourDetail, int> _repository;
        private readonly IMapper _mapper;

        public TourDetailBusiness(IRepository<TourDetail,int> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TourDetailModel> GetTourDetailByTourId(int TourId)
        {
            var tourd = _repository.FindByCondition(t => t.TourId == TourId).FirstOrDefault();
            if(tourd == null)
            {
                throw new NotFoundException("Tour Detail Not found");
            }
            var tourDM = _mapper.Map<TourDetailModel>(tourd);
            return tourDM;
        }
        public async Task<TourDetailModel> GetTourDetailById(int id)
        {
            var tourdetail = await _repository.GetByIdAsync(id);
            if(tourdetail == null)
            {
                throw new NotFoundException("Tour Detail Not Found");
            }
            var tourDM = _mapper.Map<TourDetailModel>(tourdetail);
            return tourDM;
        }
        public async Task<bool> CreateTourDetail(CreateTourDetailModel model)
        {
            var newTourDetail = new TourDetail
            {
                AvailableSlot = model.AvailableSlot,
                DepartureLocation = model.DepartureLocation,
                Description = model.Description,
                DestinationLocation = model.DestinationLocation,
                PricePerPerson = model.PricePerPerson,
                TotalPrice = model.TotalPrice,
                TotalSlot = model.TotalSlot,
                TourId = model.TourId,
                Transportation = model.Transportation,
            };
            await _repository.AddAsync(newTourDetail);
            var rs = await _repository.Commit();
            return rs > 0;
        }
        public async Task<bool> UpdateTourDetail(int id,UpdateTourDetailModel model)
        {
            var tourDExist= await _repository.GetByIdAsync(id);
            if(tourDExist == null)
            {
                throw new NotFoundException("Not found");
            }
            tourDExist.AvailableSlot = model.AvailableSlot;
            tourDExist.TotalSlot = model.TotalSlot;
            tourDExist.TotalPrice = model.TotalPrice;
            tourDExist.PricePerPerson = model.PricePerPerson;
            tourDExist.Transportation = model.Transportation;
            tourDExist.DepartureLocation = model.DepartureLocation;
            tourDExist.DestinationLocation = model.DestinationLocation;
            tourDExist.Description = model.Description;
            _repository.Update(tourDExist);
            var rs = await _repository.Commit();
            return rs > 0;
        }
        public async Task<bool> ChangeAvailebleSlot(int id,int slot)
        {
            var tourExist =  await _repository.GetByIdAsync(id);
            if(tourExist == null)
            {
                throw new NotFoundException("not found");
            }
            tourExist.AvailableSlot = slot;
            _repository.Update(tourExist);
            var rs = await _repository.Commit();
            return rs > 0;
        }
       
    }
}
