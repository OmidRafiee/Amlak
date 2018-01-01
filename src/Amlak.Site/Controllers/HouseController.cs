﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Core.ViewModel.House;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Amlak.Site.Controllers
{
   public class HouseController : Controller
   {
       private readonly HouseRepository _houseRepository;
       private readonly OptionRepository _optionRepository;
       private readonly CategoryRepository _categoryRepository;



       public HouseController(HouseRepository houseRepository, OptionRepository optionRepository, CategoryRepository categoryRepository)
        {
            _houseRepository = houseRepository;
            _optionRepository = optionRepository;
            _categoryRepository = categoryRepository;
        }

       public IActionResult Index()
        {
            var model = new  HouseCreateViewModel();

            ViewBag.OptionList = _optionRepository.GetAll();
            ViewBag.CategoryList = _categoryRepository.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(HouseCreateViewModel model)
        {
            model.OptionIdsJson = JsonConvert.SerializeObject(model.OptionIds);
            var result = _houseRepository.Create(model);
            TempData["Message"] = "آگهی شما با موفقیت ثبت و پس از بررسی بر روی سایت قرار میگیرد";
            return RedirectToAction("Index");
        }
    }
}