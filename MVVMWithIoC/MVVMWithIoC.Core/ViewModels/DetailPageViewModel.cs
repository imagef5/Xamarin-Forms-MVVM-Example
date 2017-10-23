using CommonRepository.Models;

namespace MVVMWithIoC.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        #region Private Fields Area
        private User _user;
        #endregion
        public DetailPageViewModel()
        {
        }

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
    }
}
