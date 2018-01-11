using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Site.ViewComponents
{
    public class AboutUs:ViewComponent
    {
        private readonly PagesRepository _pagesRepository;

        public AboutUs(PagesRepository pagesRepository)
        {
            _pagesRepository = pagesRepository;
        }


        public IViewComponentResult Invoke()
        {
            var model = _pagesRepository.GetPagesByBasename("About");
            return View(model);
        }
    }
}
