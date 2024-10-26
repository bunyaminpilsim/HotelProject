using AutoMapper;
using HotelProject.DTOLayer.DTO.RoomDTO;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.webApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDTO, Room>();
            CreateMap<Room, RoomAddDTO>();
            CreateMap<RoomUpdateDTO, Room>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();

        }
    }
}
