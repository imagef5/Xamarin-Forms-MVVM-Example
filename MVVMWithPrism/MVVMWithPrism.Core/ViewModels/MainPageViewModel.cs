using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using CommonRepository.Services;
using CommonRepository.Models;
using System.Threading.Tasks;
using MVVMWithPrism.Helpers;

namespace MVVMWithPrism.ViewModels
{
    /// <summary>
    /// MainPage.xaml 페이지와 연결된 MainlPageViewModel class 
    /// </summary>
    /// <remarks>
    /// 회원 리스트 페이지에서 사용되는 ViewModel
    /// Prism 참조 
    /// https://github.com/PrismLibrary/Prism/tree/master/docs/Xamarin-Forms
    /// </remarks>
    public class MainPageViewModel : BaseViewModel
    {
        #region Private Fields Area
        private IUserService _userService;
        private INavigationService _navigationService;
        private List<User> _users = new List<User>();
        private DelegateCommand<User> _userSelectedCommand;
        #endregion

        #region Constructor Area
        public MainPageViewModel(INavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;

            GetUsersAsync().ContinueWith((arg) =>
            {

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        #endregion

        #region Property Area
        /// <summary>
        /// 사용자 리스트
        /// </summary>
        /// <value>The users.</value>
        public ObservableRangeCollection<User> Users { get; set; } = new ObservableRangeCollection<User>();

        #endregion

        #region Command Area
        /// <summary>
        /// Gets the user selected command.
        /// </summary>
        /// <value>The user selected command.</value>
        public DelegateCommand<User> UserSelectedCommand => _userSelectedCommand ??
                                                            (
                                                                    _userSelectedCommand = new DelegateCommand<User>
                                                                    (
                                                                        async ( user) =>
                                                                        {
                                                                            var p = new NavigationParameters();
                                                                            p.Add("user", user);
                                                                            //Prim Navigation 내용 참조
                                                                            await _navigationService.NavigateAsync("DetailPage", p);
                                                                        }
                                                                    ).ObservesCanExecute(() => IsNotBusy)
                                                            );

        #endregion


        #region Private Method Area
        /// <summary>
        /// 사용자 리스트 가져오기
        /// </summary>
        /// <returns>The users.</returns>
        private async Task GetUsersAsync()
        {
            //List<User> users = new List<User>();
            IsBusy = true;
            try
            {
                var users = await _userService.GetUsersAsync();
                Users.AddRange(users);
            }
            finally
            {
                IsBusy = false;
            }

            //return users;
        }
        #endregion
    }
}

