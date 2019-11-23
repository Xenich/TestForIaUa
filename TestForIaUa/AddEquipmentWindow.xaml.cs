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
    public partial class AddEquipmentWindow : Window
    {
        Controller controller;
        AddModelDeleg addModelDeleg;
        public AddEquipmentWindow(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            addModelDeleg = new AddModelDeleg(Controller_addModelEventHandler);
            controller.addModelEvent += addModelDeleg;
            Helper.SetModelsToComboBox(ComboBoxModel);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxModel.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите модель из списка");
                return;
            }
            controller.AddEquipment(textBoxDescription.Text, (Model)ComboBoxModel.SelectedValue);
            MessageBox.Show("Оборудование добавлено");
        }
            // добавить новую модель
        private void buttonAddNewModel_Click(object sender, RoutedEventArgs e)
        {
            (new AddModelWindow(controller)).ShowDialog();
        }
        private void Controller_addModelEventHandler()
        {
            Helper.SetModelsToComboBox(ComboBoxModel);
        }
    }
}
