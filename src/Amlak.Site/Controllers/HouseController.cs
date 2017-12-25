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

       public HouseController(HouseRepository houseRepository)
       {
           _houseRepository = houseRepository;
       }

       public IActionResult Index()
        {
            var model = new  CreateHouseViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateHouseViewModel model)
        {
            var result = _houseRepository.Create(model);
                
            return RedirectToAction("Index");
        }
    }
}