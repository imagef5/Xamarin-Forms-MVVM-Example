# Xamarin-Forms-MVVM-Example
Xamarin Forms 를 이용한 MVVM 예제

> 이미지 로딩을 위한 FFImageLoading.Forms 을 공통적으로 참조

# 1. MVVMBasic
- 기본적인 방법으로 MVVM 을 구현하는 코드 작성
- 간단한 Navigation Service 구현 - INavigationService  인터페이스 구현
- Passing Argiments 를 통한 Viewmodel Constructor Argument 전달
```
viewmodel c# code : 
        #region Constructor
        public MainPageViewModel(IUserService userService,INavigationService naviagtionService)
        {
            _userService = userService ; //new UserService();
            _navigationService = naviagtionService; //new NavigationService();

            ...
        }
        #endregion
....

xaml 파일 :
<ContentPage 
    ...
    xmlns:viewmodel="clr-namespace:MVVMBasic.ViewModels"
    xmlns:navigation="clr-namespace:MVVMBasic.Navigations"
    xmlns:repoServices="clr-namespace:CommonRepository.Services;assembly=CommonRepository"
    ...
    >
    <!-- ViewModel Binding -->
    <ContentPage.BindingContext>
        <viewmodel:MainPageViewModel >
            <!-- Passing Argiments  -->
            <x:Arguments>
                <repoServices:UserService />
                <navigation:NavigationService />
            </x:Arguments>
        </viewmodel:MainPageViewModel>
    </ContentPage.BindingContext>
    <!-- ViewModel Binding -->
    ....
```

# 2. MVVMWithIoC
- Unity IoC Container 와 함께 MVVM 을 구현하는 코드 작성
- 간단한 Navigation Service 구현 - INavigationService  인터페이스 구현
- ViewModelLocator 를 통한 ViewModel 접근 구현
```
    public class ViewModelLocator
    {
        ...
        public MainPageViewModel MainPageViewModel
        {
            get => ServiceLocator.Current.GetInstance<MainPageViewModel>(); 
        }
        
        public DetailPageViewModel DetailPageViewModel
        {
            get => ServiceLocator.Current.GetInstance<DetailPageViewModel>();
        }
        ...
     }

App.cs 파일
...
    Container = new UnityContainer();
    Container.RegisterType<IUserService, UserService>();
    Container.RegisterType<INavigationService, NavigationService>();
    ...
    var unityServiceLocator = new UnityServiceLocator(Container);
    ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
    
App.xaml 파일
...
<Application 
    ...
    xmlns:viewmodels="clr-namespace:MVVMWithIoC.ViewModels"
    ...
    >
	<Application.Resources>
		<!-- Application resource dictionary -->
		<ResourceDictionary>
		    <viewmodels:ViewModelLocator x:Key="Locator"/>
		</ResourceDictionary>
	</Application.Resources>
</Application>

MainPage.xaml 파일 
<ContentPage 
    .....
    BindingContext="{Binding MainPageViewModel, Source={StaticResource Locator}}">
```

# 3. MVVMWithPrism
- MVVM Helper Prism 을 이용한 MVVM 코드 구현
- https://github.com/PrismLibrary/Prism/tree/master/docs/Xamarin-Forms
