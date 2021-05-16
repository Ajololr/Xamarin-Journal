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
    public partial class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            Resources = DependencyService.Resolve<ResourceDictionary>();
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as CollectionViewModel).Filtered = (await (BindingContext as CollectionViewModel).LoadData());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            AppData.SelectedStudent = ((TappedEventArgs)e).Parameter as Student;
            var elementPage = new EditElementPage();

            await Navigation.PushAsync(elementPage);
        }
        private async void Search_Text_Changed(object sender, EventArgs e)
        {
            var edit = (Entry)sender;
            if(edit.Text == null)
            {
                (BindingContext as CollectionViewModel).Filtered = (BindingContext as CollectionViewModel).Students;
            } 
            else
            {
                (BindingContext as CollectionViewModel).Filtered = (BindingContext as CollectionViewModel).Students.FindAll(st => (st.FirstName + " " + st.LastName + " " + st.SecondName).ToLower().Contains(edit.Text.ToLower()));
            }
        }
        
    }
}