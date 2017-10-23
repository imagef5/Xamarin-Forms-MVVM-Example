using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMWithIoC.Interfaces
{
    public interface INavigationService
    {
        Task NavigateAsync(Page page);
        Task NavigateBack();
    }
}
