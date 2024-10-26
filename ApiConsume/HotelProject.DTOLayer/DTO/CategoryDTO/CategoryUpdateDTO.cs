﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DTOLayer.DTO.CategoryDTO
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
