using Lab3.FirebaseServices;
using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditElementPage : ContentPage
    {
        private FileResult _pickVideo;
        private FileResult _pickedImage;
        public EditElementPage()
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
            var student = (BindingContext as ElementViewModel).SelectedStudent;
            if (!string.IsNullOrEmpty(student.Video))
            {
                MediaManager.CrossMediaManager.Current.Stop();
            }
            (BindingContext as ElementViewModel).ErrorMessage = "";
            (BindingContext as ElementViewModel).SuccessMessage = "";
        }
        private async void Button_Save_Clicked(object sender, EventArgs e)
        {
            (BindingContext as ElementViewModel).ErrorMessage = "";
            (BindingContext as ElementViewModel).SuccessMessage = "";
            var firestore = DependencyService.Get<IFirestore>();
            var student = (BindingContext as ElementViewModel).SelectedStudent;

            if (LatitudeEntry.Text != null && LongitudeEntry.Text != null)
            {
                await firestore.Update(student);
                (BindingContext as ElementViewModel).SuccessMessage = "Saved";
            } else
            {
                (BindingContext as ElementViewModel).ErrorMessage = "Fill all fields";
            }
        }

        private async void Button_Image_Clicked(object sender, EventArgs e)
        {
            var firestore = DependencyService.Get<IFirestore>();
            var student = (BindingContext as ElementViewModel).SelectedStudent;
            var storage = DependencyService.Get<IStorage>();
            var image = await MediaPicker.PickPhotoAsync();
            if (image != null)
            {
                _pickedImage = image;

                var name = Guid.NewGuid() + ".jpeg";

                var url = await storage.UploadImage(_pickedImage);

                student.Images = student.Images.Concat(new[] { url }).ToArray();

                await firestore.Update(student);
            }
        }
        private async void Button_Clicked_Gallery(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GalleryPage());
        }

        private async void Button_Video_Clicked(object sender, EventArgs e)
        {
            var firestore = DependencyService.Get<IFirestore>();
            var student = (BindingContext as ElementViewModel).SelectedStudent;
            var storage = DependencyService.Get<IStorage>();
            _pickVideo = await MediaPicker.PickVideoAsync();

            var videoUrl = await storage.UploadVideo(_pickVideo);
            VideoView.Source = videoUrl;
            student.Video = videoUrl;

            await firestore.Update(student);
        }
    }
}