using BusinessDataModel.DB;
using BusinessRespository.IRepositories;
using BusinessRespository.Repositories;
//using BusinessDataModel.DB;
using System;

namespace BusinessRespository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {


        public TravelOliveContext db;
        public UnitOfWork() {
            this.db = new TravelOliveContext();
        }
        public UnitOfWork(string database) {
            this.db = new TravelOliveContext();

        }

        // Private Member -------------------------------------------------------------------------------
        private ILoginRepository _loginRepository;
       
        // Public Member ---------------------------------------------------------------------------------
        public ILoginRepository LoginRepository {
            get {
                return _loginRepository = _loginRepository ?? new LoginRepository(db);
            }
        }

        private IAboutUsRepository _aboutUsRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IAboutUsRepository AboutUsRepository
        {
            get
            {
                return _aboutUsRepository = _aboutUsRepository ?? new AboutUsRepository(db);
            }
        }

        private IDestinationRepository _destinationRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IDestinationRepository DestinationRepository
        {
            get
            {
                return _destinationRepository = _destinationRepository ?? new DestinationRepository(db);
            }
        }

        private ITourThemeRepository _tourThemeRepository;

        // Public Member ---------------------------------------------------------------------------------
        public ITourThemeRepository TourThemeRepository
        {
            get
            {
                return _tourThemeRepository = _tourThemeRepository ?? new TourThemeRepository(db);
            }
        }

       private IBlogRepository _blogRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IBlogRepository BlogRepository
        {
            get
            {
                return _blogRepository = _blogRepository ?? new BlogRepository(db);
            }
        }

        private IBannerRepository _bannerRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IBannerRepository BannerRepository
        {
            get
            {
                return _bannerRepository = _bannerRepository ?? new BannerRepository(db);
            }
        }


        private ICurrentNewsRepository _currentNewsRepository;

        // Public Member ---------------------------------------------------------------------------------
        public ICurrentNewsRepository CurrentNewsRepository
        {
            get
            {
                return _currentNewsRepository = _currentNewsRepository ?? new CurrentNewsRepository(db);
            }
        }


        private IUpcommingNewsRepository _upcommingNewsRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IUpcommingNewsRepository UpcommingNewsRepository
        {
            get
            {
                return _upcommingNewsRepository = _upcommingNewsRepository ?? new UpcommingNewsRepository(db);
            }
        }


        private INewsRepository _newsRepository;

        // Public Member ---------------------------------------------------------------------------------
        public INewsRepository NewsRepository
        {
            get
            {
                return _newsRepository = _newsRepository ?? new NewsRepository(db);
            }
        }

        private IEventRepository _eventRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IEventRepository EventRepository
        {
            get
            {
                return _eventRepository = _eventRepository ?? new EventRepository(db);
            }
        }


        private IOfferAdsRepository _offerAdsRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IOfferAdsRepository OfferAdsRepository
        {
            get
            {
                return _offerAdsRepository = _offerAdsRepository ?? new OfferAdsRepository(db);
            }
        }

        private IProfileCategoryRepository _profileCategoryRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IProfileCategoryRepository ProfileCategoryRepository
        {
            get
            {
                return _profileCategoryRepository = _profileCategoryRepository ?? new ProfileCategoryRepository(db);
            }
        }


        private ILocationRepository _locationRepository;

        // Public Member ---------------------------------------------------------------------------------
        public ILocationRepository LocationRepository
        {
            get
            {
                return _locationRepository = _locationRepository ?? new LocationRepository(db);
            }
        }

        private IUtilityRepository _utilityRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IUtilityRepository UtilityRepository
        {
            get
            {
                return _utilityRepository = _utilityRepository ?? new UtilityRepository(db);
            }
        }

        private IDestinationVideosRepository _destinationVideosRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IDestinationVideosRepository DestinationVideosRepository
        {
            get
            {
                return _destinationVideosRepository = _destinationVideosRepository ?? new DestinationVideosRepository(db);
            }
        }

        private IInterviewRepository _interviewRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IInterviewRepository InterviewRepository
        {
            get
            {
                return _interviewRepository = _interviewRepository ?? new InterviewRepository(db);
            }
        }

        private ITrendingNewsRepository _trendingNewsRepository;

        // Public Member ---------------------------------------------------------------------------------
        public ITrendingNewsRepository TrendingNewsRepository
        {
            get
            {
                return _trendingNewsRepository = _trendingNewsRepository ?? new TrendingNewsRepository(db);
            }
        }

        private IFAQRepository _fAQRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IFAQRepository FAQRepository
        {
            get
            {
                return _fAQRepository = _fAQRepository ?? new FAQRepository(db);
            }
        }

        private ITopDestinationRepository _topDestinationRepository;

        // Public Member ---------------------------------------------------------------------------------
        public ITopDestinationRepository TopDestinationRepository
        {
            get
            {
                return _topDestinationRepository = _topDestinationRepository ?? new TopDestinationRepository(db);
            }
        }

