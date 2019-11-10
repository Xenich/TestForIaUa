namespace TestForIaUa
{
    public delegate void AddEquipmentDeleg(Equipment eq);       // добавление нового оборудования
    public delegate void FilterByTypeDeleg(Type type);          // фильтр по типу оборудования
    public delegate void FilterByManufacturerDeleg(Manufacturer manufacturer);       // фильтр по производителю оборудования
}