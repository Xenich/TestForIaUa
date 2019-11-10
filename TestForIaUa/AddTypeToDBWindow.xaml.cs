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
    /// Interaction logic for AddTypeToDBWindow.xaml
    /// </summary>
    public partial class AddTypeToDBWindow : Window
    {
        public event AddTypeDeleg addTypeEvent;         // событие - добавлен производитель

        public AddTypeToDBWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Введите наименование типа оборудования");
                return;
            }
            using (OfficeContext db = new OfficeContext())
            {
                Type t = new Type() { Name = textBoxName.Text };
                db.Types.Add(t);
                db.SaveChanges();
                if (addTypeEvent != null)
                    addTypeEvent(t);
                MessageBox.Show("Новый тип оборудования добавлен");
            }
        }
    }
}
