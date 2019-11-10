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
    /// Interaction logic for AddManufacturerToDBWindow.xaml
    /// </summary>
    public partial class AddManufacturerToDBWindow : Window
    {
        public event AddManufacturerDeleg addManufacturerEvent;         // событие - добавлен производитель
        public AddManufacturerToDBWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Введите наименование производителя!");
                return;
            }
            using (OfficeContext db = new OfficeContext())
            {
                string query = "Select Id From Manufacturers Where Name = '" + textBoxName.Text+"'";
                int[] res = db.Database.SqlQuery<int>(query).ToArray();
                if (res.Length > 0)
                {
                    MessageBox.Show("Такой производитель уже есть");
                    return;
                }

                Manufacturer m = new Manufacturer() { Name = textBoxName.Text };
                db.Manufacturers.Add(m);
                db.SaveChanges();
                if (addManufacturerEvent != null)
                    addManufacturerEvent(m);
                MessageBox.Show("Производитель добавлен");
            }
        }
    }
}
