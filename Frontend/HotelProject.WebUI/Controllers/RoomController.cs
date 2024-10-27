using HotelProject.WebUI.DTOs.RoomDTO;
using HotelProject.WebUI.ViewComponents.Default;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelProject.WebUI.Controllers
{
    public class RoomController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public RoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FilterRooms(string? categoryName, string? description)
        {
            var client = _httpClientFactory.CreateClient();
            string url = $"http://localhost:5209/api/Room2/FilterRooms?categoryName={categoryName}&description={description}";

            var responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDTO>>(jsonData);
                return Json(values); 
            }
            return Json(new List<ResultRoomDTO>());
        }
    }
}
