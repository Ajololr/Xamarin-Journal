using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Lab3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as CollectionViewModel).LoadData();
        }

        private void Pin_InfoWindowClicked(object sender, Xamarin.Forms.Maps.PinClickedEventArgs e)
        {
            var vm = (BindingContext as CollectionViewModel);
            var pin = (Pin)sender;
            AppData.SelectedStudent = vm.Students.First(a => a.Id == pin.ClassId);
            Navigation.PushAsync(new EditElementPage());
        }
    }
}