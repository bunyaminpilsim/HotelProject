using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.ServiceDTO
{
    public class UpdateServiceDTO
    {
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Hizmet İkon Linki Giriniz")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı Giriniz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet Açıklaması Giriniz")]
        public string Description { get; set; }
    }
}
