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
    public partial class GalleryPage : ContentPage
    {
        public GalleryPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            (BindingContext as ElementViewModel).index = (BindingContext as ElementViewModel).ImageList.IndexOf(((TappedEventArgs)e).Parameter as string);

            await Navigation.PushAsync(new ImagePage());

        }
    }
}