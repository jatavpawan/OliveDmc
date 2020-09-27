using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using BusinessServices.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace OLiveDMC
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //public string MyAllowSpecificOrigins { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => builder.AllowAnyOrigin().WithOrigins("http://localhost", "http://rsmartservices.com", "http://localhost:51306", "http://localhost:4200", "http://administrator.gmservices.in")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
          //  services.AddSingleton<IFileProvider>(
          //new PhysicalFileProvider(
          //    Path.Combine(Directory.GetCurrentDirectory(), "Uploads")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IAboutUsService, AboutUsService>();
            services.AddTransient<IDestinationService, DestinationService>();
            services.AddTransient<ITourThemeService, TourThemeService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IBannerService, BannerService>();

            services.AddTransient<IUpcommingNewsService, UpcommingNewsService>();
            services.AddTransient<ICurrentNewsService, CurrentNewsService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IOfferAdsService, OfferAdsService>();
            services.AddTransient<IProfileCategoryService, ProfileCategoryService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IUtilityService, UtilityService>();
            services.AddTransient<IDestinationVideosService, DestinationVideosService>();
            services.AddTransient<IInterviewService, InterviewService>();
            services.AddTransient<ITrendingNewsService, TrendingNewsService>();
            services.AddTransient<IFAQService, FAQService>();
            services.AddTransient<ITopDestinationService, TopDestinationService>();
            services.AddTransient<ILatestEventService, LatestEventService>();
            services.AddTransient<IInterviewsInWhatsNewService, InterviewsInWhatsNewService>();
            services.AddTransient<INewDestinationsInWhatsNewService, NewDestinationsInWhatsNewService>();
            services.AddTransient<IPrivacyPolicyService, PrivacyPolicyService>();
            services.AddTransient<ITeamMemberInAboutUsService, TeamMemberInAboutUsService>();
            services.AddTransient<IFestivalService, FestivalService>();
            services.AddTransient<IAboutUsIntroductionService, AboutUsIntroductionService>();
            services.AddTransient<IAboutUsStatementService, AboutUsStatementService>();
            services.AddTransient<ITravelUtilityQueryService, TravelUtilityQueryService>();
            services.AddTransient<IContactUsService, ContactUsService>();
            services.AddTransient<IUserCoverImageService, UserCoverImageService>();
            services.AddTransient<IUserPersonalInfoService, UserPersonalInfoService>();
            services.AddTransient<IUserGalleryService, UserGalleryService>();
            services.AddTransient<IUserPostService, UserPostService>();
            services.AddTransient<IBlogCategoryService, BlogCategoryService>();
            services.AddTransient<IUserNetworkService, UserNetworkService>();
            services.AddTransient<ISkillsService, SkillsService>();
            services.AddTransient<IAreaOfExpertiseService, AreaOfExpertiseService>();
            services.AddTransient<IStudentCareerService, StudentCareerService>();
            services.AddTransient<IProfessionalCareerService, ProfessionalCareerService>();
            services.AddTransient<IFresherCareerService, FresherCareerService>();
            services.AddTransient<IBookingService, BookingService>();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            //app.UseIdentity();
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
                RequestPath = new PathString("/Uploads")
            });


            //app.UseStaticFiles();

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content")),
            //    RequestPath = new PathString("/Uploads")
            //});

            app.UseSpaStaticFiles();

            //app.UseSession();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    spa.Options.StartupTimeout = System.TimeSpan.FromSeconds(200);
                }
            });

          

        }
    }
}
