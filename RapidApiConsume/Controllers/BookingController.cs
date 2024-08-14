using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?checkout_date=2024-09-15&order_by=popularity&filter_by_currency=EUR&include_adjacency=true&children_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&room_number=1&dest_id=-1456928&dest_type=city&adults_number=2&page_number=0&checkin_date=2024-09-14&locale=en-gb&units=metric&children_ages=5%2C0"),
                Headers =
    {
        { "x-rapidapi-key", "32c5620181msh758ea7c0a39a9e9p14664cjsnbb8eb41e8515" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                return View(values.result.ToList());
            }
        }
    }
}
