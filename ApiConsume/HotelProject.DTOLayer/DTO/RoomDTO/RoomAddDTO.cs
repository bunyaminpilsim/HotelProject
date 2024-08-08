﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DTOLayer.DTO.RoomDTO
{
    public class RoomAddDTO
    {
        [Required(ErrorMessage ="Lütfen Oda Numarasını Giriniz")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage ="Lütfen Fiyat Bilgisi Giriniz")]
        public int Price { get; set; }

        [Required(ErrorMessage ="Lütfen Oda Başlığı Giriniz")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Lütfen Yatak Sayısını Giriniz")]
        public string BedCount { get; set; }

        [Required(ErrorMessage ="Lütfen Banyo Sayısı Giriniz")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
