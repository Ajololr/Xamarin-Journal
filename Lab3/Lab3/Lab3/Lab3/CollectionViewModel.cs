using Lab3.FirebaseServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab3
{
    class CollectionViewModel : INotifyPropertyChanged
    {
        private List<Student> _students = new List<Student>();
        private List<Student> _filtered = new List<Student>();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Student> Filtered
        {
            get => _filtered;
            set
            {
                _filtered = value;
                OnPropertyChanged();
            }
        }

        public List<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public async Task<List<Student>> LoadData()
        {
            var firestore = DependencyService.Get<IFirestore>();
            Students = await firestore.GetAll();
            return Students;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
