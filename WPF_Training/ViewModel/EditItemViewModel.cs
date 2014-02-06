using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WPF_Training.ViewModel
{
    class EditItemViewModel:ViewModelBase
    {
        public Person EditedPerson { get; set; }
        public RelayCommand CancelCommand{get;private set;}
        public RelayCommand SaveCommand{get;private set;}
        private readonly Person _originalPerson =new Person();
        public EditItemViewModel(Person person)
        {
            InitCommands();
            EditedPerson=new Person();
            if(person==null)return;
            EditedPerson = person;
            SetOriginalPerson(person);
        }
            
        private void InitCommands()
        {
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(CloseWindow);
        }

        private void SetOriginalPerson(Person person)
        {
            _originalPerson.Name = person.Name;
            _originalPerson.Surname = person.Surname;
        }

        private void Cancel()
        {
            EditedPerson = _originalPerson;
            CloseWindow();
        }

        private void CloseWindow()
        {
            var window = Application.Current.Windows[Application.Current.Windows.Count - 1];
            if (window != null)
                window.Close();
        }
    }
}
