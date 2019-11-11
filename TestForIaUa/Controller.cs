using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestForIaUa
{
    static class Controller
    {
        public static event AddManufacturerDeleg addManufacturerEvent;      // событие - добавлен производитель
        public static event AddTypeDeleg addTypeEvent;                      // событие - добавлен тип оборудования
        public static event AddModelDeleg addModelEvent;                    // событие - добавлена новая модель оборудования
        public static event AddEquipmentDeleg EquipmentAddedEvent;          // событие - добавление нового оборудования
        public static event EquipmentRedactedDeleg EquipmentRedactedEvent;  // событие - отредактировано оборудование

            // добавление нового производителя
        public static void AddManufacturer(string name)
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
                    addManufacturerEvent(m);
            }
        }

            // добавление нового типа оборудования
        public static void AddType(string name)
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
                    addTypeEvent(t);
                MessageBox.Show("Новый тип оборудования добавлен");
            }
        }

            // добавление нового оборудования
        public static void AddEquipment(string description, Model model)
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
        public static void AddModel(string name, Manufacturer manuf, Type typ)
        {
            using (OfficeContext db = new OfficeContext())
            {
                Model m = new Model();
                m.Name = name;
                db.Manufacturers.Attach(manuf);
                db.Types.Attach(typ);
                m.Manufacturer = manuf;
                m.Type = typ;
                db.Models.Add(m);
                db.SaveChanges();
                if (addModelEvent != null)
                    addModelEvent(m);
            }
        }
            
            // редактирование оборудования
        public static void RedactEquipment(int id, string description, Model model)
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
    }
}
