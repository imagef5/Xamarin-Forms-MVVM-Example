using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommonRepository.Services;
using CommonRepository.Models;
using System.Threading.Tasks;
using MVVMBasic.Interfaces;
using MVVMBasic.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace MVVMBasic.ViewModels
{
    ///<summary>
    /// BaseViewModel 을 구현하지 않고 
    /// 가장 기본적인 ViewModel을 구현하는 방법으로 Code 를 구현 하였습니다.
    /// </summary>
    public class MainPageViewModel : INotifyPropertyChanged
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
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MVVMBasic.ViewModels.MainPageViewModel"/> is busy.
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
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                    IsNotBusy = !_isBusy;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MVVMBasic.ViewModels.MainPageViewModel"/> is not busy.
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
                if (_isNotBusy != value)
                {
                    _isNotBusy = value;
                    OnPropertyChanged();
                    IsBusy = !_isNotBusy;
                    UserSelectedCommand.ChangeCanExecute();
                }
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

        #region INotifiPropertyChanged Implement
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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
                users?.ForEach(Users.Add);
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
