using Microsoft.AspNetCore.Mvc;
using GreenHouse.Interface;
using GreenHouse.Models;

namespace GreenHouse.Controller
{
    public class PlantaController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IPlantaRepository _plantaRepository;

        public PlantaController(IPlantaRepository plantaRepository)
        {
            _plantaRepository = plantaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var plantas = await _plantaRepository.GetAll();
            return View(plantas);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _plantaRepository.GetById(id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantName,SensorValue,SensorEvent")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                await _plantaRepository.Create(plant);
                return RedirectToAction(nameof(Index));
            }
            return View(plant);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _plantaRepository.GetById(id);
            if (plant == null)
            {
                return NotFound();
            }
            return View(plant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlantName,SensorValue,SensorEvent")] Plant plant)
        {
            if (id != plant.PlantName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _plantaRepository.Update(plant);
                return RedirectToAction(nameof(Index));
            }
            return View(plant);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _plantaRepository.GetById(id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _plantaRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
