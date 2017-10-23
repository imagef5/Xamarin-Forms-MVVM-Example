using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMBasic.Interfaces
{
    public interface INavigationService
    {
        Task NavigateAsync(Page page);
        Task NavigateBack();
    }
}
