using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.ServiceDTO
{
    public class CreateServiceDTO
    {
        [Required(ErrorMessage = "Hizmet İkon Linki Giriniz")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı Giriniz")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
