using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Site.Controllers
{

    public class NewsController : Controller
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

        public IActionResult Detail(int id)
        {
            var model = _newsRepository.GetById(id);
            
            return View(model);
        }
    }

}
