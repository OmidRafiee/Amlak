using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Core.ViewModel.Category;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var model = _categoryRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel vm)
        {
            var result = _categoryRepository.Create(vm);
            return RedirectToAction("Edit", new { id = result.Data });
        }

        public IActionResult Edit(int id)
        {
            var model = _categoryRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryViewModel vm)
        {
            var result = _categoryRepository.Update(vm);
            return RedirectToAction("Edit", new { id = result.Data });
        }
        public ActionResult Delete(int id)
        {
            var result = _categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }





    }
}
