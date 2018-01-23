using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Core.ViewModel.News;
using Amlak.Core.ViewModel;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Admin.Controllers
{
    public class NewsController: Controller
    {
        private readonly NewsRepository _newsRepository;

        public NewsController(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }


        public IActionResult Index()
        {
            var model = _newsRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NewsViewModel model)
        {
            var result = _newsRepository.Create(model);
            return RedirectToAction("Edit", new { id = result.Data });
        }

        public IActionResult Edit(int id)
        {
            var model = _newsRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NewsViewModel model)
        {
            var result = _newsRepository.Update(model);
            return RedirectToAction("Edit", new { id = result.Data });
        }

        public IActionResult Delete(int id)
        {
            var result = _newsRepository.DeleteById(id);
            return RedirectToAction("Index");
        }

        
    }
}