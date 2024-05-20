using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Renteal_Car.Data;
using Renteal_Car.Models;

namespace Renteal_Car.Controllers
{
    public class CarController : Controller
    {
        private RentalCarContext context;

        public CarController(RentalCarContext cx)
        {
            context = cx; 
        }
        public IActionResult Index()
        {
            var iteam =context.Cars.ToList();
            return View(iteam);
        }

        public IActionResult New()
        {

            return View();

        }


        public async Task<IActionResult> State(int? id)
        {
            
                if (id == null || context.Cars == null)
                {
                    return NotFound();
                }

                var carstate =await context.Cars.FirstOrDefaultAsync(m => m.CarId == id);
                if (carstate == null)
                {
                    return NotFound();
                }

                return View(carstate);
            

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id ==0) 
            {
                return NotFound();

            }
            var cars = context.Cars.Find(id);
            if (cars == null)
            {
                return NotFound();

            }

            return View(cars);
        }

        [HttpPost]
        public IActionResult New(Car NewCar)
    
        {
            if (ModelState.IsValid) {
                context.Cars.Add(NewCar);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View(NewCar);
               
            }
        }


        public IActionResult SportCar()
        {
            var cars = context.Cars.ToList();
            return View(cars);
        }

        [HttpPost]
        public IActionResult Edit(Car cars)
        {
            if (ModelState.IsValid)
            {
                context.Cars.Update(cars);
                context.SaveChanges();
                return RedirectToAction("index");
                
            }
            return View(cars) ;
        }

    }
}
