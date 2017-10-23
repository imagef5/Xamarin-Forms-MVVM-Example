using System.Collections.Generic;
using CommonRepository.Services;
using CommonRepository.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using MVVMWithIoC.Helpers;
using MVVMWithIoC.Interfaces;
using MVVMWithIoC.Views;

namespace MVVMWithIoC.ViewModels
{
    /// <summary>
    /// Main page view model.
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
        #region Private Fields Area
        private IUserService _userService;
        private INavigationService _navigationService;
        private List<User> _users = new List<User>();
        private bool _isBusy;
        private bool _isNotBusy = true;
        private Command<User> _userSelectedCommand;
        #endregion

        #region Constructor
        public MainPageViewModel(IUserService userService,INavigationService naviagtionService)
        {
            _userService = userService ; //new UserService();
            _navigationService = naviagtionService; //new NavigationService();

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
        /// <summary>
        /// 사용자 리스트
        /// </summary>
        /// <value>The users.</value>
        public ObservableRangeCollection<User> Users { get; set; } = new ObservableRangeCollection<User>();

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MVVMWithIoC.ViewModels.MainPageViewModel"/> is busy.
        /// </summary>
        /// <value><c>true</c> if is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (SetProperty(ref _isBusy, value))
                    IsNotBusy = !_isBusy;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MVVMWithIoC.ViewModels.MainPageViewModel"/> is not busy.
        /// </summary>
        /// <value><c>true</c> if is not busy; otherwise, <c>false</c>.</value>
        public bool IsNotBusy
        {
            get
            {
                return _isNotBusy;
            }
            set
            {
                if (SetProperty(ref _isNotBusy, value, UserSelectedCommand.ChangeCanExecute))
                    IsBusy = !_isNotBusy;
            }
        }
        #endregion

        #region Command Area
        /// <summary>
        /// Gets the user selected command.
        /// </summary>
        /// <value>The user selected command.</value>
        public Command<User> UserSelectedCommand => _userSelectedCommand ??
                                                    (
                                                        _userSelectedCommand = new Command<User>
                                                                                (
                                                                                    async (user) =>
                                                                                    {
                                                                                        var detailPage = new DetailPage();
                                                                                        var detailPageViewModel = new DetailPageViewModel();
                                                                                        detailPageViewModel.User = user;
                                                                                        detailPage.BindingContext = detailPageViewModel;

                                                                                        await _navigationService.NavigateAsync(detailPage);
                                                                                    },
                                                                                    (user) => IsNotBusy
                                                                                )
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
