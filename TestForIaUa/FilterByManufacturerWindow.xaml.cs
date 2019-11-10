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
    /// Interaction logic for FilterByManufacturerWindow.xaml
    /// </summary>
    public partial class FilterByManufacturerWindow : Window
    {
        public event FilterByManufacturerDeleg FilterByManufacturerEvent;         // событие - выбран производитель, по которому нужно фильтровать
        public FilterByManufacturerWindow()
        {
            InitializeComponent();
            Helper.SetManufacturersToComboBox(ComboBoxManufacturer);
        }

        private void buttonAdjust_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxManufacturer.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите производителя из списка");
                return;
            }
            Manufacturer manufacturer = (Manufacturer)ComboBoxManufacturer.SelectedValue;
            if (FilterByManufacturerEvent != null)
                FilterByManufacturerEvent(manufacturer);
            FilterByManufacturerEvent = null;
            this.Close();
        }
    }
}