        private ILatestEventRepository _latestEventRepository;

        // Public Member ---------------------------------------------------------------------------------
        public ILatestEventRepository LatestEventRepository
        {
            get
            {
                return _latestEventRepository = _latestEventRepository ?? new LatestEventRepository(db);
            }
        }

        private IInterviewsInWhatsNewRepository _interviewsInWhatsNewRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IInterviewsInWhatsNewRepository InterviewsInWhatsNewRepository
        {
            get
            {
                return _interviewsInWhatsNewRepository = _interviewsInWhatsNewRepository ?? new InterviewsInWhatsNewRepository(db);
            }
        }
        private INewDestinationsInWhatsNewRepository _newDestinationsInWhatsNewRepository;

        // Public Member ---------------------------------------------------------------------------------
        public INewDestinationsInWhatsNewRepository NewDestinationsInWhatsNewRepository
        {
            get
            {
                return _newDestinationsInWhatsNewRepository = _newDestinationsInWhatsNewRepository ?? new NewDestinationsInWhatsNewRepository(db);
            }
        }

        private IPrivacyPolicyRepository _privacyPolicyRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IPrivacyPolicyRepository PrivacyPolicyRepository
        {
            get
            {
                return _privacyPolicyRepository = _privacyPolicyRepository ?? new PrivacyPolicyRepository(db);
            }
        }

        private ITeamMemberInAboutUsRepository _teamMemberInAboutUsRepository;

        // Public Member ---------------------------------------------------------------------------------
        public ITeamMemberInAboutUsRepository TeamMemberInAboutUsRepository
        {
            get
            {
                return _teamMemberInAboutUsRepository = _teamMemberInAboutUsRepository ?? new TeamMemberInAboutUsRepository(db);
            }
        }

        private IFestivalRepository _festivalRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IFestivalRepository FestivalRepository
        {
            get
            {
                return _festivalRepository = _festivalRepository ?? new FestivalRepository(db);
            }
        }

        private IAboutUsIntroductionRepository _aboutUsIntroductionRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IAboutUsIntroductionRepository AboutUsIntroductionRepository
        {
            get
            {
                return _aboutUsIntroductionRepository = _aboutUsIntroductionRepository ?? new AboutUsIntroductionRepository(db);
            }
        }

        private IAboutUsStatementRepository _aboutUsStatementRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IAboutUsStatementRepository AboutUsStatementRepository
        {
            get
            {
                return _aboutUsStatementRepository = _aboutUsStatementRepository ?? new AboutUsStatementRepository(db);
            }
        }

        private ITravelUtilityQueryRepository _travelUtilityQueryRepository;

        // Public Member ---------------------------------------------------------------------------------
        public ITravelUtilityQueryRepository TravelUtilityQueryRepository
        {
            get
            {
                return _travelUtilityQueryRepository = _travelUtilityQueryRepository ?? new TravelUtilityQueryRepository(db);
            }
        }

        private IContactUsRepository _contactUsRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IContactUsRepository ContactUsRepository
        {
            get
            {
                return _contactUsRepository = _contactUsRepository ?? new ContactUsRepository(db);
            }
        }

        private IUserCoverImageRepository _userCoverImageRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IUserCoverImageRepository UserCoverImageRepository
        {
            get
            {
                return _userCoverImageRepository = _userCoverImageRepository ?? new UserCoverImageRepository(db);
            }
        }

        private IUserPersonalInfoRepository _userPersonalInfoRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IUserPersonalInfoRepository UserPersonalInfoRepository
        {
            get
            {
                return _userPersonalInfoRepository = _userPersonalInfoRepository ?? new UserPersonalInfoRepository(db);
            }
        }

        private IUserGalleryRepository _userGalleryRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IUserGalleryRepository UserGalleryRepository
        {
            get
            {
                return _userGalleryRepository = _userGalleryRepository ?? new UserGalleryRepository(db);
            }
        }

        private IUserPostRepository _userPostRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IUserPostRepository UserPostRepository
        {
            get
            {
                return _userPostRepository = _userPostRepository ?? new UserPostRepository(db);
            }
        }

        private IBlogCategoryRepository _blogCategoryRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IBlogCategoryRepository BlogCategoryRepository
        {
            get
            {
                return _blogCategoryRepository = _blogCategoryRepository ?? new BlogCategoryRepository(db);
            }
        }

        private IUserNetworkRepository _userNetworkRepository;

        // Public Member ---------------------------------------------------------------------------------
        public IUserNetworkRepository UserNetworkRepository
        {
            get
            {
                return _userNetworkRepository = _userNetworkRepository ?? new UserNetworkRepository(db);
            }
        }

        public void Commit() {
            db.SaveChanges();
        }

        public void Dispose() {
            db.Dispose();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
