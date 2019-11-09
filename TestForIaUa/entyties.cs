// entyties

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestForIaUa
{
    public class Equipment
    {
        [Key]       // можно и не указывать
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
            // внешний ключ
        public Model ModelId { get; set; }
        public Model Model { get; set; }
    }

    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
            // внешний ключ
        public Manufacturer ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
            // внешний ключ
        public Type TypeId { get; set; }
        public Type Type { get; set; }
    }

    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
    }

    public class Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
    }

    public class Repair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public System.DateTime DateTime { get; set; }
        [MaxLength(30)]
        public string Description { get; set; }         // детали ремонта
            // внешний ключ
        public Equipment EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}