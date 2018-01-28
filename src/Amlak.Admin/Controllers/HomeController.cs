using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amlak.Admin.Filter;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Amlak.Admin.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var request = Request.HttpContext.Request;

            // دسترسی به شیئ کش
            //  var cache = context.HttpContext.Cash;

            // کاربر IP بدست آوردن
            //  var IP = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;
            var IP = request.HttpContext.Connection.RemoteIpAddress;

            // مشخصات مرورگر
            var browser = request.Headers["User-Agent"].ToString();

            return View();
        }



        [HttpPost]
        [StopSpamActionFilter(DelayRequest = 0)]
        public IActionResult Index(int id)
        {
            var request = Request.HttpContext.Request;

            // دسترسی به شیئ کش
            //  var cache = context.HttpContext.Cash;

            // کاربر IP بدست آوردن
            //  var IP = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;
            var IP = request.HttpContext.Connection.RemoteIpAddress;

            // مشخصات مرورگر
            var browser = request.Headers["User-Agent"].ToString();

            // در اینجا آدرس درخواست جاری را تعیین می‌کنیم
          //  var targetInfo = (this.AddAddress) ? (request.GetDisplayUrl() + request.QueryString) : "";

            // شناسه یکتای درخواست
            //var Uniquely = String.Concat(IP, browser, targetInfo);



            return RedirectToAction("About");
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
