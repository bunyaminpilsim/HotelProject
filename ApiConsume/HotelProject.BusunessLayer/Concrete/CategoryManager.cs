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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryService;

        public CategoryManager(ICategoryDal categoryService)
        {
            _categoryService = categoryService;
        }

        public void TDelete(Category t)
        {
            _categoryService.Delete(t);
        }

        public Category TGetById(int id)
        {
            return _categoryService.GetById(id);
        }

        public List<Category> TGetList()
        {
            return _categoryService.GetList();
        }

        public void TInsert(Category t)
        {
            _categoryService.Insert(t);
        }

        public void TUpdate(Category t)
        {
           _categoryService.Update(t);
        }
    }
}
