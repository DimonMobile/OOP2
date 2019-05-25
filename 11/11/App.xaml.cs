using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _11
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            _11.MainWindow view = new _11.MainWindow();
            DbContexts.RecordContext context = new DbContexts.RecordContext();
            view.DataContext = new ViewModels.MainViewModel(context);
            view.Show();
        }
    }
}
