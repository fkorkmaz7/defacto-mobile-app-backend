using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Models.Orders;
using eShopOnContainers.Core.Models.User;
using eShopOnContainers.Core.Services.Order;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IOrderService _orderService;
        private ObservableCollection<Order> _orders;
        private Order _selectedOrder;

        public ProfileViewModel()
        {
            this.MultipleInitialization = true;

            _settingsService = DependencyService.Get<ISettingsService>();
            _orderService = DependencyService.Get<IOrderService>();
        }

        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                RaisePropertyChanged(() => Orders);
            }
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                if (value == null)
                    return;
                _selectedOrder = null;
                RaisePropertyChanged(() => SelectedOrder);
            }
        }

        public ICommand YardimCommand => new Command(async () => await YardimAsync());

        public ICommand OdemeCommand => new Command(async () => await OdemeAsync());

        public ICommand KisiselCommand => new Command(async () => await KisiselAsync());

        public ICommand AdresCommand => new Command(async () => await AdresAsync());

        public ICommand HakkindaCommand => new Command(async () => await HakkindaAsync());

        public ICommand SiparisCommand => new Command(async () => await SiparisAsync());


        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());

        public ICommand OrderDetailCommand => new Command<Order>(async (order) => await OrderDetailAsync(order));

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            // Get orders
            var authToken = _settingsService.AuthAccessToken;
            var orders = await _orderService.GetOrdersAsync(authToken);
            Orders = orders.ToObservableCollection();

            IsBusy = false;
        }

        private async Task LogoutAsync()
        {
            IsBusy = true;

            // Logout
            await NavigationService.NavigateToAsync(
                "//Login",
                new Dictionary<string, string> { { "Logout", true.ToString() } });

            IsBusy = false;
        }

        private async Task HakkindaAsync()
        {
          

            // hakkında
            await NavigationService.NavigateToAsync(
                "Hakkinda",
             new Dictionary<string, string> { { "Hakkinda", true.ToString() } });

          
        }

        private async Task YardimAsync()
        {


            // yardim
            await NavigationService.NavigateToAsync(
                "Yardim",
             new Dictionary<string, string> { { "Yardim", true.ToString() } });


        }
        private async Task OdemeAsync()
        {


            // odeme
            await NavigationService.NavigateToAsync(
                "Odeme",
             new Dictionary<string, string> { { "Odeme", true.ToString() } });


        }
        private async Task AdresAsync()
        {


            // adres
            await NavigationService.NavigateToAsync(
                "Adres",
             new Dictionary<string, string> { { "Adres", true.ToString() } });


        }
        private async Task KisiselAsync()
        {


            // kisisel
            await NavigationService.NavigateToAsync(
                "Kisisel",
             new Dictionary<string, string> { { "Kisisel", true.ToString() } });


        }

        private async Task SiparisAsync()
        {


            // siparislerim
            await NavigationService.NavigateToAsync(
                "Siparis",
             new Dictionary<string, string> { { "Siparis", true.ToString() } });


        }

        private async Task OrderDetailAsync(Order order)
        {
            await NavigationService.NavigateToAsync(
                "OrderDetail",
                new Dictionary<string, string> { { nameof(Order.OrderNumber), order.OrderNumber.ToString() } });
        }

     


       


    }
}