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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _costumerDal;

        public CustomerManager(ICustomerDal costumerDal)
        {
            _costumerDal = costumerDal;
        }

        public Customer AddCustomer(Customer c)
        {
           return _costumerDal.InsertRretunData(c);
        }

        public void TDelete(Customer t)
        {
            _costumerDal.Delete(t);
        }

        public Customer TGetById(int id)
        {
            return _costumerDal.GetById(id);
        }

        public List<Customer> TGetList()
        {
            return _costumerDal.GetList();
        }

        public void TInsert(Customer t)
        {
            _costumerDal.Insert(t);
        }

        public void TUpdate(Customer t)
        {
            _costumerDal.Update(t);
        }
    }
}
