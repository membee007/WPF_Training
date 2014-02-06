using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WPF_Training.ViewModel
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    
    internal class MainViewModel : ViewModelBase
    {
        public RelayCommand AddToListComanCommand { get; private set; }
        public RelayCommand RemoveSelectedCommand { get; private set; }
        public RelayCommand EditSelectedCommand { get; private set; }
        public ObservableCollection<Person> Persons { get; private set; }
        public Person SelectedPerson { get; set; }

        public MainViewModel()
        {
            AddToListComanCommand = new RelayCommand(AddToList);
            RemoveSelectedCommand = new RelayCommand(RemoveSelectedItem);
            EditSelectedCommand = new RelayCommand(EditSelectedItem);
            Persons = new ObservableCollection<Person> ();
        }

        private void AddToList()
        {
            SelectedPerson= new Person();
            var person = LaunchEditScreen();
            if(person.Name!=null||person.Surname!=null)
            Persons.Add(person);
        }

        private void RemoveSelectedItem()
        {
            Persons.Remove(SelectedPerson);
        }

        private void EditSelectedItem()
        {
            var index = Persons.IndexOf(SelectedPerson);
            var person = LaunchEditScreen();
            if(index>-1)
            Persons[index] = person;
        }

        private Person LaunchEditScreen()
        {
            var vm = new EditItemViewModel(SelectedPerson);
            var view = new EditListViewItem { DataContext = vm };
            view.ShowDialog();
            return vm.EditedPerson;
        }

    }
}

