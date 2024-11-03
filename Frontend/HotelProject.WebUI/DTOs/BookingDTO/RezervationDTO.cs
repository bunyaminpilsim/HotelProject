using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.DTOs.BookingDTO
{
    public class RezervationDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public TimeSpan ReservationStartTime { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public TimeSpan ReservationEndTime { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string? UpdateUser { get; set; }
    }
}
