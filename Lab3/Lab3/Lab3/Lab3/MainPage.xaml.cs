using Lab3.FirebaseServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Resources = DependencyService.Resolve<ResourceDictionary>();
            InitializeComponent();
        }

        private async void Button_Sign_In_Clicked(object sender, EventArgs e)
        {
            try
            {
                var auth = DependencyService.Get<IAuth>();
                var email = signInEmailEntry.Text;
                var password = signInPasswordEntry.Text;

                await auth.SignIn(email, password);

                await Navigation.PushAsync(new TabBarPage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void Button_Sign_Up_Clicked(object sender, EventArgs e)
        {
            var signUpPage = new SignUpPage();
            await Navigation.PushAsync(signUpPage);
        }
    }
}
