using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alamut.Data.Structure;
using Amlak.Core.DTO.News;
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

        public List<NewsDTO> GetAll()
        {
            return _context.News
                .OrderBy(q => q.Title)
                .ProjectTo<NewsDTO>()
                .ToList();
        }


        public List<NewsDTO> GetAllIsPblished()
        {
            return _context.News
                .Where(q=>q.IsPublished)
                .OrderBy(q => q.Title)
                .ProjectTo<NewsDTO>()
                .ToList();
        }

        public ServiceResult<int> Update(NewsDTO model)
        {
            var oldEntity = _context.News.FirstOrDefault(q => q.Id == model.Id);
            Mapper.Map(model, oldEntity);
            _context.SaveChanges();
            var result = ServiceResult<int>.Okay(model.Id);
            return result;
        }

        public ServiceResult<int> Delete(int id)
        {
            var model = new News { Id = id };
            _context.News.Remove(model);
            var result = _context.SaveChanges();
            return ServiceResult<int>.Okay(id);
        }


        #endregion

        #region Methods
        public NewsDTO GetById(int id)
        {
            return _context.Pages.Where(q => q.Id == id).ProjectTo<NewsDTO>().FirstOrDefault();
        }

        #endregion

        public ServiceResult<bool> SetIsPublished(int id, bool status)
        {
            var entity = _context.News.Find(id);

            if (entity == null)
                return ServiceResult<bool>.Error("رکوردی یافت نشد");

            entity.IsPublished = status;
            _context.News.Update(entity);
            _context.SaveChanges();

            return ServiceResult<bool>.Okay(status);
        }
    }
}
