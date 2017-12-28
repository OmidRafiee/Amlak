using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alamut.Data.Structure;
using Amlak.Core.Entities;
using Amlak.Core.ViewModel.Option;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Amlak.Data.Repository
{
    public class OptionRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region Constructor

        public OptionRepository(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD
        public ServiceResult<int> Create(OptionViewModel model)
        {
            var entity = Mapper.Map<Option>(model);
            _context.Option.Add(entity);
            _context.SaveChanges();
            return ServiceResult<int>.Okay(entity.Id);
        }

        public List<OptionViewModel> GetAll()
        {
            return _context.Option.ProjectTo<OptionViewModel>().OrderBy(q => q.Title).ToList();
        }



        public ServiceResult<int> Update(OptionViewModel model)
        {
            var oldEntity = _context.Option.FirstOrDefault(q => q.Id == model.Id);
            Mapper.Map(model, oldEntity);
            _context.SaveChanges();
            var result = ServiceResult<int>.Okay(model.Id);
            return result;
        }
        public ServiceResult Delete(int id)
        {
            var model = _context.Option.Find(id);
            _context.Option.Remove(model);
            _context.SaveChanges();
            return ServiceResult.Okay("با موفقیت حذف شد");
        }
        #endregion

        #region Methods
        public OptionViewModel GetById(int id)
        {
            return _context.Option.Where(q => q.Id.Equals(id)).ProjectTo<OptionViewModel>().FirstOrDefault();
        }

        #endregion
    }
}
