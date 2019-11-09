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
    /// Interaction logic for AddModelWindow.xaml
    /// </summary>
    public partial class AddModelWindow : Window
    {
        public AddModelWindow()
        {
            InitializeComponent();
            ComboBoxManuf.ItemsSource = GetManufacturers();
        }

        private Manufacturer[] GetManufacturers()
        {
            using (OfficeContext db = new OfficeContext())
            {

                Manufacturer[] manufacturers = db.Manufacturers.ToArray();
                return manufacturers;
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
