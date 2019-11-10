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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace TestForIaUa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ВСЁ ЭТО ВЫНЕСТИ В КОНТРОЛЛЕР       
        Dictionary<int, DataGridClass> dic = new Dictionary<int, DataGridClass>();        // словарь: id - DataGridClass для отображения в датагриде
        AddEquipmentDeleg addEquipmentDeleg;
        AddManufacturerDeleg addManufacturerDeleg;
        AddTypeDeleg addTypeDeleg;
        EquipmentRedactedDeleg equipmentRedactedDeleg;
        //FilterByTypeDeleg filterByTypeDeleg;
        //FilterByManufacturerDeleg filterByManufacturerDeleg;
        public MainWindow()
        {
            InitializeComponent();
            addEquipmentDeleg = new AddEquipmentDeleg(AddEquipment_EquipmentAddedEvent);
            addManufacturerDeleg = new AddManufacturerDeleg(AM_addManufacturerEventHandler);
            addTypeDeleg = new AddTypeDeleg(AT_addTypeEventHandler);
            equipmentRedactedDeleg = new EquipmentRedactedDeleg(EquipmentRedactedEventHandler);
            //filterByTypeDeleg = new FilterByTypeDeleg(FilterByType_FilterByTypeEvent);
            //filterByManufacturerDeleg = new FilterByManufacturerDeleg(FilterByManufacturer_FilterByManufacturerEvent);
            mainDataGrid.ItemsSource = dic.Values;
            FillMainDataGrid();
            Helper.SetTypesToComboBox(ComboBoxType);
            Helper.SetManufacturersToComboBox(ComboBoxManuf);
        }
            // заполнение датагрида
        private void FillMainDataGrid()
        {
            dic.Clear();
            using (OfficeContext db = new OfficeContext())
            {
                string query = "Select Equipments.Id, mm.ModelName, mm.TypeName, mm.ManName, Equipments.Description FROM Equipments INNER JOIN " +
                                "(Select Models.Id as [ModelID], Models.Name as [ModelName], Manufacturers.Id as [ManID], Manufacturers.Name as [ManName], Types.Id as [TypeID], Types.Name as [TypeName] " +
                                "FROM Models, Manufacturers, Types " +
                                "WHERE Models.ManufacturerId = Manufacturers.Id AND Models.TypeId = Types.Id) as [mm] " +
                                "ON Equipments.ModelId = mm.ModelID";

                List<DataGridClass> sourceForDataGrid = db.Database.SqlQuery<DataGridClass>(query).ToList<DataGridClass>();      //        // источник данных для датагрида
                foreach (DataGridClass dgc in sourceForDataGrid)
                {
                    dic.Add(dgc.id, dgc);
                }    
            }
            mainDataGrid.Items.Refresh();
        }

            // добавление нового оборудования
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEquipmentWindow AddEquipment = new AddEquipmentWindow();
            AddEquipment.EquipmentAddedEvent += addEquipmentDeleg;
            AddEquipment.ShowDialog();
            AddEquipment.EquipmentAddedEvent -= addEquipmentDeleg;
        }
            // обработчик события добавления нового оборудования
        private void AddEquipment_EquipmentAddedEvent(Equipment equip)
        {
            DataGridClass dg = new DataGridClass(equip.Id, equip.Model.Name, equip.Model.Manufacturer.Name,equip.Model.Type.Name, equip.Description );
            dic.Add(dg.id, dg);
            mainDataGrid.Items.Refresh();
            AdjustFilter();
        }

            // добвление типа
        private void buttonAddType_Click(object sender, RoutedEventArgs e)
        {
            AddTypeToDBWindow AT = new AddTypeToDBWindow();
            AT.addTypeEvent += addTypeDeleg;
            AT.ShowDialog();
            AT.addTypeEvent -= addTypeDeleg;
        }
        private void AT_addTypeEventHandler(Type t)
        {
            Helper.SetTypesToComboBox(ComboBoxType);
        }

            // добавление производителя
        private void buttonAddManufacturer_Click(object sender, RoutedEventArgs e)
        {
            AddManufacturerToDBWindow AM = new AddManufacturerToDBWindow();
            AM.addManufacturerEvent += addManufacturerDeleg;
            AM.ShowDialog();
            AM.addManufacturerEvent -= addManufacturerDeleg;
        }
        private void AM_addManufacturerEventHandler(Manufacturer m)
        {
            Helper.SetManufacturersToComboBox(ComboBoxManuf);
        }

            // добавление новой модели
        private void buttonAddModel_Click(object sender, RoutedEventArgs e)
        {
            (new AddModelWindow()).ShowDialog();
        }
            // добавление ремонта
        private void buttonRepair_Click(object sender, RoutedEventArgs e)
        {
            new RepairWindow().ShowDialog();
        }
            // формирование отчёта по поломкам
        private void buttonReport_Click(object sender, RoutedEventArgs e)
        {
            (new ReportByDateWindow()).ShowDialog();
        }

            // удаление оборудования
        private void mainDataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                MessageBoxResult res = MessageBox.Show("Удалить из базы?","Удалить?",MessageBoxButton.OKCancel);
                if (res == MessageBoxResult.OK)
                {
                    object item = mainDataGrid.SelectedItem;
                    int id = ((DataGridClass)item).id;
                    using (OfficeContext db = new OfficeContext())
                    {
                        Equipment eq = new Equipment
                        {
                           Id = id
                        };
                        db.Equipments.Attach(eq);
                        db.Equipments.Remove(eq);
                        db.SaveChanges();

                        /*string query = "DELETE FROM Equipments WHERE id =" + id;
                        db.Database.ExecuteSqlCommand(query);*/
                        dic.Remove(id);
                        mainDataGrid.Items.Refresh();
                    }
                }
            }
        }
  
            // фильтр по типу
        private void ComboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdjustFilter();
        }
            // фильтр по производителю
        private void ComboBoxManuf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdjustFilter();
        }
            // применение фильтра
        void AdjustFilter()
        {
            string query = "Select Equipments.Id, mm.ModelName, mm.TypeName, mm.ManName, Equipments.Description FROM Equipments INNER JOIN " +
            "(Select Models.Id as [ModelID], Models.Name as [ModelName], Manufacturers.Id as [ManID], Manufacturers.Name as [ManName], Types.Id as [TypeID], Types.Name as [TypeName] " +
            "FROM Models, Manufacturers, Types " +
            "WHERE Models.ManufacturerId = Manufacturers.Id AND Models.TypeId = Types.Id ";
            if (ComboBoxManuf.SelectedIndex != -1)
            {
                Manufacturer m =(Manufacturer)ComboBoxManuf.SelectedValue;
                query += ("AND Manufacturers.Id = " + m.Id + " ");
            }
            if (ComboBoxType.SelectedIndex!=-1)
            {
                Type t = (Type)ComboBoxType.SelectedValue;
                query += ("AND Types.Id = " + t.Id + " ");
            }
            query += ") as [mm] ON Equipments.ModelId = mm.ModelID";
            using (OfficeContext db = new OfficeContext())
            {
                List<DataGridClass> sourceForDataGrid = db.Database.SqlQuery<DataGridClass>(query).ToList<DataGridClass>();      //        // источник данных для датагрида
                dic.Clear();
                foreach (DataGridClass dgc in sourceForDataGrid)
                {
                    dic.Add(dgc.id, dgc);
                }
                mainDataGrid.Items.Refresh();
            }
        }
            // Сброс фильтра
        private void filterNoneButton_Click(object sender, RoutedEventArgs e)
        {
            FillMainDataGrid();
            ComboBoxManuf.SelectedIndex = -1;
            ComboBoxType.SelectedIndex = -1;
        }
            // даблклик по гриду - вызывает карточку оборудования
        private void mainDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = mainDataGrid.SelectedItem;
            int id = ((DataGridClass)item).id;
            Equipment eq;
            using (OfficeContext db = new OfficeContext())
            {
                eq = db.Equipments.Find(id);
                EquipmentRedactorWindow ERW = new EquipmentRedactorWindow(id);
                ERW.EquipmentRedactedEvent += equipmentRedactedDeleg;
                ERW.ShowDialog();
                ERW.EquipmentRedactedEvent -= equipmentRedactedDeleg;
            }
        }
            // событие редактирования оборудования (после даблклика)- обновляем грид
        private void EquipmentRedactedEventHandler()
        {
            FillMainDataGrid();
        }
    }

    // класс - источник для датагрида
    public class DataGridClass
    {
        public DataGridClass()
        { }
        public DataGridClass(int id, string ModelName, string ManName, string TypeName, string Description)
        {
            this.id = id;
            this.ModelName = ModelName;
            this.TypeName = TypeName;
            this.ManName = ManName;
            this.Description = Description;
        }
        public int id { get; set; }
        public string ModelName { get; set; }
        public string TypeName { get; set; }
        public string ManName { get; set; }
        public string Description { get; set; }
    }
}




