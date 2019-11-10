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
using CsvHelper;
using System.IO;


namespace TestForIaUa
{
    /// <summary>
    /// Interaction logic for ReportByDateWindow.xaml
    /// </summary>
    public partial class ReportByDateWindow : Window
    {
        public ReportByDateWindow()
        {
            InitializeComponent();
        }

        private void buttoGo_Click(object sender, RoutedEventArgs e)
        {
            if (startDate.SelectedDate == null)
            {
                MessageBox.Show("Выберите начальную дату");
                return;
            }
            if (endDate.SelectedDate == null)
            {
                MessageBox.Show("Выберите конечную дату");
                return;
            }
            if (startDate.SelectedDate > endDate.SelectedDate)
            {
                MessageBox.Show("Начальная дата позже конечной");
                return;
            }
            DateTime dtStart = startDate.SelectedDate.Value;
            DateTime dtend = endDate.SelectedDate.Value;
            using (OfficeContext db = new OfficeContext())
            {
                string query = "SELECT Repairs.Id, Repairs.DateTime, Repairs.Description, Equipments.Id as [InvNumber],  Equipments.Description as [EqDescription], mm.ModelName, mm.TypeName, mm.ManufacturerName " +
                        "From Repairs, Equipments " +
                        "INNER JOIN " +
                        " (SELECT Models.Id as [ModelID], Models.Name as [ModelName], Manufacturers.Name as [ManufacturerName], Types.Name as [TypeName] " +
                        "FROM Models, Manufacturers, Types " +
                        "WHERE Models.ManufacturerId = Manufacturers.Id AND Models.TypeId = Types.Id) as [mm] " +
                        "ON mm.ModelID = Equipments.ModelId " +
                        "WHERE Repairs.EquipmentId = Equipments.Id AND Repairs.DateTime BETWEEN '" + dtStart.ToString("MM/dd/yyyy") + "' AND '" + dtend.ToString("MM/dd/yyyy") + "'";
                Report[] report = db.Database.SqlQuery<Report>(query).ToArray();
                if (report.Length == 0)
                {
                    MessageBox.Show("Ремонты за выбранный период не проводились");
                    return;
                }
                using (StreamWriter writer = new StreamWriter("Отчёт о ремонтах.csv"))
                {
                    using (CsvWriter csv = new CsvWriter(writer))
                    {
                        csv.WriteRecords(report);
                    }
                }
                MessageBox.Show("Отчёт сформирован, находится в файле \"Отчёт о ремонтах.csv\" в каталоге с программой");
            }
        }
    }

    class Report
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public int InvNumber { get; set; }
        public string EqDescription { get; set; }
        public string ModelName { get; set; }
        public string TypeName { get; set; }
        public string ManufacturerName { get; set; }
    }
}
