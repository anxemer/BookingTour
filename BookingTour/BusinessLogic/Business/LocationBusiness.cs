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
    public class LocationBusiness
    {
        private readonly IRepository<Location, int> _repository;
        private readonly IMapper _mapper;

        public LocationBusiness(IRepository<Location, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<LocationModel>> GetAllLocation()
        {
            var location = _repository.GetAll();
            var locationList = _mapper.Map<List<LocationModel>>(location);
            return locationList;
        }
        public async Task<LocationModel> GetLocationById(int id)
        {
            var location = await _repository.GetByIdAsync(id);
            if(location == null)
            {
                throw new NotFoundException("Location not found");
            }
            var locationM = _mapper.Map<LocationModel>(location);
            return locationM;
        }
        public async Task<LocationModel> GetLocationByName(string name)
        {
            var location = await _repository.FindByCondition(l => l.Name == name.Trim()).FirstOrDefaultAsync();
            if(location == null)
            {
                throw new NotFoundException("Location not found");
            }
            var locationM = _mapper.Map<LocationModel>(location);
            return locationM;
        }
        public async Task<bool> CreateLocaiton(CreateLocationModel createLocation,int adminId)
        {
            var locationExít = await _repository.FindByCondition(l => l.Name == createLocation.Name.Trim()).FirstOrDefaultAsync();
            if(locationExít != null)
            {
                throw new BadRequestException("Locatin has exist");
            }
            var newLocaiton = new Location
            {
                CreateBy = adminId,
                Address = createLocation.Address,
                Description = createLocation.Description,
                Name = createLocation.Name,
                CreatedAt = DateTime.UtcNow,
                ModifyBy = adminId,
                UpdatedAt = DateTime.UtcNow,
                Status = SD.ACTIVE
            };
            await _repository.AddAsync(newLocaiton);
            var rs = await _repository.Commit(); 
            if(rs > 0)
            {
                return true;
            }
            return false;

        }
        public async Task<bool> UpdateLocation(int loId,UpdateLocationModel updateLocation,int adminId)
        {
            var locaExist = await _repository.GetByIdAsync(loId);
            if(locaExist == null) {
                throw new NotFoundException("Location not found");
            }
            locaExist.Name = updateLocation.Name;
            locaExist.UpdatedAt = DateTime.UtcNow;
            locaExist.ModifyBy = adminId;
            locaExist.Address = updateLocation.Address;
            locaExist.Description = updateLocation.Description;
            _repository.Update(locaExist);
            var rs = await _repository.Commit();
            if(rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> ChangeStatusLocation(int locaId,string status,int adminId)
        {
            var locaExist = await _repository.GetByIdAsync(locaId);
            if(locaExist == null)
            {
                throw new NotFoundException("Location not found");
            }

            locaExist.ModifyBy = adminId;
            locaExist.Name = status;
            locaExist.UpdatedAt = DateTime.UtcNow;
            _repository.Update(locaExist);
            var rs = await _repository.Commit();
            if(rs > 0)
            {
                return true;
            }
            return false;
        }
    }
}
