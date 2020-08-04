
using BusinessRespository.IRepositories;
using System;


namespace BusinessRespository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
       ILoginRepository LoginRepository { get; }

       IAboutUsRepository AboutUsRepository { get; }
       IDestinationRepository DestinationRepository { get; }
       ITourThemeRepository TourThemeRepository { get; }
       IBlogRepository BlogRepository { get; }
       IBannerRepository BannerRepository { get; }

       ICurrentNewsRepository CurrentNewsRepository { get; }
       IUpcommingNewsRepository UpcommingNewsRepository { get; }

       INewsRepository NewsRepository { get; }
       IEventRepository EventRepository { get; }
       IOfferAdsRepository OfferAdsRepository { get; }
       IProfileCategoryRepository ProfileCategoryRepository { get; }
       ILocationRepository LocationRepository { get; }
        IUtilityRepository UtilityRepository { get; }

        IDestinationVideosRepository DestinationVideosRepository { get; }
        IInterviewRepository InterviewRepository { get; }
        ITrendingNewsRepository TrendingNewsRepository { get; }
        IFAQRepository FAQRepository { get; }
        ITopDestinationRepository TopDestinationRepository { get; }

        void Commit();
        void Rollback();
    }
}
