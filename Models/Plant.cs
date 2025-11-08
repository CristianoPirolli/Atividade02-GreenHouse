using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouse.Models
{
    [Table("PLANTS")]
    public class Plant
    {
        [Key]
        [Required]
        [Column("PLANT_NAME", TypeName = "char(30)")]
        public required string PlantName { get; set; }

        [Column("SENSOR_VALUE")]
        public float SensorValue { get; set; }

        [Column("SENSOR_EVENT")]
        public DateTime SensorEvent { get; set; } = DateTime.Now;
    }
}
