using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Site.ViewComponents
{
    public class SearchMain : ViewComponent
    {
        private readonly OptionRepository _optionRepository;
        private readonly CategoryRepository _categoryRepository;

        public SearchMain(OptionRepository optionRepository, CategoryRepository categoryRepository)
        {
            _optionRepository = optionRepository;
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.OptionList = _optionRepository.GetAll();
            ViewBag.CategoryList = _categoryRepository.GetAll();

            return View();
        }
    }
}
