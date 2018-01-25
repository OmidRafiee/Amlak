using System;
using Amlak.Core.SSOT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amlak.Admin.Controllers
{

   public class FileController : Controller
    {
        private readonly FileConfig _fileConfig ;

        public FileController(FileConfig fileConfig)
        {
            _fileConfig = fileConfig;
        }

        public ActionResult Image(string field = "")
        {
            ViewBag.Field = field;
            return View();
        }

        public ActionResult File(string field = "")
        {
            ViewBag.Field = field;
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(string field, IFormFile file)
        {
             //TODO: upload file
            ViewBag.Field = field;

            try
            {
                ViewBag.FileName = FileHelper.SaveFile(file, _fileConfig, "image");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }

            return View();
        }

        [HttpPost]
        public ActionResult UploadImage2()
        {
           var fileConfig = "C:\\inetpub\\wwwroot\\repository\\image\\";
            foreach (var file in Request.Form.Files)
            {
                if (file == null ||
                    file.Length == 0)
                    continue;

                return Json(new
                {
                    fileName = FileHelper.SaveFile2(file, fileConfig , "image")
                });
            }

            return Json("");
        }

        [HttpPost]
        public ActionResult UploadFile(string field, IFormFile file)
        {
             //TODO: upload file
            ViewBag.Field = field;

            try
            {
                ViewBag.FileName = FileHelper.SaveFile(file, _fileConfig, "file");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }

            return View();
        }
    }
    
}