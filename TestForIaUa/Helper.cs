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
        public static void SetModelsToComboBox(ComboBox comboBox)
        {
            using (OfficeContext db = new OfficeContext())
            {
                comboBox.ItemsSource = db.Models.ToArray();
            }
        }
    }
}
