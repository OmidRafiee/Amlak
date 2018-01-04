using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Site.ViewComponents
{
    public class SimliarRequest:ViewComponent
    {
        private readonly HouseRepository _houseRepository;

        public SimliarRequest(HouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
