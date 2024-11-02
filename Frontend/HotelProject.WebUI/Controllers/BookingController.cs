using HotelProject.WebUI.DTOs.BookingDTO;
using HotelProject.WebUI.DTOs.RoomDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int roomId)
        {
            var client = _httpClientFactory.CreateClient();
            string url = $"http://localhost:5209/api/Room/{roomId}";

            var responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultRoomDTO>(jsonData);
                return View(values);
            }        

            return View(new List<ResultRoomDTO>());
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDTO createBookingDto)
        {
            createBookingDto.Status = "Onay Bekliyor";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5209/api/Boooking", stringContent);
            return RedirectToAction("Index", "Default");
        }

        [HttpPost]
        public void ReserveRoom(int roomId, DateTime checkInDate, DateTime checkOutDate, string checkInTime, string checkOutTime)
        {
            //// CreateBookingDTO nesnesi oluştur
            //var createBookingDto = new Rezer
            //{
            //    RoomId = roomId,
            //    CheckInDate = checkInDate,
            //    CheckOutDate = checkOutDate,
            //    CheckInTime = checkInTime,
            //    CheckOutTime = checkOutTime,
            //    Status = "Onay Bekliyor"
            //};

            // Booking işlemini yap
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createBookingDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //await client.PostAsync("http://localhost:5209/api/Booking", stringContent);

            //// Başarılı bir rezervasyon sonrası yönlendirme
            //return RedirectToAction("Index", new { roomId });
        }

    }
}
