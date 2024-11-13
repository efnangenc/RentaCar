using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAndSell.Car.API.Data;
using RentAndSell.Car.API.Data.Entities.Concrete;

namespace RentAndSell.Car.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static List<Araba> cars = new List<Araba>();
        private CarRentDbContext _dbContext;
        private IQueryable<Araba> _activeAndNotDeletedCars;
        public CarsController(CarRentDbContext dbContext)
        {
            _dbContext = dbContext;
            _activeAndNotDeletedCars = _dbContext.Arabalar.Where(a => a.IsActive == true && a.IsDeleted == false);
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_activeAndNotDeletedCars.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_activeAndNotDeletedCars.Where(a=>a.Id == id).SingleOrDefault());
        }

        [HttpPost]
        public ActionResult Post(Araba car)
        {
            //ArabaTarihce arabaTarihce = new ArabaTarihce();
            //arabaTarihce.Marka = car.Marka;
            //arabaTarihce.Model = car.Model;
            //arabaTarihce.Yili = car.Yili;
            //arabaTarihce.YakitTuru = car.YakitTuru;
            //arabaTarihce.SanzimanTipi = car.SanzimanTipi;
            //arabaTarihce.MotorTipi = car.MotorTipi;
            //arabaTarihce.IsActive = car.IsActive;
            //arabaTarihce.IsDeleted = car.IsDeleted;
            //arabaTarihce.IslemTipi = IslemTipi.Inserted;
            //arabaTarihce.IslemZamani = DateTime.Now;

            //_dbContext.ArabaTarihcesi.Add(arabaTarihce);  //insert işlmi yapar ama biz triggger yaptık her seferinde bu bloğu yazmamamk için

            _dbContext.Arabalar.Add(car);
            _dbContext.SaveChanges();

            return Ok($"Kayıt başarıyla yapıldı. Kayıt no: {car.Id}");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Araba car)
        {
        //    Araba? readAraba = _activeAndNotDeletedCars.AsNoTracking()
        //                                         .Where(a => a.Id == id)
        //                                         .SingleOrDefault();


            Araba? readAraba = _activeAndNotDeletedCars
                                                 .Where(a => a.Id == id)
                                                 .SingleOrDefault();


            if (readAraba != null)
            {
                readAraba.Marka = car.Marka;
                readAraba.Model = car.Model;
                readAraba.Yili= car.Yili;
                readAraba.MotorTipi = car.MotorTipi;
                readAraba.YakitTuru = car.YakitTuru;
                readAraba.SanzimanTipi = car.SanzimanTipi;
                readAraba.Update = DateTime.Now;

                //_dbContext.Arabalar.Update(readAraba);  //referans tip olduğğundan update demeden de update yaptırabilriim o adresini biliyo. bu yüzden asnotracking de ihtiyaçtan kalktı
                _dbContext.SaveChanges();
                return NoContent();
            }

            return StatusCode(503, "Güncelleme İşlemi yapılamadı");

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Araba? readAraba = _activeAndNotDeletedCars.AsNoTracking()
                                                 .Where(a => a.Id == id)
                                                 .SingleOrDefault();

            if (readAraba != null)
            {
                _dbContext.Arabalar.Remove(readAraba);
                _dbContext.SaveChanges();
                return NoContent();
            }

            return StatusCode(503, "Silme İşlemi yapılamadı");
        }


        [HttpGet("Year/{year:range(1980,2024)}")]
        public ActionResult Filter(int year)
        {
            return Ok(_activeAndNotDeletedCars.AsNoTracking().Where(a=>a.Yili==year).ToList());
        }

        [HttpGet("Year/{year:range(1980,2024)}/Markasi/{brand:alpha}")]
        public ActionResult Filter(int year, string brand)
        {
            return Ok(_activeAndNotDeletedCars.AsNoTracking().Where(a => a.Yili == year && a.Marka == brand).ToList());
        }

        [HttpGet("Year/{year:range(1980,2024)}/Markasi/{brand:alpha}/Modeli/{model}")]
        public ActionResult Filter(int year, string brand, string model)
        {
            return Ok(_activeAndNotDeletedCars.AsNoTracking().Where(a => a.Yili == year && a.Marka == brand && a.Model == model).ToList());
        }
    }
}
