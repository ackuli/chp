using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Repository.Pattern.UnitOfWork;
using HMS.Service.Models;
using Repository.Pattern.Repositories;
using Repository.Pattern.DataContext;
using HMS.Entities.Models;
using Repository.Pattern.Ef6;
using HMS.Service.ViewModels;

namespace HMS.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IDataContextAsync, HMSContext>(new PerRequestLifetimeManager())
             .RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager())
             .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
             .RegisterType<IRepositoryAsync<BinaryObject>, Repository<BinaryObject>>()
             .RegisterType<IBinaryObjectService, BinaryObjectService>()
             .RegisterType<IRepositoryAsync<QuestionAnswer>, Repository<QuestionAnswer>>()
             .RegisterType<IQuestionAnswersService, QuestionAnswerService>()
             .RegisterType<IRepositoryAsync<QuestionType>, Repository<QuestionType>>()
             .RegisterType<IQuestionTypeService, QuestionTypeService>()
             .RegisterType<IRepositoryAsync<Event>, Repository<Event>>()
             .RegisterType<IEventService, EventService>()
             .RegisterType<IRepositoryAsync<EventsType>, Repository<EventsType>>()
             .RegisterType<IEventsTypesService, EventsTypeService>()
             .RegisterType<IRepositoryAsync<News>, Repository<News>>()
             .RegisterType<INewssService, NewsService>()
             .RegisterType<IRepositoryAsync<UserAccount>, Repository<UserAccount>>()
             .RegisterType<IUserAccountsService, UserAccountService>()
             .RegisterType<IRepositoryAsync<Role>, Repository<Role>>()
             .RegisterType<IRolesService, RoleService>()
             .RegisterType<IRepositoryAsync<Country>, Repository<Country>>()
             .RegisterType<ICountrysService, CountryService>()
             .RegisterType<IRepositoryAsync<ClientInfo>, Repository<ClientInfo>>()
             .RegisterType<IClientInfosService, ClientInfoService>()
             .RegisterType<IRepositoryAsync<EventsType>, Repository<EventsType>>()
             .RegisterType<IEventsTypesService, EventsTypeService>()
             .RegisterType<IRepositoryAsync<AdvertisePosition>, Repository<AdvertisePosition>>()
             .RegisterType<IAdvertisePositionService, AdvertisePositionService>()
             .RegisterType<IRepositoryAsync<Advertis>, Repository<Advertis>>()
             .RegisterType<IAdvertissService, AdvertisService>()
             .RegisterType<IHomePageViewModelService, HomePageViewModelService>()
             .RegisterType<InewsEventVMService, newsEventVMService>()
             .RegisterType<IRepositoryAsync<Experience>, Repository<Experience>>()
             .RegisterType<IExperiencesService, ExperienceService>()
             .RegisterType<IRepositoryAsync<Package>, Repository<Package>>()
             .RegisterType<IPackagesService, PackageService>()
             .RegisterType<IRepositoryAsync<Hotel>, Repository<Hotel>>()
             .RegisterType<IHotelsService, HotelService>()
             .RegisterType<IRepositoryAsync<PeoplePerRoom>, Repository<PeoplePerRoom>>()
             .RegisterType<IPeoplePerRoomsService, PeoplePerRoomService>()


              .RegisterType<IRepositoryAsync<ContactU>, Repository<ContactU>>()
             .RegisterType<IContactUsService, ContactUsService>()

             .RegisterType<IRepositoryAsync<RoleRightss>, Repository<RoleRightss>>()
             .RegisterType<IRoleRightsssService, RoleRightssService>()
              .RegisterType<IRepositoryAsync<Rightss>, Repository<Rightss>>()
             .RegisterType<IRightsssService, RightssService>()

             .RegisterType<IRepositoryAsync<Duration>, Repository<Duration>>()
             .RegisterType<IDurationsService, DurationService>()

              .RegisterType<IRepositoryAsync<Duration>, Repository<Duration>>()
              .RegisterType<IDurationsService, DurationService>()

               .RegisterType<IRepositoryAsync<Shifting>, Repository<Shifting>>()
               .RegisterType<IShiftingService, ShiftingService>()

                .RegisterType<IRepositoryAsync<PackagesInfo>, Repository<PackagesInfo>>()
                .RegisterType<IPackagesInfoService, PackagesInfoService>()

                .RegisterType<IRepositoryAsync<PackageType>, Repository<PackageType>>()
                .RegisterType<IPackageTypeService, PackageTypeService>()



               .RegisterType<IRepositoryAsync<CurrencyType>, Repository<CurrencyType>>()
               .RegisterType<ICurrencyTypesService, CurrencyTypeService>()
               .RegisterType<IRepositoryAsync<PackageSubscribe>, Repository<PackageSubscribe>>()
               .RegisterType<IPackageSubscribeService, PackageSubscribeService>()
               .RegisterType<IPackageDisplayTypeSevice, PackageDisplayTypeSevice>()
               .RegisterType<IRepositoryAsync<PackageDisplayType>, Repository<PackageDisplayType>>()

               .RegisterType<IScholareService, ScholareService>()
               .RegisterType<IRepositoryAsync<Scholare>, Repository<Scholare>>()

               .RegisterType<IDistanceUnitService, DistanceUnitsService>()
               .RegisterType<IRepositoryAsync<DistanceUnit>, Repository<DistanceUnit>>()

               .RegisterType<IContentService, ContentService>()
               .RegisterType<IRepositoryAsync<Content>, Repository<Content>>()
               .RegisterType<IStoredProcedures, HMSContext>()




               .RegisterType<IQuestionsService, QuestionService>()
               .RegisterType<IRepositoryAsync<Question>, Repository<Question>>()

               .RegisterType<IQuestionDetailsService, QuestionDetailService>()
               .RegisterType<IRepositoryAsync<QuestionDetail>, Repository<QuestionDetail>>()

               .RegisterType<IQuizQuestionAnswersService, QuizQuestionAnswerService>()
               .RegisterType<IRepositoryAsync<QuizQuestionAnswer>, Repository<QuizQuestionAnswer>>()

               .RegisterType<IQuizsService, QuizService>()
               .RegisterType<IRepositoryAsync<Quiz>, Repository<Quiz>>()

               .RegisterType<IAnswerChoicesService, AnswerChoiceService>()
               .RegisterType<IRepositoryAsync<AnswerChoice>, Repository<AnswerChoice>>()

               .RegisterType<IAnswersService, AnswerService>()
               .RegisterType<IRepositoryAsync<Answer>, Repository<Answer>>()
               .RegisterType<IQuizDetailsService, QuizDetailService>()
               .RegisterType<IRepositoryAsync<QuizDetail>, Repository<QuizDetail>>()
             ;
        }
    }
}
