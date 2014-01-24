using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WPF_Training.ViewModel
{
    class EditItemViewModel:ViewModelBase
    {
        public string Editedtxt { get; set; }
        public RelayCommand CancelCommand{get;private set;}
        public RelayCommand SaveCommand{get;private set;}
        private string Originaltxt { get; set;}
        public EditItemViewModel(string textTobeEdited)
        {
            Editedtxt = textTobeEdited;
            Originaltxt = textTobeEdited;
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(CloseWindow);
        }
        
        private void Cancel()
        {
            Editedtxt = Originaltxt;
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
