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
    public class HotelImageBusiness
    {
        private readonly IRepository<HotelImage, int> _repository;
        private readonly IMapper _mapper;

        public HotelImageBusiness(IRepository<HotelImage,int> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<HotelImageModel>> GetAllHotelImage()
        {
            var hotelI = _repository.GetAll();
            var hotelIList = _mapper.Map<List<HotelImageModel>>(hotelI);
            return hotelIList;
        }
        public async Task<HotelImageModel> GetHotelImageById(int id)
        {
            var hotelI = await _repository.GetByIdAsync(id);
            if(hotelI == null)
            {
                throw new NotFoundException("Hotel Image not found");
            }
            var him = _mapper.Map<HotelImageModel>(hotelI);
            return him;
        }
        public async Task<bool> CreateHotelImage(int  Hotelid,CreateHotelImageModel createHotelImage)
        {
            var hotelExist = await _repository.GetByIdAsync(Hotelid);
            if (hotelExist == null)
            {
                throw new NotFoundException("Hotel not found");
            }
            var newHtI = new HotelImage
            {
                HotelId = Hotelid,
               
                Url = createHotelImage.Url,
            };
            await _repository.AddAsync(newHtI);
            var rs = await _repository.Commit();
            return rs > 0;
        }
        public async Task<bool> DeleteHotelImage(int id)
        {
            var hmtExist = await _repository.GetByIdAsync(id);
            if(hmtExist == null)
            {
                throw new NotFoundException("Hotel image not found");
            }
            _repository.Remove(id);
            var rs = await _repository.Commit();
            return rs > 0;
        }
    }
}
