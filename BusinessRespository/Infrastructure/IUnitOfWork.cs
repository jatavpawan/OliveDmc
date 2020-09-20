
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
        ILatestEventRepository LatestEventRepository { get; }
        IInterviewsInWhatsNewRepository InterviewsInWhatsNewRepository { get; }
        INewDestinationsInWhatsNewRepository NewDestinationsInWhatsNewRepository { get; }
        IPrivacyPolicyRepository PrivacyPolicyRepository { get; }
        ITeamMemberInAboutUsRepository TeamMemberInAboutUsRepository { get; }
        IFestivalRepository FestivalRepository { get; }
        IAboutUsIntroductionRepository AboutUsIntroductionRepository { get; }
        IAboutUsStatementRepository AboutUsStatementRepository { get; }
        ITravelUtilityQueryRepository TravelUtilityQueryRepository { get; }
        IContactUsRepository ContactUsRepository { get; }
        IUserCoverImageRepository UserCoverImageRepository { get; }
        IUserPersonalInfoRepository UserPersonalInfoRepository { get; }
        IUserGalleryRepository UserGalleryRepository { get; }
        IUserPostRepository UserPostRepository { get; }
        IBlogCategoryRepository BlogCategoryRepository { get; }
        IUserNetworkRepository UserNetworkRepository { get; }

        void Commit();
        void Rollback();
    }
}
