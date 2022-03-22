using System.Windows;
using InventoryOfEquipment.Lib;
using InventoryOfEquipment.ViewModels;
using InventoryOfEquipment.Views;

namespace InventoryOfEquipment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static DB db;
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            db = new DB("194.169.163.29", "inventory", "root", "root_mpt");

            var window = new MainWindow() {
                Height = 750,
                Width = 900,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window.DataContext =  new MainViewModel();
            window.ShowDialog();
        }
    }
}