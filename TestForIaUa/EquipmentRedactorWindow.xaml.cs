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
        public event EquipmentRedactedDeleg EquipmentRedactedEvent;
        Equipment equipment;
        int id;
        public EquipmentRedactorWindow(int id)
        {
            InitializeComponent();
            this.id = id;
            Helper.SetModelsToComboBox(ComboBoxModel);
            using (OfficeContext db = new OfficeContext())
            {
                equipment = db.Equipments.Find(id);
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
            using (OfficeContext db = new OfficeContext())
            {
                equipment = db.Equipments.Find(id);
                equipment.Description = textBoxDescription.Text;
                if (ComboBoxModel.SelectedIndex != -1)
                {
                    Model model = (Model)ComboBoxModel.SelectedValue;
                    db.Models.Attach(model);
                    equipment.Model = model;
                }
                db.SaveChanges();
            }
            if (EquipmentRedactedEvent != null)
                EquipmentRedactedEvent();
        }
    }
}
