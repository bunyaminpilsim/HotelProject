using HotelProject.WebUI.DTOs.AppUserDTO;
using HotelProject.WebUI.DTOs.ContactDTO;
using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminMailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5209/api/Contact");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonData2);
            List<SelectListItem> values3 = (from x in values2
                                            select new SelectListItem
                                            {
                                                Text = x.Mail,
                                                Value = x.Mail.ToString()
                                            }).ToList();
            ViewBag.user = values3;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AdminMailViewModel model)
        {
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5209/api/Contact");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            
            //ViewBag.user = values2.Mail;
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "bunyaminpilsim@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("bunyaminpilsim@gmail.com", "qnpjcrsepyrmlrpf");
            client.Send(mimeMessage);
            client.Disconnect(true);

            //Gönderilen Mailin Veri Tabanına Kaydedilmesi.
          

            return RedirectToAction("Index");
        }
    }
}
