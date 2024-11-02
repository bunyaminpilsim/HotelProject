namespace HotelProject.WebUI.DTOs.RoomDTO
{
    public class ResultRoomDTO
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Yeni özellikler
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string CheckInTime { get; set; } // Örneğin, "14:00" formatında olabilir
        public string CheckOutTime { get; set; } // Örneğin, "12:00" formatında olabilir
    }

}
