using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessDataModel.DB
{
    public partial class TravelOliveContext : DbContext
    {
        public TravelOliveContext()
        {
        }

        public TravelOliveContext(DbContextOptions<TravelOliveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<AboutUsIntroduction> AboutUsIntroduction { get; set; }
        public virtual DbSet<AboutUsStatement> AboutUsStatement { get; set; }
        public virtual DbSet<AreaOfExpertise> AreaOfExpertise { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<BlogCategory> BlogCategory { get; set; }
        public virtual DbSet<BlogComment> BlogComment { get; set; }
        public virtual DbSet<BlogPriority> BlogPriority { get; set; }
        public virtual DbSet<BlogReaction> BlogReaction { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CurrentNews> CurrentNews { get; set; }
        public virtual DbSet<Destination> Destination { get; set; }
        public virtual DbSet<DestinationVideos> DestinationVideos { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Faq> Faq { get; set; }
        public virtual DbSet<Festival> Festival { get; set; }
        public virtual DbSet<FresherCareer> FresherCareer { get; set; }
        public virtual DbSet<GalleryComment> GalleryComment { get; set; }
        public virtual DbSet<GalleryCommentReaction> GalleryCommentReaction { get; set; }
        public virtual DbSet<GalleryReaction> GalleryReaction { get; set; }
        public virtual DbSet<Interview> Interview { get; set; }
        public virtual DbSet<InterviewsInWhatsNew> InterviewsInWhatsNew { get; set; }
        public virtual DbSet<LatestEvent> LatestEvent { get; set; }
        public virtual DbSet<NewDestinationsInWhatsNew> NewDestinationsInWhatsNew { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<OfferAds> OfferAds { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<PostComment> PostComment { get; set; }
        public virtual DbSet<PostCommentReaction> PostCommentReaction { get; set; }
        public virtual DbSet<PostReaction> PostReaction { get; set; }
        public virtual DbSet<PrivacyPolicy> PrivacyPolicy { get; set; }
        public virtual DbSet<ProfessionalCareer> ProfessionalCareer { get; set; }
        public virtual DbSet<ProfileCategory> ProfileCategory { get; set; }
        public virtual DbSet<Reaction> Reaction { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StudentCareer> StudentCareer { get; set; }
        public virtual DbSet<TeamMemberInAboutUs> TeamMemberInAboutUs { get; set; }
        public virtual DbSet<TopDestination> TopDestination { get; set; }
        public virtual DbSet<TourTheme> TourTheme { get; set; }
        public virtual DbSet<TravelUtility> TravelUtility { get; set; }
        public virtual DbSet<TravelUtilityQuery> TravelUtilityQuery { get; set; }
        public virtual DbSet<TrendingNews> TrendingNews { get; set; }
        public virtual DbSet<UpcommingNews> UpcommingNews { get; set; }
        public virtual DbSet<UserCoverImage> UserCoverImage { get; set; }
        public virtual DbSet<UserFriends> UserFriends { get; set; }
        public virtual DbSet<UserFriendsRequest> UserFriendsRequest { get; set; }
        public virtual DbSet<UserGallery> UserGallery { get; set; }
        public virtual DbSet<UserPersonalInfo> UserPersonalInfo { get; set; }
        public virtual DbSet<UserPost> UserPost { get; set; }
        public virtual DbSet<UserRegLogin> UserRegLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=34.82.40.21;Initial Catalog=TravelOlive;Persist Security Info=True;User ID=sa;Password=pawan@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AboutUs>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AboutUsIntroduction>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImageFirst).IsUnicode(false);

                entity.Property(e => e.FeaturedImageSecond).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AboutUsStatement>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(550)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AreaOfExpertise>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BlogComment>(entity =>
            {
                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BlogPriority>(entity =>
            {
                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BlogReaction>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ContactUs>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.ContinentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ContinentName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CurrentNews>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.Property(e => e.AboutCountry).IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.HowToReach).IsUnicode(false);

                entity.Property(e => e.Miscellaneous).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TopAttraction).IsUnicode(false);

                entity.Property(e => e.TopDestination).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);

                entity.Property(e => e.Visadetail).IsUnicode(false);
            });

            modelBuilder.Entity<DestinationVideos>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("FAQ");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Festival>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<FresherCareer>(entity =>
            {
                entity.Property(e => e.AboutMe).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SkillId)
                    .HasColumnName("SkillID")
                    .IsUnicode(false);

                entity.Property(e => e.SocialMediaProfile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UploadProject).IsUnicode(false);

                entity.Property(e => e.UploadResume).IsUnicode(false);
            });

            modelBuilder.Entity<GalleryComment>(entity =>
            {
                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GalleryCommentReaction>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GalleryReaction>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<InterviewsInWhatsNew>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<LatestEvent>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<NewDestinationsInWhatsNew>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<OfferAds>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.PageId)
                    .HasColumnName("PageID")
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.PagePath)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.PageTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PostCommentReaction>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PostReaction>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PrivacyPolicy>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProfessionalCareer>(entity =>
            {
                entity.Property(e => e.AboutMe).IsUnicode(false);

                entity.Property(e => e.AreaOfExpertise).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentCompany)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentCtc)
                    .HasColumnName("CurrentCTC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentLocation).IsUnicode(false);

                entity.Property(e => e.ExpectedCtc)
                    .HasColumnName("ExpectedCTC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HighestQualification)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SkillId).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UploadProject).IsUnicode(false);

                entity.Property(e => e.UploadResume).IsUnicode(false);
            });

            modelBuilder.Entity<ProfileCategory>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Reaction>(entity =>
            {
                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AboutDescription).IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CoverImage).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gmcid)
                    .HasColumnName("GMCID")
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Occupation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Otp)
                    .HasColumnName("OTP")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImg).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SkillName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.StateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<StudentCareer>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TeamMemberInAboutUs>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TopDestination>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TourTheme>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ThemeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<TravelUtility>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtilityType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<TravelUtilityQuery>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfTravel).HasColumnType("date");

                entity.Property(e => e.DestinationCountry)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.StartCountry)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrendingNews>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UpcommingNews>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FeaturedImage).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<UserCoverImage>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserFriends>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserFriendsRequest>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserGallery>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Gallery).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<UserPersonalInfo>(entity =>
            {
                entity.Property(e => e.AboutDescription).IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CoverImage).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Occupation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImg).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserPost>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.RecUpd)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Video).IsUnicode(false);
            });

            modelBuilder.Entity<UserRegLogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserRegL__1788CCAC8B608301");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreating_1(modelBuilder);
        }
    }
}
