using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var resources = new ResourceDictionary
            {
                ["Color"] = "#6666FF",
                ["FontSize"] = 14,
            };
            DependencyService.RegisterSingleton(resources);

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
