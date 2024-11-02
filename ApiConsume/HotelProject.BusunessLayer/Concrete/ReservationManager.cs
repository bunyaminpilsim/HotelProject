using HotelProject.BusunessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusunessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void TDelete(Rezervation t)
        {
            _reservationDal.Delete(t);
        }

        public Rezervation TGetById(int id)
        {
            return _reservationDal.GetById(id);
        }

        public List<Rezervation> TGetList()
        {
            return _reservationDal.GetList();
        }

        public void TInsert(Rezervation t)
        {
            _reservationDal.Insert(t);
        }

        public void TUpdate(Rezervation t)
        {
            _reservationDal.Update(t);
        }
    }
}
