using Lab3.FirebaseServices;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Lab3
{
    class SignUpViewModel : INotifyPropertyChanged
    {
        private FileResult _selectedImage;
        private string _message;
        private string _successMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public FileResult SelectedImage
        {
            get => _selectedImage;
            set
            {
                _selectedImage = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public string SuccessMessage
        {
            get => _successMessage;
            set
            {
                _successMessage = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
