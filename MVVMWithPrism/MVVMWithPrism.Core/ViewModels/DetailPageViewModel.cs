using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommonRepository.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace MVVMWithPrism.ViewModels
{
    /// <summary>
    /// DetailPage.xaml 페이지와 연결된 DetailPageViewModel class 
    /// </summary>
    /// <remarks>
    /// 회원 리스트 페이지에서 사용되는 ViewModel
    /// Prism 참조 
    /// https://github.com/PrismLibrary/Prism/tree/master/docs/Xamarin-Forms
    /// </remarks>
    public class DetailPageViewModel : BaseViewModel
    {
        #region Private Fields Area
        private User _user;
        #endregion

        #region Constructor
        public DetailPageViewModel()
        {
        }
        #endregion

        #region Property Area
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                SetProperty(ref _user, value);
            }
        }
        #endregion

        #region Override VaseViewMode INavagationAware 인터페이스

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("user"))
                User = (User)parameters["user"];
        }

        #endregion

    }
}
