using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouse.Models
{
    [Table("PLANTS")] // Mapeia para a tabela do banco
    public class Plant
    {
        [Key]
        [Column("PLANT_NAME", TypeName = "char(30)")]
        public string PlantName { get; set; }

        [Column("SENSOR_VALUE")]
        public float SensorValue { get; set; }

        [Column("SENSOR_EVENT")]
        public DateTime SensorEvent { get; set; } = DateTime.Now;
    }
}
