using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

       
    }
}
