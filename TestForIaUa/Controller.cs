using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestForIaUa
{
    public class Controller
    {
        public event AddManufacturerDeleg addManufacturerEvent;      // событие - добавлен производитель
        public event AddTypeDeleg addTypeEvent;                      // событие - добавлен тип оборудования
        public event AddModelDeleg addModelEvent;                    // событие - добавлена новая модель оборудования
        public event AddEquipmentDeleg EquipmentAddedEvent;          // событие - добавление нового оборудования
        public event EquipmentRedactedDeleg EquipmentRedactedEvent;  // событие - отредактировано оборудование
        private static Controller instance = null;

        public static Controller GetInstance()
        {
            if (instance == null)
                instance = new Controller();
            return instance;
        }
            // добавление нового производителя
        public void AddManufacturer(string name)
        {
            using (OfficeContext db = new OfficeContext())
            {
                string query = "Select Id From Manufacturers Where Name = '" + name + "'";
                int[] res = db.Database.SqlQuery<int>(query).ToArray();
                if (res.Length > 0)
                {
                    MessageBox.Show("Такой производитель уже есть");
                    return;
                }
                Manufacturer m = new Manufacturer() { Name = name };
                db.Manufacturers.Add(m);
                db.SaveChanges();
                MessageBox.Show("Производитель добавлен");
                if (addManufacturerEvent != null)
                    addManufacturerEvent();
            }
        }

            // добавление нового типа оборудования
        public void AddType(string name)
        {
            using (OfficeContext db = new OfficeContext())
            {
                string query = "Select Id From Types Where Name = '" + name + "'";
                int[] res = db.Database.SqlQuery<int>(query).ToArray();
                if (res.Length > 0)
                {
                    MessageBox.Show("Такой тип уже есть");
                    return;
                }

                Type t = new Type() { Name = name };
                db.Types.Add(t);
                db.SaveChanges();
                if (addTypeEvent != null)
                    addTypeEvent();
                MessageBox.Show("Новый тип оборудования добавлен");
            }
        }

            // добавление нового оборудования
        public void AddEquipment(string description, Model model)
        {
            using (OfficeContext db = new OfficeContext())
            {
                Equipment equipment = new Equipment();
                equipment.Description = description;
                db.Models.Attach(model);
                equipment.Model = model;
                Equipment equip = db.Equipments.Add(equipment);
                db.SaveChanges();
                if (EquipmentAddedEvent != null)
                    EquipmentAddedEvent(equip);
            }
        }

            // добавление новой модели оборудования
        public Model AddModel(string name, Manufacturer manuf, Type typ)
        {
            Model m = new Model();
            using (OfficeContext db = new OfficeContext())
            {
                m.Name = name;
                db.Manufacturers.Attach(manuf);
                db.Types.Attach(typ);
                m.Manufacturer = manuf;
                m.Type = typ;
                db.Models.Add(m);
                db.SaveChanges();
                if (addModelEvent != null)
                    addModelEvent();
            }
            return m;
        }
            
            // редактирование оборудования
        public void RedactEquipment(int id, string description, Model model)
        {
            using (OfficeContext db = new OfficeContext())
            {
                Equipment equipment = db.Equipments.Find(id);
                equipment.Description = description;
                if (model != null)
                {
                    db.Models.Attach(model);
                    equipment.Model = model;
                }
                db.SaveChanges();
            }
            if (EquipmentRedactedEvent != null)
                EquipmentRedactedEvent();
        }

            // заполнение БД тестовыми значениями
        public void TestFillDB()
        {
            using (OfficeContext db = new OfficeContext())
            {
                db.Database.Delete();
                
                Manufacturer man1 = new Manufacturer() { Name = "LG" };
                Manufacturer man2 = new Manufacturer() { Name = "Sumsung" };
                Manufacturer man3 = new Manufacturer() { Name = "Sony" };
                Manufacturer man4 = new Manufacturer() { Name = "Nikon" };
                Manufacturer man5 = new Manufacturer() { Name = "Asus" };
                Manufacturer man6 = new Manufacturer() { Name = "Lenovo" };
                Manufacturer man7 = new Manufacturer() { Name = "Dell" };
                Manufacturer man8 = new Manufacturer() { Name = "Apple" };
                List<Manufacturer> manList = new List<Manufacturer>() { man1, man2, man3, man4, man5, man6, man7, man8};
                db.Manufacturers.AddRange(manList);
                db.SaveChanges();
                if (addManufacturerEvent != null)
                    addManufacturerEvent();

                Type t1 = new Type() { Name = "Монитор" };
                Type t2 = new Type() { Name = "Клавиатура" };
                Type t3 = new Type() { Name = "Мышь" };
                Type t4 = new Type() { Name = "Фотоаппарат" };
                Type t5 = new Type() { Name = "Флешка" };
                Type t6 = new Type() { Name = "Колонки" };
                Type t7 = new Type() { Name = "Жёсткий диск" };
                Type t8 = new Type() { Name = "Принтер" };
                List<Type> typeList = new List<Type>() { t1, t2, t3, t4, t5, t6, t7, t8 };
                db.Types.AddRange(typeList);
                db.SaveChanges();
                if (addTypeEvent != null)
                    addTypeEvent();

                Model m1 = AddModel("Модель1", man1, t2);
                Model m2 = AddModel("Модель2", man2, t8);
                Model m3 = AddModel("Модель3", man3, t7);
                Model m4 = AddModel("Модель4", man4, t6);
                Model m5 = AddModel("Модель5", man5, t5);
                Model m6 = AddModel("Модель6", man6, t4);
                Model m7 = AddModel("Модель7", man7, t3);
                Model m8 = AddModel("Модель8", man8, t2);
                Model m9 = AddModel("Модель9", man1, t1);
                Model m10 = AddModel("Модель10", man2, t8);
                Model m11 = AddModel("Модель11", man3, t7);
                Model m12 = AddModel("Модель12", man6, t6);
                Model m13 = AddModel("Модель13", man7, t5);
                Model m14 = AddModel("Модель14", man8, t4);
                Model m15 = AddModel("Модель15", man1, t3);
                Model m16 = AddModel("Модель16", man2, t2);
                Model m17 = AddModel("Модель17", man3, t1);
                Model m18 = AddModel("Модель18", man4, t8);
                Model m19 = AddModel("Модель19", man5, t7);
                Model m20 = AddModel("Модель20", man6, t6);
                Model m21 = AddModel("Модель21", man7, t5);
                Model m22 = AddModel("Модель22", man8, t4);
                Model m23 = AddModel("Модель23", man1, t3);
                Model m24 = AddModel("Модель24", man2, t2);
                Model m25 = AddModel("Модель25", man3, t1);

                AddEquipment("Модель оборудования 1", m1);
                AddEquipment("Модель оборудования 2", m2);
                AddEquipment("Модель оборудования 3", m3);
                AddEquipment("Модель оборудования 4", m4);
                AddEquipment("Модель оборудования 5", m5);
                AddEquipment("Модель оборудования 6", m6);
                AddEquipment("Модель оборудования 7", m7);
                AddEquipment("Модель оборудования 8", m8);
                AddEquipment("Модель оборудования 9", m9);
                AddEquipment("Модель оборудования 10", m10);
                AddEquipment("Модель оборудования 11", m11);
                AddEquipment("Модель оборудования 12", m12);
                AddEquipment("Модель оборудования 1-2", m1);
                AddEquipment("Модель оборудования 2-2", m2);
                AddEquipment("Модель оборудования 3-2", m3);
                AddEquipment("Модель оборудования 4-2", m4);
                AddEquipment("Модель оборудования 5-2", m5);
                AddEquipment("Модель оборудования 6-2", m6);
                AddEquipment("Модель оборудования 7-2", m7);
                AddEquipment("Модель оборудования 8-2", m8);
                AddEquipment("Модель оборудования 9-2", m9);
                AddEquipment("Модель оборудования 10-2", m10);
                AddEquipment("Модель оборудования 11-2", m11);
                AddEquipment("Модель оборудования 12-3", m12);
                AddEquipment("Модель оборудования 1-3", m1);
                AddEquipment("Модель оборудования 2-3", m2);
                AddEquipment("Модель оборудования 3-3", m3);
                AddEquipment("Модель оборудования 4-3", m4);
                AddEquipment("Модель оборудования 5-3", m5);
                AddEquipment("Модель оборудования 6-3", m6);
                AddEquipment("Модель оборудования 7-3", m7);
                AddEquipment("Модель оборудования 8-3", m8);
                AddEquipment("Модель оборудования 9-3", m9);
                AddEquipment("Модель оборудования 10-3", m10);
                AddEquipment("Модель оборудования 11-3", m11);
                AddEquipment("Модель оборудования 12-3", m12);
            }
        }
    }
}
