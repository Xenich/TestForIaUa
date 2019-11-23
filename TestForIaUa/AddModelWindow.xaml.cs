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
    public partial class AddModelWindow : Window
    {
        Controller controller;
        AddManufacturerDeleg addManufacturerDeleg;
        AddTypeDeleg addTypeDeleg;
        public AddModelWindow(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            Helper.SetTypesToComboBox(ComboBoxType);
            Helper.SetManufacturersToComboBox(ComboBoxManuf);
            addManufacturerDeleg = new AddManufacturerDeleg(Controller_addManufacturerEventHandler);
            addTypeDeleg = new AddTypeDeleg(Controller_addTypeEventHandler);
            controller.addManufacturerEvent += addManufacturerDeleg;
            controller.addTypeEvent += Controller_addTypeEventHandler;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxManuf.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите производителя из списка");
                return;
            }
            if (ComboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип оборудования из списка");
                return;
            }

            if (textBoxName.Text == "")
            {
                MessageBox.Show("Введите название модели");
                return;
            }
            controller.AddModel(textBoxName.Text, (Manufacturer)ComboBoxManuf.SelectedValue, (Type)ComboBoxType.SelectedValue);
            MessageBox.Show("Модель добавлена");
        }

        private void ComboBoxManuf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           // int id = (int)this.ComboBoxManuf.SelectedValue;          
        }

            // добавление производителя
        private void buttonAddNewManuf_Click(object sender, RoutedEventArgs e)
        {
            (new AddManufacturerToDBWindow(controller)).ShowDialog();
        }
        private void Controller_addManufacturerEventHandler()
        {
            Helper.SetManufacturersToComboBox(ComboBoxManuf);
        }
            // добавление типа
        private void buttonAddNewType_Click(object sender, RoutedEventArgs e)
        {
            (new AddTypeToDBWindow(controller)).ShowDialog();
        }
        private void Controller_addTypeEventHandler()
        {
            Helper.SetTypesToComboBox(ComboBoxType);
        }
    }
}
