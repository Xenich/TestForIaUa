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
    /// Interaction logic for RepairWindow.xaml
    /// </summary>
    public partial class RepairWindow : Window
    {
        public RepairWindow()
        {
            InitializeComponent();
            Dictionary<Equipment, string> comboSource;
            using (OfficeContext db = new OfficeContext())
            {
                Equipment[] equipments = db.Equipments
                    .Include("Model")
                    .ToArray();
                comboSource = new Dictionary<Equipment, string>();
                for (int i = 0; i < equipments.Length; i++)
                {
                    comboSource.Add(equipments[i], "Инв. номер: " + equipments[i].Id + ", модель: " + equipments[i].Model.Name);
                }
                ComboBoxEquipment.ItemsSource = comboSource;
                ComboBoxEquipment.DisplayMemberPath = "Value";
                ComboBoxEquipment.SelectedValuePath = "Key";
            }
            ComboBoxEquipment.ItemsSource = comboSource;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxEquipment.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите борудование из списка");
                return;
            }

            using (OfficeContext db = new OfficeContext())
            {
                Repair repair = new Repair();
                repair.Description = textBoxDescription.Text;
                repair.DateTime = calendar.SelectedDate.Value;
                Equipment eq = (Equipment)ComboBoxEquipment.SelectedValue;
                db.Equipments.Attach(eq);

                repair.Equipment = eq;
                db.Repairs.Add(repair);
                db.SaveChanges();
                MessageBox.Show("Информация о ремонте добавлена");
            }
        }
    }
}
