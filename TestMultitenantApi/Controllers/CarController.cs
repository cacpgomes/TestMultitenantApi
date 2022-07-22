using System;
using Microsoft.AspNetCore.Mvc;
using TestMultitenantApi.Data;
using TestMultitenantApi.Model;

namespace TestMultitenantApi.Controllers
{
    [ApiController]
    [Route("{__tenant__=}/[controller]")]
    public class CarController: ControllerBase
    {
        private readonly CarContext _carContext;
        public CarController(CarContext carContext)
        {
            _carContext = carContext;
        }

        [HttpGet]
        public ActionResult<IList<Car>> Get()
        {
            var cars = _carContext.Cars.ToList();

            return Ok(cars);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post(string brand)
        {
            var entry = _carContext.Cars.Add(new Model.Car { Brand = brand });
            await _carContext.SaveChangesAsync();
            
            return Ok(entry.Entity);
        }
    }
}

