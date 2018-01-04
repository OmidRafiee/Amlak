using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Site.ViewComponents
{
    public class SpecialOffer:ViewComponent
    {
        private readonly HouseRepository _houseRepository;

        public SpecialOffer(HouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
