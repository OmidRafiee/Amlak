using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Core.ViewModel.House;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Admin.Controllers
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
           var model= _houseRepository.GetAll();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _houseRepository.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(HouseEditViewModel model)
        {
            if (model.IsPublished)
            {
                model.PublishDate=DateTime.Now;
            }

           var result= _houseRepository.Update(model);

            return RedirectToAction("Edit", new {model.Id});
        }

       
    }
}
