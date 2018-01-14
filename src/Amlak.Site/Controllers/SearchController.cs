using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Core.DTO.Detail;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Site.Controllers
{
    public class SearchController : Controller
    {
        private readonly HouseRepository _houseRepository;
        private readonly OptionRepository _optionRepository;
        private readonly CategoryRepository _categoryRepository;



        public SearchController(HouseRepository houseRepository, OptionRepository optionRepository, CategoryRepository categoryRepository)
        {
            _houseRepository = houseRepository;
            _optionRepository = optionRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
           
            ViewBag.OptionList = _optionRepository.GetAll();
            ViewBag.CategoryList = _categoryRepository.GetAll();
            return View();
        }

        public IActionResult Detail(int id)
        {
            var model = _houseRepository.GetById(id);

            ViewBag.OptionList = _optionRepository.GetAll();
            ViewBag.CategoryList = _categoryRepository.GetAll();
            return View(model);
        }

    }
}