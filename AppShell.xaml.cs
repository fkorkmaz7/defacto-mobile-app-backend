using System;
using System.Collections.Generic;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels.Base;
using eShopOnContainers.Core.Views;
using eShopOnContainers.Core.Views.Hesabım;
using Xamarin.Forms;
using ListView = eShopOnContainers.Core.Views.ListView;

namespace eShopOnContainers.Core
{
    public partial class AppShell : Shell
    {
        public AppShell ()
        {
            InitializeRouting ();
            InitializeComponent ();

            var settingsService = ViewModelLocator.Resolve<ISettingsService> ();

            if (string.IsNullOrEmpty (settingsService.AuthAccessToken))
            {
                this.GoToAsync ("//Login");
            }

        }

        private void InitializeRouting()
        {
            Routing.RegisterRoute ("Basket", typeof (BasketView));
            Routing.RegisterRoute ("Settings", typeof (SettingsView));
            Routing.RegisterRoute ("OrderDetail", typeof (OrderDetailView));
            Routing.RegisterRoute("Hakkinda", typeof(HakkindaView));
            Routing.RegisterRoute("Siparis", typeof(SiparisView));
            Routing.RegisterRoute("Yardim", typeof(YardimView));
            Routing.RegisterRoute("Odeme", typeof(OdemeView));
            Routing.RegisterRoute("Adres", typeof(AdresView));
            Routing.RegisterRoute("Kisisel", typeof(KisiselView));
            Routing.RegisterRoute ("CampaignDetails", typeof(CampaignDetailsView));
            Routing.RegisterRoute ("Checkout", typeof (CheckoutView));
            Routing.RegisterRoute("Kategory", typeof(ListView));
        }


    }
}
