using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alamut.Data.Structure;
using Amlak.Core.Entities;
using Amlak.Core.ViewModel.News;
using Amlak.Core.ViewModel.Pages;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Calabin.Core.DTO.Pages;

namespace Amlak.Data.Repository
{
    public class NewsRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region Constructor
        public NewsRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CRUD
        public ServiceResult<int> Create(NewsViewModel model)
        {
            var entity = Mapper.Map<News>(model);
            _context.News.Add(entity);
            _context.SaveChanges();
            var result = ServiceResult<int>.Okay(entity.Id);
            return result;
        }

        public List<NewsViewModel> GetAll()
        {
            return _context.News
                .OrderBy(q => q.Title)
                .ProjectTo<NewsViewModel>()
                .ToList();
        }
        public ServiceResult<int> Update(NewsViewModel model)
        {
            var oldEntity = _context.News.FirstOrDefault(q => q.Id == model.Id);
            Mapper.Map(model, oldEntity);
            _context.SaveChanges();
            var result = ServiceResult<int>.Okay(model.Id);
            return result;
        }

        public ServiceResult<int> DeleteById(int id)
        {
            var model = new News { Id = id };
            _context.News.Remove(model);
            var result = _context.SaveChanges();
            return ServiceResult<int>.Okay(id);
        }


        #endregion

        #region Methods
        public NewsViewModel GetById(int id)
        {
            return _context.Pages.Where(q => q.Id == id).ProjectTo<NewsViewModel>().FirstOrDefault();
        }

        #endregion
    }
}
