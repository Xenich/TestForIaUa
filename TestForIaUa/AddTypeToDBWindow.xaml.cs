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
        public AddTypeToDBWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            using (OfficeContext db = new OfficeContext())
            {
                Type m = new Type() { Name = textBoxName.Text };
                    db.Types.Add(m);
                    db.SaveChanges();
                    MessageBox.Show("Новый тип оборудования добавлен");
            }
        }
    }
}
