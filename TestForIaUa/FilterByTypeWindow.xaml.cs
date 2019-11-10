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
    /// Interaction logic for FilterByTypeWindow.xaml
    /// </summary>
    public partial class FilterByTypeWindow : Window
    {
        public event FilterByTypeDeleg FilterByTypeEvent;         // событие - выбран тип, по которому нужно фильтровать
        public FilterByTypeWindow()
        {
            InitializeComponent();
            Helper.SetTypesToComboBox(ComboBoxType);
        }

        private void buttonAdjust_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип из списка");
                return;
            }
            Type type = (Type)ComboBoxType.SelectedValue;
            if(FilterByTypeEvent!=null)
                FilterByTypeEvent(type);
            FilterByTypeEvent = null;
            this.Close();
        }
    }
}
