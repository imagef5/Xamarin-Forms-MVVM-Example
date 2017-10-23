using CommonRepository.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using MVVMWithIoC.Interfaces;
using MVVMWithIoC.Navigations;
using MVVMWithIoC.ViewModels;
using Xamarin.Forms;

namespace MVVMWithIoC
{
    public partial class App : Application
    {
        public static UnityContainer Container { get; private set; }

        public App()
        {
            InitializeComponent();

            Init();

            MainPage = new NavigationPage(new MainPage());
        }

        private void Init()
        {
            Container = new UnityContainer();
            Container.RegisterType<IUserService, UserService>();
            Container.RegisterType<INavigationService, NavigationService>();
            //Container.RegisterType<MainPageViewModel>(new ContainerControlledLifetimeManager());

            //.netstandard 1.6 프로젝트에서 ServiceLocator.SetLocatorProvider(() => unityServiceLocator) 호출에 대한 참조가 깨짐
            //해결방법 : NuGet 패키지 -> Microsoft.NETCore.Portable.Compatibility 추가 
            //                       System.ComponentModel 추가 
            var unityServiceLocator = new UnityServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
