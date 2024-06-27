using AutoMapper;
using BusinessLogic.Business.FirebaseBusiness;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using BusinessLogic.Utiliti;
using DataAccess.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class TourBusiness
    {
        private readonly IRepository<Tour, int> _repository;
        private readonly IRepository<TourImage, int> _imageRepository;
        private readonly IMapper _mapper;
        private readonly FirebaseService _firebaseService;

        public TourBusiness(IRepository<Tour, int> repository, IRepository<TourImage, int> imageRepository, IMapper mapper, FirebaseService firebaseService)
        {
            _repository = repository;
            _imageRepository = imageRepository;
            _mapper = mapper;
            _firebaseService = firebaseService;
        }
        public async Task<List<TourModel>> GetAllTour()
        {
            var tour = _repository.GetAll();
            var tourList = _mapper.Map<List<TourModel>>(tour);
            return tourList;
        }
        public async Task<TourModel> GetTourById(int id)
        {
            var tour = await _repository.GetByIdAsync(id);
            if (tour == null)
            {
                throw new NotFoundException("Tour not found");
            }
            var tourM = _mapper.Map<TourModel>(tour);
            return tourM;
        }
        public async Task<TourModel> GetTourByName(string name)
        {
            var tour = await _repository.FindByCondition(t => t.Name == name.Trim()).FirstOrDefaultAsync();
            if (tour == null)
            {
                throw new NotFoundException("tour not found");
            }
            var tourM = _mapper.Map<TourModel>(tour);
            return tourM;
        }
        public async Task<bool> CreateTour(CreateTourModel createTour, int adminId)
        {
            var tourExist = await _repository.FindByCondition(t => t.Name == createTour.Name).FirstOrDefaultAsync();
            if (tourExist != null)
            {
                throw new BadRequestException("Tour has exist");
            }
            var newTour = new Tour
            {
                Name = createTour.Name,
                CategoryTourId = createTour.CategoryTourId,
                Description = createTour.Description,
                CreateBy = adminId,
                HotelId = createTour.HotelId,
                ModifyBy = adminId,
                Price = createTour.Price,
                Status = SD.ACTIVE,
                StartDay = createTour.StartDay,
                TotalDay = createTour.TotalDay,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            await _repository.AddAsync(newTour);
            await _repository.Commit();
            var imageUrl = createTour.Files;
            foreach (var url in imageUrl)
            {
                var imageTour = new TourImage
                {
                    TourId = newTour.Id,
                };
                await _imageRepository.AddAsync(imageTour);
                await _imageRepository.Commit();
                var imagePath = FirebasePathName.TOURIMAGE + $"{imageTour.Id}";
                var imageLoadResult = await _firebaseService.UploadFileToFirebase(url, imagePath);
                if (!imageLoadResult.IsSuccess)
                {
                    throw new InternalServerErrorException("Error uploading files to Firebase.");
                }
                imageTour.Url = (string)imageLoadResult.Result;
                _imageRepository.Update(imageTour);
            }
            var rs = await _imageRepository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateTour(int tourId, UpdateTourModel updateTour,int adminId)
        {
            var TourExist = await _repository.GetByIdAsync(tourId);
            if (TourExist == null)
            {
                throw new NotFoundException("Tour not found");
            }
            TourExist.Name = updateTour.Name;
            TourExist.StartDay = updateTour.StartDay;
            TourExist.ModifyBy = adminId;
            TourExist.Price = updateTour.Price;
            TourExist.UpdatedAt = DateTime.UtcNow;
            TourExist.Description = updateTour.Description;
            TourExist.CategoryTourId = updateTour.CategoryTourId;
            TourExist.HotelId = updateTour.HotelId;
            _repository.Update(TourExist);
            var imageUrl = updateTour.Files;
            foreach (var url in imageUrl)
            {
                var newImage = new TourImage
                {
                    TourId = tourId
                };
                await _imageRepository.AddAsync(newImage);
                await _imageRepository.Commit();

                var imagePath = FirebasePathName.TOURIMAGE + $"{newImage.Id}";
                var imageLoadResult = await _firebaseService.UploadFilesToFirebase(imageUrl, imagePath);
                if (!imageLoadResult.IsSuccess)
                {
                    throw new InternalServerErrorException("Error uploading files to Firebase.");
                }
                newImage.Url = (string)imageLoadResult.Result;
                _imageRepository.Update(newImage);
            }
            var rs = await _imageRepository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateStatusTour(int tourId,string status,int adminId)
        {
            var tourExist = await _repository.FindByCondition(t => t.Id == tourId).FirstOrDefaultAsync();
           if(tourExist == null)
            {
                throw new NotFoundException("Tour not found");
            }
           tourExist.Status = status;
            tourExist.ModifyBy = adminId;
            _repository.Update(tourExist);
            var rs = await _repository.Commit();
            if(rs > 0) { return true; }
            return false;
        }
        public async Task<bool> DeleteImageTour(int tourId, UpdateTourImageModel updateTourImage)
        {
            var tourExist = await _repository.GetByIdAsync(tourId);
            if (tourExist == null)
            {
                throw new NotFoundException("Tour not found");
            }
            var imageTour = await _imageRepository.GetByIdAsync(updateTourImage.ImageId);
            if (imageTour == null)
            {
                throw new NotFoundException("Image not found");
            }
            if (updateTourImage.Url != null && updateTourImage.Url.Length>0) { 
                if(!string.IsNullOrEmpty(imageTour.Url)) {
                    string urlImage = $"{FirebasePathName.TOURIMAGE}{tourExist.Id}";
                    var deleteResultt = await _firebaseService.DeleteFileFromFirebase(urlImage);
                    if (!deleteResultt.IsSuccess)
                    {
                        throw new InternalServerErrorException($"Failed to delete old image");
                    }
                    var imagePath = $"{FirebasePathName.TOURIMAGE}{tourExist.Id}";
                    var imageUploadResutl = await _firebaseService.UploadFileToFirebase(updateTourImage.Url, imagePath);
                    if (imageUploadResutl.IsSuccess)
                    {
                        imageTour.Url = (string)imageUploadResutl.Result;
                    }
                    else
                    {
                        throw new InternalServerErrorException($"Failed to upload new image:");
                    }
                    _imageRepository.Update(imageTour);
                }
            }
            var rs = await _imageRepository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        //public async Task<List<TourImageModel>> GetAllTourImage(int TourId)
        //{

        //}
    }
}
