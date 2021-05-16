using Lab3.FirebaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            Resources = DependencyService.Resolve<ResourceDictionary>();
            InitializeComponent();
        }

        private async void Button_Sign_Up_Clicked(object sender, EventArgs e)
        {
            try
            {
                (BindingContext as SignUpViewModel).ErrorMessage = "";
                (BindingContext as SignUpViewModel).SuccessMessage = "";
                var auth = DependencyService.Get<IAuth>();

                if (signUpEmailEntry.Text == null || signUpPasswordEntry.Text == null ||
                    signUpFirstName.Text == null || signUplastName.Text == null ||
                    sugnUpSecondName.Text == null || birthdayPicker.Date == null ||
                    (BindingContext as SignUpViewModel).SelectedImage == null)
                {
                    (BindingContext as SignUpViewModel).ErrorMessage = "Please, fill all fields";
                    return;
                }

                var url = await DependencyService.Get<IStorage>().UploadImage((BindingContext as SignUpViewModel).SelectedImage);
                var result = await auth.SignUp(signUpEmailEntry.Text, signUpPasswordEntry.Text, signUpFirstName.Text,
                    signUplastName.Text, sugnUpSecondName.Text, birthdayPicker.Date, new[] { url });

                if (result != null)
                {
                    var firestore = DependencyService.Get<IFirestore>();
                    await firestore.Add(result);
                    (BindingContext as SignUpViewModel).SuccessMessage = "User Added";
                }
            } 
            catch  (Exception ex)
            {
                (BindingContext as SignUpViewModel).ErrorMessage = ex.Message;
            }

        }

        private async void Image_Tapped(object sender, EventArgs e)
        {
            var image = await MediaPicker.PickPhotoAsync();
            if (image != null)
            {
                (BindingContext as SignUpViewModel).SelectedImage = image;
            }
        }
    }
}