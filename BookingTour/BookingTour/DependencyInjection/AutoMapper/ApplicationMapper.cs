using AutoMapper;
using BookingTourAPI.Common.AuthViewModel;
using BookingTourAPI.Common.RequestModel;
using BookingTourAPI.Common.ResponseModel;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.AuthDtos;
using BusinessLogic.Dtos.RequestDtos;
using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.API.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //Entiti => Model
            CreateMap<Booking, BookingModel>().ReverseMap();
            CreateMap<CategoryModel, CategoryTour>().ReverseMap();
            CreateMap<HotelImage, HotelImageModel>().ReverseMap();
            CreateMap<Hotel, HotelModel>().ReverseMap();
            CreateMap<Location, LocationModel>().ReverseMap();
            CreateMap<Ticket, TicketModel>().ReverseMap();
            CreateMap<TourDetail, TourDetailModel>().ReverseMap();
            CreateMap<TourGuide, TourGuideModel>().ReverseMap();
            CreateMap<TourImage, TourImageModel>().ReverseMap();
            CreateMap<TourLocation, TourLocationModel>().ReverseMap();
            CreateMap<Tour, TourModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            //Model => Requset
            CreateMap<CreateBookingModel, CreateBookingRequest>().ReverseMap();
            CreateMap<CreateCategoryModel, CreateCategoryRequest>().ReverseMap();
            CreateMap<CreateHotelImageModel, CreateHotelImageRquest>().ReverseMap();
            CreateMap<CreateHotelModel, CreateHotelRequest>().ReverseMap();
            CreateMap<CreateLocationModel, CreatelocationRequest>().ReverseMap();
            CreateMap<CreateTicketModel, CreateTicketRequest>().ReverseMap();
            CreateMap<CreateTourDetailModel, CreateTourDetailRequset>().ReverseMap();
            CreateMap<CreateTourGuideModel, CreateTourGuideRequest>().ReverseMap();
            CreateMap<CreateTourImageModel, CreateTourImageRequest>().ReverseMap();
            CreateMap<CreateTourLocationModel, CreateTourLocationRequest>().ReverseMap();
            CreateMap<CreateTourLocationRequest, CreateTourModel>().ReverseMap();
            CreateMap<CreateTourRequest, CreateTourModel>().ReverseMap();
            CreateMap<CreateUserReques, CreateUserModel>().ReverseMap();
            CreateMap<UpdateHotelImageModel, UpdateHotelImageRequest>().ReverseMap();
            CreateMap<UpdateHotelModel, UpdateHotelRequest>().ReverseMap();
            CreateMap<UpdateSlotTourModel, UpdateSlotTourRequset>().ReverseMap();
            CreateMap<UpdateStatusBookingModel, UpdateStatusBookingRequest>().ReverseMap();
            CreateMap<UpdateStatusTicketModel, UpdateStatusTicketModel>().ReverseMap();
            CreateMap<UpdateTicketModel, UpdateStatusTicketRequset>().ReverseMap();
            CreateMap<UpdateTourDetailModel, UpdateTourDetailRequset>().ReverseMap();
            CreateMap<UpdateTourImageModel, UpdateTourImageRequest>().ReverseMap();
            CreateMap<UpdateTourModel, UpdateTourRequest>().ReverseMap();
            CreateMap<UpdateTourLocationModel, UpdateTourLocationRequest>().ReverseMap();
            CreateMap<UpdateUserModel, UpdateUserRequest>().ReverseMap();
            CreateMap<UpdateCategoryModel, UpdateCategoryRequset>().ReverseMap();
            CreateMap<UpdateTourGuideModel, UpdateTourGuideRequest>().ReverseMap();
            //Model => Response
            CreateMap<GetBookingResponse, BookingModel>().ReverseMap();
            CreateMap<GetCategoryResponse, CategoryModel>().ReverseMap();
            CreateMap<GetHotelImageResponse, HotelImageModel>().ReverseMap();
            CreateMap<GetHotelResponse, HotelModel>().ReverseMap();
            CreateMap<GetLocationResponse, LocationModel>().ReverseMap();
            CreateMap<GetTicketResponse, TicketModel>().ReverseMap();
            CreateMap<GetTourDetailResponse, TourDetailModel>().ReverseMap();
            CreateMap<GetTourResponse, TourGuideModel>().ReverseMap();
            CreateMap<GetTourImageRepsonse, TourImageModel>().ReverseMap();
            CreateMap<GetTourResponse, TourModel>().ReverseMap();
            CreateMap<GetUserRepsonse, UserModel>().ReverseMap();
            //Token
            CreateMap<TokenRequest, TokenModel>().ReverseMap();
            CreateMap<LoginModel, LoginRequest>().ReverseMap();
            CreateMap<LoginResponse, LoginResponseModel>().ReverseMap();
        }
    }
}
