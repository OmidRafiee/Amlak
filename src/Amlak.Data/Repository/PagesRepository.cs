using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alamut.Data.Structure;
using Amlak.Core.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Calabin.Core.DTO.Pages;
using Calabin.Core.ViewModel.Pages;

namespace Amlak.Data.Repository
{
    public class PagesRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region Constructor
        public PagesRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CRUD
        public ServiceResult<int> CreatePages(PagesViewModel model)
        {
            var entity = Mapper.Map<Pages>(model);
            _context.Pages.Add(entity);
            _context.SaveChanges();
            var result = ServiceResult<int>.Okay(entity.Id);
            return result;
        }

        public List<PagesSummary> GetAllPages()
        {
            return _context.Pages
                .OrderBy(q => q.Title)
                .ProjectTo<PagesSummary>()
                .ToList();
        }
        public ServiceResult<int> UpdatePagesById(PagesViewModel model)
        {
            var oldEntity = _context.Pages.FirstOrDefault(q => q.Id == model.Id);
            Mapper.Map(model, oldEntity);
            _context.SaveChanges();
            var result = ServiceResult<int>.Okay(model.Id);
            return result;
        }

        public ServiceResult<int> DeletePagesById(int id)
        {
            var model = new Pages { Id = id };
            _context.Pages.Remove(model);
            var result = _context.SaveChanges();
            return ServiceResult<int>.Okay(id);
        }


        #endregion

        #region Methods
        public Pages GetPagesById(int id)
        {
            return _context.Pages.FirstOrDefault(q => q.Id == id);
        }



        public List<Pages> GetPagessByIds(List<int> ids)
        {
            return _context.Pages
                .Where(q => ids.Contains(q.Id))
                .ToList();
        }

        public Pages GetPagesByBasename(string basename)
        {
            return _context.Pages.FirstOrDefault(q => q.Basename == basename);
        }
        #endregion
    }
}
