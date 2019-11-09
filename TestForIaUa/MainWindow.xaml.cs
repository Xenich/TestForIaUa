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
using System.Data.Entity;

namespace TestForIaUa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            using (OfficeContext db = new OfficeContext())
            {
                string query =  "Select Equipments.Id, mm.ModelName, mm.TypeName, mm.ManName, Equipments.Description FROM Equipments INNER JOIN "+
                                "(Select Models.Id as [ModelID], Models.Name as [ModelName], Manufacturers.Id as [ManID], Manufacturers.Name as [ManName], Types.Id as [TypeID], Types.Name as [TypeName] "+
                                "FROM Models, Manufacturers, Types "+
                                "WHERE Models.Manufacturer_Id = Manufacturers.Id AND Models.Type_Id = Types.Id) as [mm] "+
                                "ON Equipments.Model_Id = mm.ModelID";

                DataGridClass[] res = db.Database.SqlQuery<DataGridClass>(query).ToArray();
                foreach (DataGridClass obj in res)
                {
                    mainDataGrid.Items.Add(obj);
                }
            }
        }

        private void NewDataBase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenDataBase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            (new AddEquipmentWindow()).ShowDialog();
        }

        private void buttonReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonAddType_Click(object sender, RoutedEventArgs e)
        {
            (new AddTypeToDBWindow()).ShowDialog();
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonAddManufacturer_Click(object sender, RoutedEventArgs e)
        {
            (new AddManufacturerToDBWindow()).ShowDialog();
        }

        private void buttonAddModel_Click(object sender, RoutedEventArgs e)
        {
            (new AddModelWindow()).ShowDialog();
        }

        private void buttonRepair_Click(object sender, RoutedEventArgs e)
        {
            new RepairWindow().ShowDialog();
        }
    }

    class DataGridClass
    {
        public int id { get; set; }
        public string ModelName { get; set; }
        public string TypeName { get; set; }
        public string ManName { get; set; }
        public string Description { get; set; }
    }
}
