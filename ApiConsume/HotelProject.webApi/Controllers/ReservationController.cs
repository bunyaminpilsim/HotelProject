using HotelProject.BusunessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.RoomDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ICustomerService _customerService;

        public ReservationController(IReservationService reservationService, ICustomerService customerService)
        {
            _reservationService = reservationService;
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _reservationService.TGetList();
            return Ok(values);
        }
       
        [HttpPost]
        public IActionResult AddReservation(ReservationRequestDTO reservationRequestDTO)
        {

            var customer = new Customer
            {
                Mail = reservationRequestDTO.Mail,
                Name = reservationRequestDTO.Name,
                Surname = reservationRequestDTO.Surname,
                Phone = reservationRequestDTO.Phone
            };

            customer = _customerService.AddCustomer(customer);

            var rezervation = new Rezervation
            {
                CreateTime = DateTime.Now,
                CreateUser = "armut",
                CustomerId = customer.Id,
                ReservationEndDate = reservationRequestDTO.CheckInDate,
                ReservationEndTime = TimeSpan.Parse(reservationRequestDTO.CheckInTime),
                ReservationStartDate = reservationRequestDTO.CheckOutDate,
                ReservationStartTime = TimeSpan.Parse(reservationRequestDTO.CheckOutTime),
                RoomId = reservationRequestDTO.RoomId,
                Status = "A",
                UpdateTime = DateTime.Now,
                UpdateUser = "A",
            };

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
