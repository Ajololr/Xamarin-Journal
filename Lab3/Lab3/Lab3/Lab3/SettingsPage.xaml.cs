using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ColorPicker;
using System.Globalization;
using System.Threading;
using Plugin.Multilingual;

namespace Lab3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private bool isStart = true;
        public SettingsPage()
        {
            Resources = DependencyService.Resolve<ResourceDictionary>();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var language = "English";
            switch (CrossMultilingual.Current.CurrentCultureInfo.Name)
            {
                case "ru":
                    {
                        language = "Русский";
                        break;
                    }
            }

            LanguagePicker.SelectedItem = language;

            FontSizeSlider.Value = Convert.ToDouble(Resources["FontSize"]);
            ModeSwitch.IsToggled = Application.Current.UserAppTheme == OSAppTheme.Dark;

            isStart = false;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (isStart) return;

            if (Application.Current.UserAppTheme == OSAppTheme.Dark)
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
            else
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (isStart) return;

            var slider = (Slider)sender;
            slider.Value = Math.Round(slider.Value);
            Resources["FontSize"] = Convert.ToInt32(slider.Value);
        }

        private void ColorPicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (isStart) return;
            var colorPicker = (ColorTriangle)sender;
            Resources["Color"] = colorPicker.SelectedColor.ToHex();
        }

        private async void Button_Sign_Out_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isStart) return;

            var picker = (Picker)sender;
            switch (picker.SelectedItem)
            {
                case "Русский":
                    {
                        CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("ru");
                        break;
                    }
                default:
                    {
                        CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
                        break;
                    }
            }
            AppData.LanguageChanged = true;
            await Navigation.PopToRootAsync();
            Application.Current.MainPage = new NavigationPage(new TabBarPage());
        }
    }
}