using CarDBSQLApplication_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CarDBSQLApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddNewCarPage.xaml
    /// </summary>
    public partial class AddNewCarPage : Page
    {
        public AddNewCarPage()
        {
            InitializeComponent();

            List<TablesManufacturer> lct = new List<TablesManufacturer>();
            List<TablesModel> modelLct = new List<TablesModel>();
            List<TablesSNPrefix> prefixLct = new List<TablesSNPrefix>();

            lct = AddNewCarPage.GetManufactList();
            ManufactList.ItemsSource = lct;

            modelLct = AddNewCarPage.GetModelList();
            ModelList.ItemsSource = modelLct;

            prefixLct = AddNewCarPage.GetPrefixList();
            PrefixList.ItemsSource = prefixLct;
        }

        public static List<TablesManufacturer> GetManufactList()
        {
            EntityModel db = new EntityModel();

            return db.TablesManufacturer.Select(p => p).ToList<TablesManufacturer>();
        }

        public static List<TablesModel> GetModelList()
        {
            EntityModel db = new EntityModel();

            return db.TablesModel.Select(p => p).ToList<TablesModel>();
        }

        public static List<TablesSNPrefix> GetPrefixList()
        {
            EntityModel db = new EntityModel();

            return db.TablesSNPrefix.Select(p => p).ToList<TablesSNPrefix>();
        }

        public void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        public void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mf.Source = new Uri("Pages/MainPage.xaml", UriKind.RelativeOrAbsolute);
            MainPage mp = new MainPage();
            MainWindow.mf.NavigationService.Navigate(mp);
        }
    }
}
