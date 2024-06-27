using AutoMapper;
using BookingDentist.API.AutoMapper;
using BusinessLogic.Business;
using BusinessLogic.Business.FirebaseBusiness;
using BusinessLogic.Repostitory;
using DataAccess;
using DataAccess.Entites;
using FSAM.BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;

namespace BookingTourAPI.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void InitializerDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddDbContext<TourBookingContext>(options =>
       options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //Add Mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationMapper());
            });
            
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddScoped<FirebaseService>();
            services.AddSingleton(mapper);
            services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<GenericBackendService>();
            services.AddScoped<UserBusiness>();
            services.AddScoped<CategoryBusiness>();
            services.AddScoped<AuthBusiness>();
            services.AddScoped<HotelBusiness>();
            services.AddScoped<HotelImageBusiness>();
            services.AddScoped<TourBusiness>();
            services.AddScoped<BookingBusiness>();
            services.AddScoped<TicketBusiness>();
            services.AddScoped<TourDetailBusiness>();
            services.AddScoped<TourGuideBusiness>();
            services.AddScoped<LocationBusiness>();
            services.AddScoped<TourLocationBusiness>();

        }
    }
}
