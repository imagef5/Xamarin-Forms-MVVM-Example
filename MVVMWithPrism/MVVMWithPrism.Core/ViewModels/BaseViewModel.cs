using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace MVVMWithPrism.ViewModels
{
    /// <summary>
    /// Base view model.
    /// </summary>
    public class BaseViewModel : BindableBase, INavigationAware
    {
        #region Private Fields Area
        private bool _isBusy;
        private bool _isNotBusy = true;
        #endregion

        #region Property Area
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MVVMWithPrism.ViewModels.BaseViewModel"/> is busy.
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
        /// Gets or sets a value indicating whether this <see cref="T:MVVMWithPrism.ViewModels.BaseViewModel"/> is not busy.
        /// </summary>
        /// <value><c>true</c> if is not busy; otherwise, <c>false</c>.</value>
        public bool IsNotBusy
        {
            get
            {
                return _isNotBusy;
            }
            private set
            {
                if (SetProperty(ref _isNotBusy, value))
                    IsBusy = !_isNotBusy;
            }
        }
        #endregion

        #region INavagationAware 인터페이스 구현
        /*
         * https://github.com/PrismLibrary/Prism/blob/master/docs/Xamarin-Forms/3-Navigation-Service.md 설명 참조
         */
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {

        }
        #endregion
    }
}
