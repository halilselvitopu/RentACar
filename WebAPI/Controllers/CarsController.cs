using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetCarById(int id)
        {

            var result = _carService.GetById(id);
            if (result.Success == true)
            {

                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult UpdateCar(Car car)
        {
            var result = (_carService.Update(car));
            if (result.Success)
            {
                 _carService.Update(car);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(Car car)
        {
            var result = (_carService.Delete(car));

            if (result.Success)
            {
                _carService.Delete(car);
                return Ok(result);
            }
            
                return BadRequest(result);
            }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                _carService.GetCarDetails();
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetCarByBrandId(Car car)
        {
            var result = (_carService.Update(car));
            if (result.Success)
            {
                _carService.Update(car);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycolourid")]
        public IActionResult GetCarsByColourId(int id)
        {
            var result = (_carService.GetCarsByColourId(id));
            if (result.Success)
            {
                _carService.GetCarsByColourId(id);
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
    }

