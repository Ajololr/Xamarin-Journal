using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lab3
{
    public class ElementViewModel : INotifyPropertyChanged
    {
        private Student _selectedStudent;
        private List<string> _imageList;
        public int index = 0;

        private string _message;
        private string _successMessage;

        public event PropertyChangedEventHandler PropertyChanged;
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

        public int Index
        {
            get => index;
            set
            {
                index = value;
                OnPropertyChanged();
            }
        }

        public string CurrentImage
        {
            get => _imageList[Index];
        }

        public List<string> ImageList
        {
            get => _imageList;
            set
            {
                _imageList = value;
                OnPropertyChanged();
            }
        }
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ElementViewModel()
        {
            SelectedStudent = AppData.SelectedStudent;
            var imageList = new List<string>(SelectedStudent.Images);

            ImageList = imageList;
            AppData.GallaryOpen = false;
            
        }
    }
}
