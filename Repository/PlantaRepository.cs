using GreenHouse.Data;
using GreenHouse.Interface;
using GreenHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenHouse.Repository
{
    public class PlantaRepository : IPlantaRepository
    {
        private readonly AppDbContext _context;

        public PlantaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Plant plant)
        {
            await _context.Plants.AddAsync(plant);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string plantName)
        {
            var plant = await _context.Plants.FindAsync(plantName);
            if (plant != null)
            {
                _context.Plants.Remove(plant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Plant>> GetAll()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<Plant?> GetById(string plantName)
        {
            return await _context.Plants.Where(p => p.PlantName == plantName).FirstOrDefaultAsync();
        }

        public async Task Update(Plant plant)
        {
            try
            {
                _context.Entry(plant).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PlantExists(plant.PlantName))
                {
                    throw new Exception("Planta não encontrada.");
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task<bool> PlantExists(string plantName)
        {
            return await _context.Plants.AnyAsync(e => e.PlantName == plantName);
        }
    }
}