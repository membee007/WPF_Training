using System.Windows;
using WPF_Training.ViewModel;

namespace WPF_Training
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var vm = new MyViewModel();
            var view = new MainWindow {DataContext = vm};
            view.ShowDialog();
        }

    }
}