/* СВАЛКА
         // фильтр по типу
        private void filterTypeButton_Click(object sender, RoutedEventArgs e)
        {
            FilterByTypeWindow FBTW = new FilterByTypeWindow();
            FBTW.FilterByTypeEvent += filterByTypeDeleg;
            FBTW.ShowDialog();
        }
                // Обработчик события выбора типа для фильтра
        private void FilterByType_FilterByTypeEvent(Type type)
        {
            int typeid = type.Id;
            using (OfficeContext db = new OfficeContext())
            {
                string query = "Select Equipments.Id, mm.ModelName, mm.TypeName, mm.ManName, Equipments.Description FROM Equipments INNER JOIN " +
                                "(Select Models.Id as [ModelID], Models.Name as [ModelName], Manufacturers.Id as [ManID], Manufacturers.Name as [ManName], Types.Id as [TypeID], Types.Name as [TypeName] " +
                                "FROM Models, Manufacturers, Types " +
                                "WHERE Models.ManufacturerId = Manufacturers.Id AND Models.TypeId = Types.Id AND Types.Id="+ typeid+") as [mm] " +
                                "ON Equipments.ModelId = mm.ModelID";

                List<DataGridClass> sourceForDataGrid = db.Database.SqlQuery<DataGridClass>(query).ToList<DataGridClass>();      //        // источник данных для датагрида
                dic.Clear();
                foreach (DataGridClass dgc in sourceForDataGrid)
                {
                    dic.Add(dgc.id, dgc);
                }
                mainDataGrid.Items.Refresh();
            }
        }

        private void filterManufacturerButton_Click(object sender, RoutedEventArgs e)
        {
            FilterByManufacturerWindow FBMW = new FilterByManufacturerWindow();
            FBMW.FilterByManufacturerEvent += FilterByManufacturer_FilterByManufacturerEvent;
            FBMW.ShowDialog();
        }

        private void FilterByManufacturer_FilterByManufacturerEvent(Manufacturer manufacturer)
        {
            int manufacturerid = manufacturer.Id;
            using (OfficeContext db = new OfficeContext())
            {
                string query = "Select Equipments.Id, mm.ModelName, mm.TypeName, mm.ManName, Equipments.Description FROM Equipments INNER JOIN " +
                                "(Select Models.Id as [ModelID], Models.Name as [ModelName], Manufacturers.Id as [ManID], Manufacturers.Name as [ManName], Types.Id as [TypeID], Types.Name as [TypeName] " +
                                "FROM Models, Manufacturers, Types " +
                                "WHERE Models.ManufacturerId = Manufacturers.Id AND Models.TypeId = Types.Id AND Manufacturers.Id=" + manufacturerid + ") as [mm] " +
                                "ON Equipments.ModelId = mm.ModelID";

                List<DataGridClass> sourceForDataGrid = db.Database.SqlQuery<DataGridClass>(query).ToList<DataGridClass>();      //        // источник данных для датагрида
                dic.Clear();
                foreach (DataGridClass dgc in sourceForDataGrid)
                {
                    dic.Add(dgc.id, dgc);
                }
                mainDataGrid.Items.Refresh();
            }
        }
 
 * */
