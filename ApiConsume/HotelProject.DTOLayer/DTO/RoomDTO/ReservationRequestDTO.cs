namespace HotelProject.WebUI.DTOs.RoomDTO
{
    public class ReservationRequestDTO
    {
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
