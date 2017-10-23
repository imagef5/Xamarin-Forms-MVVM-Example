using System;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace MVVMWithIoC.ViewModels
{
    /// <summary>
    /// View model locator.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Gets the main page view model.
        /// </summary>
        /// <value>The main page view model.</value>
        public MainPageViewModel MainPageViewModel
        {
            //.netstandard 1.6 프로젝트에서 ServiceLocator.SetLocatorProvider(() => unityServiceLocator) 호출에 대한 참조가 깨짐
            //해결방법 : NuGet 패키지 -> Microsoft.NETCore.Portable.Compatibility 추가 
            //                       System.ComponentModel 추가 
            get => ServiceLocator.Current.GetInstance<MainPageViewModel>(); 
            //get => App.Container.Resolve<MainPageViewModel>();
        }

        /// <summary>
        /// Gets the detail page view model.
        /// </summary>
        /// <value>The detail page view model.</value>
        public DetailPageViewModel DetailPageViewModel
        {
            get => ServiceLocator.Current.GetInstance<DetailPageViewModel>();
            //get => App.Container.Resolve<DetailPageViewModel>();
        }
    }
}
