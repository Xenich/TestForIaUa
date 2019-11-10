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
    /// Interaction logic for AddEquipmentWindow.xaml
    /// </summary>
    public partial class AddEquipmentWindow : Window
    {
        public event AddEquipmentDeleg EquipmentAddedEvent;         // событие - добавление нового оборудования
        public AddEquipmentWindow()
        {
            InitializeComponent();
                // заполняем комбобокс с моделями
            Dictionary<Model, string> comboSource;
            using (OfficeContext db = new OfficeContext())
            {
                Model[] models = db.Models
                    .Include("Type")
                    .Include("Manufacturer")
                    .ToArray();
                //string[] comboItemSource = new string[models.Length];
                comboSource = new Dictionary<Model, string>();
                for (int i = 0; i < models.Length; i++)
                {
                    comboSource.Add(models[i], "Тип: " + models[i].Type.Name + ", производитель: " + models[i].Manufacturer.Name + " - " + models[i].Name);
                }
                ComboBoxModel.ItemsSource = comboSource;
                ComboBoxModel.DisplayMemberPath = "Value";
                ComboBoxModel.SelectedValuePath = "Key";
            }
            ComboBoxModel.ItemsSource = comboSource;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxModel.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите модель из списка");
                return;
            }
            using (OfficeContext db = new OfficeContext())
            {
                Equipment equipment = new Equipment();
                equipment.Description = textBoxDescription.Text;
                Model model = (Model)ComboBoxModel.SelectedValue;
               
                db.Models.Attach(model);
                equipment.Model = model;
                Equipment equip = db.Equipments.Add(equipment);
                db.SaveChanges();
                MessageBox.Show("Оборудование добавлено");
                if(EquipmentAddedEvent!=null)
                    EquipmentAddedEvent(equip);
            }
        }
    }
}
