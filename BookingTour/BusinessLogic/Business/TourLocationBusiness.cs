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
    public class TourLocationBusiness
    {
        private readonly IRepository<TourLocation, int> _repository;
        private readonly IRepository<Tour, int> _tourRepository;
        private readonly IRepository<Location, int> _locationRepository;
        private readonly IMapper _mapper;

        public TourLocationBusiness(IRepository<TourLocation,int> repository, IRepository<Tour, int> tourRepository, IRepository<Location, int> LocationRepository, IMapper mapper)
        {
            _repository = repository;
            _tourRepository = tourRepository;
            _locationRepository = LocationRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateTourLocation(CreateTourLocationModel createTourLocation)
        {
            var tourExist = await _tourRepository.GetByIdAsync(createTourLocation.TourId);
            if (tourExist == null)
            {
                throw new NotFoundException("Tour not found");
            }
            var locationExist = await _locationRepository.GetByIdAsync(createTourLocation.LocationId);
            if (locationExist == null)
            {
                throw new NotFoundException("Location not found");
            }
            var newTourLocation = new TourLocation
            {
                LocationId = createTourLocation.LocationId,
                TourId = createTourLocation.TourId,
            };
            await _repository.AddAsync(newTourLocation);
            var rs = await _repository.Commit();
            if (rs >0) { return true; }
            return false;
        } 
    }
}
