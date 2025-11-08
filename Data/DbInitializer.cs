using GreenHouse.Models;

namespace GreenHouse.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Plants.Any())
            {
                return;
            }

            var plants = new Plant[]
            {
                new Plant { PlantName = "Rosa", SensorValue = 23.5f },
                new Plant { PlantName = "Orquídea", SensorValue = 18.2f },
                new Plant { PlantName = "Girassol", SensorValue = 30.1f },
                new Plant { PlantName = "Lírio", SensorValue = 15.7f },
                new Plant { PlantName = "Violeta", SensorValue = 20.0f }
            };
            foreach (Plant p in plants)
            {
                context.Plants.Add(p);
            }
            context.SaveChanges();
        }
    }
}