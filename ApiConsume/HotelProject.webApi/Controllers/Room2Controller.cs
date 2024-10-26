using AutoMapper;
using HotelProject.BusunessLayer.Abstract;
using HotelProject.DTOLayer.DTO.RoomDTO;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelProject.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomService, IMapper mapper, ICategoryService categoryService)
        {
            _roomService = roomService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult Index()
        {
            var values = _roomService.TGetList();
            var roomList = _mapper.Map<List<RoomDTO>>(values);

            
           foreach (var room in roomList) {
                room.CategoryName = _categoryService.TGetById(room.CategoryId).Name;
            }


            return Ok(roomList);
        }

        [HttpPost]
        public IActionResult AddRoom(RoomAddDTO roomAddDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values=_mapper.Map<Room>(roomAddDTO);
           _roomService.TInsert(values);
            return Ok();

        }
        [HttpPut]
        public IActionResult UpdateRoom(RoomUpdateDTO roomUpdateDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values=_mapper.Map<Room>(roomUpdateDTO);
            _roomService.TUpdate(values);
            return Ok();
        }
    }
}
