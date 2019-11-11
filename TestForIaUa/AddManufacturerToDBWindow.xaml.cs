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
    public partial class AddManufacturerToDBWindow : Window
    {
        public AddManufacturerToDBWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Введите наименование производителя!");
                return;
            }
            Controller.AddManufacturer(textBoxName.Text);
        }
    }
}
