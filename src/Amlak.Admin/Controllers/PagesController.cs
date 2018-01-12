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

        public ActionResult Index()
        {
            var model = _pagesRepository.GetAllPages();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PagesViewModel model)
        {
            var result = _pagesRepository.CreatePages(model);
            return RedirectToAction("Edit", new { id = result.Data });
        }

        public ActionResult Edit(int id)
        {
            var model = _pagesRepository.GetPagesById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PagesViewModel model)
        {
            var result = _pagesRepository.UpdatePagesById(model);
            return RedirectToAction("Edit", new { id = result.Data });
        }

        public ActionResult Delete(int id)
        {
            var result = _pagesRepository.DeletePagesById(id);
            return RedirectToAction("Index");
        }


        // ======================================(API)======================================
        public ActionResult GetAll()
        {
            var model = _pagesRepository.GetAllPages();
            return Json(model);
        }
    }
}