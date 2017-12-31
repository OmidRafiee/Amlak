using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Core.ViewModel.House;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Site.Controllers
{
   public class HouseController : Controller
   {
       private readonly HouseRepository _houseRepository;
       private readonly OptionRepository _optionRepository;


        public HouseController(HouseRepository houseRepository, OptionRepository optionRepository)
        {
            _houseRepository = houseRepository;
            _optionRepository = optionRepository;
        }

       public IActionResult Index()
        {
            var model = new  HouseCreateViewModel();

            ViewBag.OptionList = _optionRepository.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(HouseCreateViewModel model)
        {
            var result = _houseRepository.Create(model);
                
            return RedirectToAction("Index");
        }
    }
}