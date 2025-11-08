using GreenHouse.Models;

namespace GreenHouse.Interface
{
    public interface IPlantaRepository
    {
        Task<List<Plant>> GetAll();
        Task<Plant?> GetById(string plantName);
        Task Create(Plant plant);
        Task Update(Plant plant);
        Task Delete(string plantName);
    }
}
