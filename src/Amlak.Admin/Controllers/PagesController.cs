using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Core.ViewModel.Pages;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Admin.Controllers
{
    public class PagesController : Controller
    {
        private readonly PagesRepository _pagesRepository;

        public PagesController(PagesRepository pagesRepository)
        {
            _pagesRepository = pagesRepository;
        }

        public IActionResult Index()
        {
            var model = _pagesRepository.GetAllPages();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PagesViewModel model)
        {
            var result = _pagesRepository.CreatePages(model);
            return RedirectToAction("Edit", new { id = result.Data });
        }

        public IActionResult Edit(int id)
        {
            var model = _pagesRepository.GetPagesById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PagesViewModel model)
        {
            var result = _pagesRepository.UpdatePagesById(model);
            return RedirectToAction("Edit", new { id = result.Data });
        }

        public IActionResult Delete(int id)
        {
            var result = _pagesRepository.DeletePagesById(id);
            return RedirectToAction("Index");
        }


        // ======================================(API)======================================
        public IActionResult GetAll()
        {
            var model = _pagesRepository.GetAllPages();
            return Json(model);
        }
    }
}