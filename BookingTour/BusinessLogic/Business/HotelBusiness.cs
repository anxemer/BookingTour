using AutoMapper;
using BusinessLogic.Business.FirebaseBusiness;
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
    public class HotelBusiness
    {
        private readonly IRepository<Hotel, int> _repository;
        private readonly IRepository<HotelImage, int> _imageRepository;


        private readonly IMapper _mapper;
        private readonly FirebaseService _firebaseService;

        public HotelBusiness(IRepository<Hotel, int> repository, IRepository<HotelImage, int> imageRepository, IMapper mapper, FirebaseService firebaseService)
        {
            _imageRepository = imageRepository;
            _repository = repository;
            _mapper = mapper;
            _firebaseService = firebaseService;
        }
        public async Task<List<HotelModel>> GetAllHotel()
        {
            var hotel = _repository.GetAll();
            var hotelList = _mapper.Map<List<HotelModel>>(hotel);
            return hotelList;
        }
        public async Task<HotelModel> GetHotelById(int id)
        {
            var hotel = await _repository.GetByIdAsync(id);
            if (hotel == null)
            {
                throw new NotFoundException("Hotel not found");
            }
            var hotelM = _mapper.Map<HotelModel>(hotel);
            return hotelM;
        }
        public async Task<HotelModel> GetHotelByName(string name)
        {
            var hotel = await _repository.FindByCondition(h => h.Name == name.Trim()).FirstOrDefaultAsync();
            if (hotel == null)
            {
                throw new NotFoundException("Hotel not found");
            }
            var hotelM = _mapper.Map<HotelModel>(hotel);
            return hotelM;
        }
        public async Task<bool> CreateHotel(CreateHotelModel createHotel, int adminId)
        {
            var hotelExist = await _repository.FindByCondition(h => h.Name == createHotel.Name.Trim()).FirstOrDefaultAsync();
            if (hotelExist != null)
            {
                throw new BadRequestException("Hotel has exist");
            }
            var newHotel = new Hotel
            {
                ModifyBy = adminId,

                Address = createHotel.Address,
                Name = createHotel.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Description = createHotel.Description,
                Status = SD.ACTIVE,
                TotalRoom = createHotel.TotalRoom,
                CreateBy = adminId,

            };
            if (newHotel == null)
            {
                throw new InternalServerErrorException("Cannot create hotel");
            }
            await _repository.AddAsync(newHotel);
            await _repository.Commit();
            var imageUrl = createHotel.Files;
            foreach (var url in imageUrl)
            {
                var newUrl = new HotelImage
                {
                    HotelId = newHotel.Id,
                };
                await _imageRepository.AddAsync(newUrl);
                await _imageRepository.Commit();
                var imagePath = FirebasePathName.HOTELIMAGE + $"{newUrl.Id}";
                var imageUploadResult = await _firebaseService.UploadFileToFirebase(url, imagePath);
                if (!imageUploadResult.IsSuccess)
                {
                    throw new InternalServerErrorException("Error uploading files to Firebase.");
                }
                newUrl.Url = (string)imageUploadResult.Result;
                _imageRepository.Update(newUrl);
            }
            var rs = await _imageRepository.Commit();
            return rs > 0;
        }
        public async Task<bool> UpdateHotel(int id, UpdateHotelModel updateHotel, int modifyBy)
        {
            var hotelExist = await _repository.GetByIdAsync(id);
            if (hotelExist != null)
            {
                throw new NotFoundException("Hotel not found");
            }
            hotelExist.ModifyBy = modifyBy;
            hotelExist.Name = updateHotel.Name;
            hotelExist.Address = updateHotel.Address;
            hotelExist.UpdatedAt = DateTime.UtcNow;
            hotelExist.Description = updateHotel.Description;
            hotelExist.TotalRoom = updateHotel.TotalRoom;
            _repository.Update(hotelExist);
           
            var rs = await _repository.Commit();
            return rs > 0;
        }
        public async Task<bool> ChangeStatusHotel(int id, string status, int modifyby)
        {
            var hotelExit = await _repository.GetByIdAsync(id);
            if (hotelExit != null)
            {
                throw new NotFoundException("Hotel not found");
            }
            hotelExit.UpdatedAt = DateTime.UtcNow;
            hotelExit.ModifyBy = modifyby;
            hotelExit.Status = status;
            _repository.Update(hotelExit);
            var rs = await _repository.Commit();
            return rs > 0;
        }
        public async Task<bool> UpdateImageHotel(int id, UpdateHotelImageModel updateHotelImage)
        {
            var hotelExist = await _repository.GetByIdAsync(id);
            if (hotelExist == null)
            {
                throw new NotFoundException("Hotel not found");
            }
            var imageUrl = updateHotelImage.Url;
            foreach (var url in imageUrl)
            {
                var newUrl = new HotelImage
                {
                    HotelId = hotelExist.Id,
                };
                await _imageRepository.AddAsync(newUrl);
                await _imageRepository.Commit();
                var imagePath = FirebasePathName.HOTELIMAGE + $"{newUrl.Id}";
                var imageUploadResult = await _firebaseService.UploadFileToFirebase(url, imagePath);
                if (!imageUploadResult.IsSuccess)
                {
                    throw new InternalServerErrorException("Error uploading files to Firebase.");
                }
                newUrl.Url = (string)imageUploadResult.Result;
                _imageRepository.Update(newUrl);
            }
            var rs = await _imageRepository.Commit();
            return rs > 0;
        }

    }
}

