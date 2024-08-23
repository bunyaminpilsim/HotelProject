using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DTOLayer.DTO.AppUserDTO
{
    public class AppUserWithWorkLocationDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string WorkLocationName { get; set; }
        public int WorkLocationID { get; set; }
    }
}
