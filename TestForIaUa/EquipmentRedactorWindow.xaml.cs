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
    /// Interaction logic for EquipmentRedactorWindow.xaml
    /// </summary>
    public partial class EquipmentRedactorWindow : Window
    {
        Controller controller;
        int id;
        public EquipmentRedactorWindow(int id, Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            this.id = id;
            Helper.SetModelsToComboBox(ComboBoxModel);
            using (OfficeContext db = new OfficeContext())
            {
                Equipment equipment = db.Equipments.Find(id);
                textBoxDescription.Text = equipment.Description;
                Repair[] repairs = db.Repairs.Where(c => c.EquipmentId == id).ToArray();
                foreach (Repair r in repairs)
                {
                    textBoxRepairs.AppendText(r.DateTime.ToShortDateString()+": "+ r.Description + Environment.NewLine);
                }
            }
        }

            // применить изменения
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxModel.SelectedIndex != -1)
                controller.RedactEquipment(id, textBoxDescription.Text, (Model)ComboBoxModel.SelectedValue);
            else
                controller.RedactEquipment(id, textBoxDescription.Text, null);
        }
    }
}
