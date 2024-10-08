﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EnitityFramework
{
    public class EfTestimonial : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonial(Context context) : base(context)
        {
        }
    }
}
