using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestForIaUa
{
    class Helper
    {
        public static void SetTypesToComboBox(ComboBox comboBox)
        {
            using (OfficeContext db = new OfficeContext())
            {
                comboBox.ItemsSource = db.Types.ToArray();
            }
        }

        public static void SetManufacturersToComboBox(ComboBox comboBox)
        {
            using (OfficeContext db = new OfficeContext())
            {
                comboBox.ItemsSource = db.Manufacturers.ToArray();
            }
        }
        public static void SetModelsToComboBox(ComboBox ComboBoxModel)
        {
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
    }
}
