using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Core.ViewModel.Option;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Admin.Controllers
{
    public class OptionController : Controller
    {
        private readonly OptionRepository _optionRepository;

        public OptionController(OptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public IActionResult Index()
        {
            var model = _optionRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OptionViewModel vm)
        {
            var result = _optionRepository.Create(vm);
            return RedirectToAction("Edit", new { id = result.Data });
        }

        public IActionResult Edit(int id)
        {
            var model = _optionRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OptionViewModel vm)
        {
            var result = _optionRepository.Update(vm);
            return RedirectToAction("Edit", new { id = result.Data });
        }
        public ActionResult Delete(int id)
        {
            var result = _optionRepository.Delete(id);
            return RedirectToAction("Index");
        }





    }
}
