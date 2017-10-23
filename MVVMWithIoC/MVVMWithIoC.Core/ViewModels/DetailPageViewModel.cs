using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommonRepository.Models;

namespace MVVMWithIoC.ViewModels
{
    public class DetailPageViewModel : INotifyPropertyChanged
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
                _user = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region INotifiPropertyChanged Implement
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
