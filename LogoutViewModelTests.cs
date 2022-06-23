using eShopOnContainers.Core;
using eShopOnContainers.Core.Models.Orders;
using eShopOnContainers.Core.Services.Logout;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels;
using eShopOnContainers.Core.ViewModels.Base;
using eShopOnContainers.UnitTests.Mocks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests.ViewModels
{
    public class LogoutViewModelTests
    {

        public LogoutViewModelTests()
        {
            ViewModelLocator.UpdateDependencies(true);
        }

        [Fact]

        public void LogoutPropertyIsNullWhenViewModelInstantiatedTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IMyDataService>(new MyDataMockService ());
            var loginviewModel  = new LoginViewModel();

            Assert.Null(loginviewModel.LoginUrl);
        }

        [Fact]
        public async Task LogoutPropertyIsNotNullAfterViewModelInitializationTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var myDataservice = new MyDataMockService();
            Xamarin.Forms.DependencyService.RegisterSingleton<IMyDataService>(myDataservice);
            var loginviewModel = new LoginViewModel();

            var order = await myDataservice.GetLogoutInfoAsync(1493424,"furkan123","furkan");
            await loginviewModel.InitializeAsync(new Dictionary<string, string> { { nameof(Order.OrderNumber), order.logoutNumber.ToString() } });

            Assert.NotNull(loginviewModel.LoginUrl);
        }

        [Fact]
        public async Task SettingLogoutPropertyShouldRaisePropertyChanged()
        {
            bool invoked = false;
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var mydataservice = new MyDataMockService();
            Xamarin.Forms.DependencyService.RegisterSingleton<IMyDataService>(mydataservice);
            var loginViewModel = new LoginViewModel();

            loginViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("Order"))
                    invoked = true;
            };
            var logout = await mydataservice.GetLogoutInfoAsync(190101078,"uzuntas_12300","fatih");
            await loginViewModel.InitializeAsync(new Dictionary<string, string> { { nameof(logout.logoutNumber), logout.logoutNumber.ToString() } });

            Assert.True(invoked);
        }




    }
}
