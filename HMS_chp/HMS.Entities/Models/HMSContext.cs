using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HMS.Entities.Models.Mapping;
using Repository.Pattern.Ef6;

namespace HMS.Entities.Models
{
    public partial class HMSContext : DataContext
    {
        static HMSContext()
        {
            Database.SetInitializer<HMSContext>(null);
        }

        public HMSContext()
            : base("Name=HMSContext")
        {
        }

        public DbSet<AdvertisePosition> AdvertisePositions { get; set; }
        public DbSet<Advertis> Advertises { get; set; }
        public DbSet<AdvertiseType> AdvertiseTypes { get; set; }
        public DbSet<AnswerChoice> AnswerChoices { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<BinaryObject> BinaryObjects { get; set; }
        public DbSet<BinaryObjectType> BinaryObjectTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientInfo> ClientInfoes { get; set; }
        public DbSet<ClientInformation> ClientInformations { get; set; }
        public DbSet<ContactU> ContactUs { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<DistanceUnit> DistanceUnits { get; set; }
        public DbSet<Duration> Durations { get; set; }
        public DbSet<Duration1> Durations1 { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventsType> EventsTypes { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<HotelDetail> HotelDetails { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<PackageDetail> PackageDetails { get; set; }
        public DbSet<PackageDisplayType> PackageDisplayTypes { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackagesInfo> PackagesInfoes { get; set; }
        public DbSet<PackageSource> PackageSources { get; set; }
        public DbSet<PackageSubscribe> PackageSubscribes { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<PageInfo> PageInfoes { get; set; }
        public DbSet<PageInfoDetail> PageInfoDetails { get; set; }
        public DbSet<PageType> PageTypes { get; set; }
        public DbSet<PeoplePerRoom> PeoplePerRooms { get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<QuestionDetail> QuestionDetails { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<QuizDetail> QuizDetails { get; set; }
        public DbSet<QuizQuestionAnswer> QuizQuestionAnswers { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<RecentSearch> RecentSearches { get; set; }
        public DbSet<Rightss> Rightsses { get; set; }
        public DbSet<RoleRightss> RoleRightsses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Scholare> Scholares { get; set; }
        public DbSet<Shifting> Shiftings { get; set; }
        public DbSet<Statuss> Statusses { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdvertisePositionMap());
            modelBuilder.Configurations.Add(new AdvertisMap());
            modelBuilder.Configurations.Add(new AdvertiseTypeMap());
            modelBuilder.Configurations.Add(new AnswerChoiceMap());
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new BinaryObjectMap());
            modelBuilder.Configurations.Add(new BinaryObjectTypeMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ClientInfoMap());
            modelBuilder.Configurations.Add(new ClientInformationMap());
            modelBuilder.Configurations.Add(new ContactUMap());
            modelBuilder.Configurations.Add(new ContentMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CurrencyTypeMap());
            modelBuilder.Configurations.Add(new DistanceUnitMap());
            modelBuilder.Configurations.Add(new DurationMap());
            modelBuilder.Configurations.Add(new Duration1Map());
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new EventsTypeMap());
            modelBuilder.Configurations.Add(new ExperienceMap());
            modelBuilder.Configurations.Add(new HotelDetailMap());
            modelBuilder.Configurations.Add(new HotelMap());
            modelBuilder.Configurations.Add(new NewsMap());
            modelBuilder.Configurations.Add(new PackageDetailMap());
            modelBuilder.Configurations.Add(new PackageDisplayTypeMap());
            modelBuilder.Configurations.Add(new PackageMap());
            modelBuilder.Configurations.Add(new PackagesInfoMap());
            modelBuilder.Configurations.Add(new PackageSourceMap());
            modelBuilder.Configurations.Add(new PackageSubscribeMap());
            modelBuilder.Configurations.Add(new PackageTypeMap());
            modelBuilder.Configurations.Add(new PageInfoMap());
            modelBuilder.Configurations.Add(new PageInfoDetailMap());
            modelBuilder.Configurations.Add(new PageTypeMap());
            modelBuilder.Configurations.Add(new PeoplePerRoomMap());
            modelBuilder.Configurations.Add(new PriceTypeMap());
            modelBuilder.Configurations.Add(new QuestionAnswerMap());
            modelBuilder.Configurations.Add(new QuestionDetailMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new QuestionTypeMap());
            modelBuilder.Configurations.Add(new QuizDetailMap());
            modelBuilder.Configurations.Add(new QuizQuestionAnswerMap());
            modelBuilder.Configurations.Add(new QuizMap());
            modelBuilder.Configurations.Add(new RecentSearchMap());
            modelBuilder.Configurations.Add(new RightssMap());
            modelBuilder.Configurations.Add(new RoleRightssMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new ScholareMap());
            modelBuilder.Configurations.Add(new ShiftingMap());
            modelBuilder.Configurations.Add(new StatussMap());
            modelBuilder.Configurations.Add(new SubscribeMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserAccountMap());
            modelBuilder.Configurations.Add(new UserTypeMap());
        }
    }
}
