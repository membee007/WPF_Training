using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WPF_Training.ViewModel
{
    internal class MyViewModel : ViewModelBase
    {
        public RelayCommand GetListItemsCommand { get; private set; }
        public RelayCommand RemoveSelected { get; private set; }
        public RelayCommand EditSelected { get; private set; }
        public ObservableCollection<string> ItemsCollection { get; private set; }
        public string Selectedtxt { get; set; }
        public MyViewModel()
        {
            GetListItemsCommand = new RelayCommand(AddToList);
            RemoveSelected = new RelayCommand(RemoveSelectedItem);
            EditSelected = new RelayCommand(EditSelectedItem);
            ItemsCollection = new ObservableCollection<string> ();
        }

        private void AddToList()
        {
            AddItemToCollection("mike is a genius " + DateTime.Now.ToString("G"));
        }

        private void AddItemToCollection(string item)
        {
            ItemsCollection.Add(item);
        }

        private void RemoveSelectedItem()
        {
            ItemsCollection.Remove(Selectedtxt);
        }

        private void EditSelectedItem()
        {
            var index = ItemsCollection.IndexOf(Selectedtxt);
            var editedtxt = LaunchEditScreen();
            if(index>-1)
            ItemsCollection[index] = editedtxt;
        }

        private string LaunchEditScreen()
        {
            var vm = new EditItemViewModel(Selectedtxt);
            var view = new EditListViewItem { DataContext = vm };
            view.ShowDialog();
            return vm.Editedtxt;
        }

    }
}

