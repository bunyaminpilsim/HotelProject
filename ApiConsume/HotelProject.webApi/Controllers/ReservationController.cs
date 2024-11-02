using HotelProject.BusunessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _reservationService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddReservation(Rezervation rezervation)
        {
            _reservationService.TInsert(rezervation);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var values = _reservationService.TGetById(id);
            _reservationService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateReservation(Rezervation rezervation)
        {
            _reservationService.TUpdate(rezervation);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var values = _reservationService.TGetById(id);
            return Ok(values);
        }
    }
}
