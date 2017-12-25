using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alamut.Data.Structure;
using Amlak.Core.Entities;
using Amlak.Core.ViewModel;
using Amlak.Core.ViewModel.House;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Amlak.Data.Repository
{
    public class HouseRepository
    {
        private readonly AppDbContext _context;

        public HouseRepository(AppDbContext context)
        {
            _context = context;
        }

        public ServiceResult<int> Create(CreateHouseViewModel model)
        {
            var entity = Mapper.Map<House>(model);

            _context.House.Add(entity);
            _context.SaveChanges();
            return ServiceResult<int>.Okay(entity.Id);
        }


        public List<HouseViewModel> GetAll()
        {
            return _context.House.ProjectTo<HouseViewModel>().ToList();
        }

        public ServiceResult Update(HouseViewModel model)
        {
            var oldEntity = _context.House.FirstOrDefault(q => q.Id == model.Id);
            Mapper.Map(model, oldEntity);
            _context.SaveChanges();
            var result = ServiceResult<int>.Okay(model.Id);
            return result;
        }

        public ServiceResult Delete(int id)
        {
            var model = _context.House.Find(id);

            _context.House.Remove(model);
            _context.SaveChanges();
            return ServiceResult.Okay("با موفقیت حذف شد");
        }

    }
}
