﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alamut.Data.Linq;
using Alamut.Data.Paging;
using Alamut.Data.Structure;
using Alamut.Helpers.Linq;
using Amlak.Core.DTO.Detail;
using Amlak.Core.DTO.House;
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
                .WhereIf(!string.IsNullOrEmpty(vm.Area), q => q.Area.Contains(vm.Area))
                .WhereIf(!string.IsNullOrEmpty(vm.Region), q => q.Region.Contains(vm.Region))
                .WhereIf(!string.IsNullOrEmpty(vm.Town), q => q.Town.Contains(vm.Town))
                .WhereIf(!string.IsNullOrEmpty(vm.Status), q => q.Status.Contains(vm.Status))

                .WhereIf(vm.MaxScale !=0 , q => q.Scale <= vm.MaxScale)
                .WhereIf(vm.MinScale != 0, q => q.Scale >= vm.MinScale)

                .WhereIf(vm.MaxPrice != 0, q => q.Price <= vm.MaxPrice)
                .WhereIf(vm.MinPrice != 0, q => q.Price >= vm.MinPrice)

                .WhereIf(vm.MaxMeterPrice != 0, q => q.MeterPriceComputed <= vm.MaxMeterPrice)
                .WhereIf(vm.MinMeterPrice != 0, q => q.MeterPriceComputed >= vm.MinMeterPrice)

                .WhereIf(vm.Bathrooms != 0, q => q.Bathrooms.Equals(vm.Bathrooms))
                .WhereIf(vm.Rooms != 0, q => q.Rooms.Equals(vm.Rooms))

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

        public HouseFullDTO GetById(int id)
        {
            var model = _context.House.Where(q => q.Id.Equals(id))
                .ProjectTo<HouseFullDTO>().FirstOrDefault();

            return model;
        }

        public List<HouseFullDTO> GetSpeialOffer(int count)
        {

            var model = _context.House.Where(q => q.IsPublished
                                             && q.IsSpecialOffer)
                .OrderByDescending(q => q.PublishDate)
                .Take(count)
                .ProjectTo<HouseFullDTO>().ToList();

            return model;
        }


        public List<HouseViewModel> GetListRequestByUserId(int userId)
        {
            return _context.House.ProjectTo<HouseViewModel>()
                .Where(q => q.IsPublished == false)
                .Where(q => q.UserId.Equals(userId))
                .ToList();
        }
    }
}

