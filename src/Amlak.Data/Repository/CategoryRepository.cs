using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alamut.Data.Structure;
using Amlak.Core.Entities;
using Amlak.Core.ViewModel.Category;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Amlak.Data.Repository
{
   public class CategoryRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region Constructor

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD
        public ServiceResult<int> Create(CategoryViewModel model)
        {
            var entity = Mapper.Map<Category>(model);
            _context.Category.Add(entity);
            _context.SaveChanges();
            return ServiceResult<int>.Okay(entity.Id);
        }

        public List<CategoryViewModel> GetAll()
        {
            return _context.Category.ProjectTo<CategoryViewModel>().OrderBy(q => q.Title).ToList();
        }



        public ServiceResult<int> Update(CategoryViewModel model)
        {
            var oldEntity = _context.Category.FirstOrDefault(q => q.Id == model.Id);
            Mapper.Map(model, oldEntity);
            _context.SaveChanges();
            var result = ServiceResult<int>.Okay(model.Id);
            return result;
        }
        public ServiceResult Delete(int id)
        {
            var model = _context.Category.Find(id);
            _context.Category.Remove(model);
            _context.SaveChanges();
            return ServiceResult.Okay("با موفقیت حذف شد");
        }
        #endregion

        #region Methods
        public CategoryViewModel GetById(int id)
        {
            return _context.Category.Where(q => q.Id.Equals(id)).ProjectTo<CategoryViewModel>().FirstOrDefault();
        }
     
        #endregion
    }
}
