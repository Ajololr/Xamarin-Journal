using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElementPage : ContentPage
    { 
        public ElementPage()
        {
            Resources = DependencyService.Resolve<ResourceDictionary>();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var student = (BindingContext as ElementViewModel).SelectedStudent;
            if (!string.IsNullOrEmpty(student.Video))
            {
                VideoView.Source = student.Video;
            }
            (BindingContext as ElementViewModel).ErrorMessage = "";
            (BindingContext as ElementViewModel).SuccessMessage = "";
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var anime = (BindingContext as ElementViewModel).SelectedStudent;
            if (!string.IsNullOrEmpty(anime.Video))
            {
                MediaManager.CrossMediaManager.Current.Stop();
            }
            (BindingContext as ElementViewModel).ErrorMessage = "";
            (BindingContext as ElementViewModel).SuccessMessage = "";
        }

        private async void Button_Clicked_View_All(object sender, EventArgs e)
        {
            AppData.GallaryOpen = true;
            await Navigation.PushAsync(new GalleryPage());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GalleryPage());
        }
    }
}