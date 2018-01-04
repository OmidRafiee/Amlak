using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alamut.Data.Linq;
using Alamut.Data.Paging;
using Alamut.Data.Structure;
using Alamut.Helpers.Linq;
using Amlak.Core.DTO.Detail;
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

        public ServiceResult<int> Create(HouseCreateViewModel model)
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

        public IPaginated<HouseViewModel> GetAll(SearchDTO vm)
        {
            var model = _context.House
                .WhereIf(vm.CategoryId != null, q => q.CategoryId.Equals(vm.CategoryId));

            return model.ProjectTo<HouseViewModel>().ToPaginated(new PaginatedCriteria(vm.Page, vm.PageSize));
        }

        

        public ServiceResult Update(HouseEditViewModel model)
        {
            var oldEntity = _context.House.FirstOrDefault(q => q.Id == model.Id);

            Mapper.Map(model, oldEntity);
            _context.SaveChanges();

            return ServiceResult<int>.Okay(model.Id);
        }

        public ServiceResult Delete(int id)
        {
            var model = _context.House.Find(id);

            _context.House.Remove(model);
            _context.SaveChanges();
            return ServiceResult.Okay("با موفقیت حذف شد");
        }

        public HouseViewModel GetById(int id)
        {
            var model = _context.House.Where(q => q.Id.Equals(id))
                .ProjectTo<HouseViewModel>().FirstOrDefault();

            return model;
        }
    }
}

