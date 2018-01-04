﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Core.DTO.Detail;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Site.Controllers
{
    public class DetailController : Controller
    {
        private readonly HouseRepository _houseRepository;

        public DetailController(HouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public IActionResult Index(SearchDTO vm)
        {
            var model = _houseRepository.GetAll(vm);
            return View(model);
        }
    }
}