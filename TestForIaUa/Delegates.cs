namespace TestForIaUa
{
    public delegate void AddEquipmentDeleg(Equipment eq);       // добавление нового оборудования
    public delegate void AddModelDeleg();                       // добавление новой модели оборудования
    public delegate void AddManufacturerDeleg();                // добавление нового производителя
    public delegate void AddTypeDeleg();                        // добавление нового типа оборудования
    public delegate void FilterByTypeDeleg(Type type);          // фильтр по типу оборудования
    public delegate void FilterByManufacturerDeleg(Manufacturer m);       // фильтр по производителю оборудования
    public delegate void EquipmentRedactedDeleg();                     // отредактировано оборудование
}