using CarDBSQLApplication_DAL;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
using System.Windows.Documents;

namespace CarDBSQLApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        EntityModel db;
        public MainPage()
        {
            InitializeComponent();

            try
            {
                db = new EntityModel();
                var EquipList = from d in db.newEquipment
                                join s in db.TablesManufacturer on d.intManufacturerID equals s.intManufacturerID
                                join t in db.TablesModel on d.intModelID equals t.intModelID
                                join v in db.TrackMeter on d.intEquipmentID equals v.intEquipmentID
                                select new { d.intGarageRoom, s.strName, t.strModelName, d.strManufYear, d.strSerialNo, v.intHoursHoursOperation, v.intMeterReading };
               
                equipGrid.ItemsSource = EquipList.ToList(); // устанавливаем привязку к кэшу
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mf.Source = new Uri("Pages/AddNewCarPage.xaml", UriKind.RelativeOrAbsolute);
            AddNewCarPage ap = new AddNewCarPage();
            MainWindow.mf.NavigationService.Navigate(ap);
        }

        public void onHyperlinkClick(object sender, RoutedEventArgs e)
        {
            MainWindow.mf.Source = new Uri("Pages/DetailsPage.xaml", UriKind.RelativeOrAbsolute);
            DetailsPage dp = new DetailsPage();
            MainWindow.mf.NavigationService.Navigate(dp);

        }
    }
}
