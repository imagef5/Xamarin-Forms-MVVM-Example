using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using MVVMWithIoC.Interfaces;

namespace MVVMWithIoC.Helpers
{
    /// <summary>
    /// 간단한 네비게이션 구현
    /// </summary>
    public class NavigationService : INavigationService
    {
        public async Task NavigateAsync(Page page)
        {
            var currentPage = GetCurrentPage();
            if (currentPage?.Parent is NavigationPage)
                await currentPage.Navigation.PushAsync(page);
            else
                await currentPage.Navigation.PushModalAsync(page);
        }

        public async Task NavigateBack()
        {
            var currentPage = GetCurrentPage();
            if (currentPage?.Parent is NavigationPage)
                await currentPage.Navigation.PopAsync();
            else
                await currentPage.Navigation.PopModalAsync();
        }

        private Page GetCurrentPage()
        {
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

            return currentPage;
        }
    }
}
