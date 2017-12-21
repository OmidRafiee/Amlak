using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Admin.Controllers
{
    [Route("[controller]")]
    public class PagesController : Controller
    {
        //private readonly PagesRepository _pagesRepository;

        //public PagesController(PagesRepository pagesRepository)
        //{
        //    _pagesRepository = pagesRepository;
        //}

        //[Route("{basename}")]
        //public ActionResult Detail(string basename)
        //{
        //    var model = _pagesRepository.GetPagesByBasename(basename);

        //    if (model == null)
        //        return NotFound();

        //    if (!model.IsPublished)
        //        return NotFound();

        //    return View(model);
        //}
    }
}