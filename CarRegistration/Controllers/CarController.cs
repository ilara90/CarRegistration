using CarRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRegistration.Controllers
{
    public class CarController : Controller
    {
        ICarRepository repo;
        public CarController(ICarRepository r)
        {
            repo = r;
        }

        [HttpGet("/cars")]
        public IActionResult Index()
        {
            List<Car> cars = repo.GetCars();
            return Ok(cars);
        }

        [HttpGet("/car/{id}")]
        public ActionResult Details(int id)
        {
            Car car = repo.Get(id);
            if (car != null)
                return Ok(car);

            return BadRequest();
        }

        [HttpGet("/cars_filter")]
        public ActionResult Filter (int from, int to)
        {
            List<Car> cars = repo.Filter(from, to);
            if (cars != null)
                return Ok(cars);

            return BadRequest();
        }

        [HttpPost("/car_create")]
        public ActionResult Create(Car car)
        {
            repo.Create(car);
            return Ok(car);
        }

        [HttpPut("/car_edit/{id}")]
        public ActionResult Edit(int id, Car car)
        {
            Car carEdit = repo.Get(id);
            if (carEdit == null)
            {
                return BadRequest();
            }

            carEdit.Model = car.Model;
            carEdit.RegistrationNumber = car.RegistrationNumber;
            carEdit.UserId = car.UserId;

            repo.Update(carEdit);
            return Ok(car);
        }

        [HttpDelete("/car_delete/{id}")]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return Ok();
        }
    }
}
