using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Site.Controllers
{
    public class HouseController : Controller
    {
        public IActionResult Index()
        {
            var model = new HouseViewModel();
            return View();
        }
    }
}