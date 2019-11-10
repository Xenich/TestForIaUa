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
    /// Interaction logic for AddModelWindow.xaml
    /// </summary>
    public partial class AddModelWindow : Window
    {
        public AddModelWindow()
        {
            InitializeComponent();
            Helper.SetTypesToComboBox(ComboBoxType);
            Helper.SetManufacturersToComboBox(ComboBoxManuf);
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
                MessageBox.Show("Введите название типа оборудования");
                return;
            }

            using (OfficeContext db = new OfficeContext())
            {
                Model m = new Model();
                m.Name = textBoxName.Text;
                //m.ManufacturerId = (int)(ComboBoxManuf.SelectedValue);        SelectedValuePath="Id"
                //m.TypeId = (int)(ComboBoxType.SelectedValue);                 SelectedValuePath="Id"
                Manufacturer manuf = (Manufacturer)ComboBoxManuf.SelectedValue;
                Type typ = (Type)ComboBoxType.SelectedValue;
                db.Manufacturers.Attach(manuf);
                db.Types.Attach(typ);
                m.Manufacturer = manuf;
                m.Type = typ;
                
                db.Models.Add(m);
                db.SaveChanges();
                MessageBox.Show("Модель добавлена");
            }
        }

        private void ComboBoxManuf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           // int id = (int)this.ComboBoxManuf.SelectedValue;          
        }
    }
}
