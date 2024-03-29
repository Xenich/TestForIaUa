﻿using System;
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

        Controller controller;
        public AddTypeToDBWindow(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Введите наименование типа оборудования");
                return;
            }
            controller.AddType(textBoxName.Text);
        }
    }
}
