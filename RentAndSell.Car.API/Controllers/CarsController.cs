using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentAndSell.Car.API.Data;

namespace RentAndSell.Car.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static List<Car> cars = new List<Car>();

        private CarRentDbContext _dbContext;
        public CarsController(CarRentDbContext dbContext)
        {
            _dbContext =dbContext ;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(cars);
        }

        [HttpGet("{id}")]  //contollerdan  sonra, ana routedan sonra gelecek olan idyi söylüyor
        public ActionResult Get(int id)
        {
            return Ok(cars.Where(c => c.Id == id).SingleOrDefault());
        }

        [HttpPost]
        public ActionResult Post(Car car)
        {
            cars.Add(car);
            return Ok(cars);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Car car)
        {
            Car findOriginalCar = cars.Where(c => c.Id == id).SingleOrDefault();
            int findOriginalIndex = cars.IndexOf(findOriginalCar);

            cars[findOriginalIndex] = car;

            return Ok(cars);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Car removedCar = cars.SingleOrDefault(c => c.Id == id);

            cars.Remove(removedCar);

            return Ok(removedCar);
        }

        [HttpGet("Year/{year:range(1980,2024)}/Marka/{brand:alpha}")]
        public ActionResult Filter(int year, string brand)
        {
            return Ok($"{year} yılına ve {brand} markasına ait arabalar");
        }
        [HttpGet("Year/{year:range(1980,2024)}/Marka/{brand:alpha}/Model/{model}")]
        public ActionResult Filter(int year, string brand, string model)
        {
            return Ok($"{year} yılına ve {brand} {model} markasına ait arabalar");
        }
    }
}
