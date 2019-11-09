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
using System.Windows.Shapes;

namespace TestForIaUa
{
    /// <summary>
    /// Interaction logic for AddManufacturerToDBWindow.xaml
    /// </summary>
    public partial class AddManufacturerToDBWindow : Window
    {
        public AddManufacturerToDBWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            using (OfficeContext db = new OfficeContext())
            {
                Manufacturer m = new Manufacturer() { Name = textBoxName.Text };
                db.Manufacturers.Add(m);
                db.SaveChanges();
                MessageBox.Show("Производитель добавлен");
            }
        }
    }
}
