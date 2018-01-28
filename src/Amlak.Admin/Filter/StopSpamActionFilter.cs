using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace Amlak.Admin.Filter
{
    public class StopSpamActionFilter : ExceptionFilterAttribute
    {
        //private readonly IMemoryCache _cache;
        ////private readonly int _delayRequest;

        //public StopSpamActionFilter(IMemoryCache cache/*, int delayRequest*/)
        //{
        //    _cache = cache;
        //  //  _delayRequest = delayRequest;
        //}


        // حداقل زمان مجاز بین درخواست‌ها برحسب ثانیه
        public int DelayRequest = 10;

        // پیام خطایی که در صورت رسیدن درخواست غیرمجاز باید صادر کنیم
        public string ErrorMessage = "درخواست‌های شما در مدت زمان معقولی صورت نگرفته است.";

        //خصوصیتی برای تعیین اینکه آدرس درخواست هم به شناسه یکتا افزوده شود یا خیر
        public bool AddAddress = true;

        public  void OnActionExecuting(ActionExecutingContext context)
        {
            // درسترسی به شئی درخواست
            var request = context.HttpContext.Request;

            // دسترسی به شیئ کش
            //  var cache = context.HttpContext.Cash;

            // کاربر IP بدست آوردن
            //  var IP = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;
            var IP = request.HttpContext.Connection.RemoteIpAddress;

            // مشخصات مرورگر
            var browser = request.Headers["User-Agent"].ToString();

            // در اینجا آدرس درخواست جاری را تعیین می‌کنیم
            var targetInfo = (this.AddAddress) ? (request.GetDisplayUrl() + request.QueryString) : "";

            // شناسه یکتای درخواست
            var Uniquely = String.Concat(IP, browser, targetInfo);


            //در اینجا با کمک هش یک امضا از شناسه‌ی درخواست ایجاد می‌کنیم
            var hashValue = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(Uniquely)).Select(s => s.ToString("x2")));

            //string greeting = "";
            //_cache.Set(hashValue, greeting,
            //    new MemoryCacheEntryOptions()
            //        .SetAbsoluteExpiration(DateTime.Now.AddSeconds(DelayRequest)));

            //// ابتدا چک می‌کنیم که آیا شناسه‌ی یکتای درخواست در کش موجود نباشد
            //if (_cache.TryGetValue(hashValue, out hashValue) != true)
            //{
            //    // یک خطا اضافه می‌کنیم ModelState اگر موجود بود یعنی کمتر از زمان موردنظر درخواست مجددی صورت گرفته و به
            //    context.ModelState.AddModelError("ExcessiveRequests", ErrorMessage);
            //}
            //else
            //{
            //    // اگر موجود نبود یعنی درخواست با زمانی بیشتر از مقداری که تعیین کرده‌ایم انجام شده
            //    // پس شناسه درخواست جدید را با پارامتر زمانی که تعیین کرده بودیم به شیئ کش اضافه می‌کنیم
            //    //    _cache.CreateEntry(hashValue);
            //    //cache.Add(hashValue, true, null, DateTime.Now.AddSeconds(DelayRequest), Cache.NoSlidingExpiration, CacheItemPriority.High, null);

            //    //string greeting = "";
            //    //_cache.Set(hashValue, greeting,
            //    //    new MemoryCacheEntryOptions()
            //    //        .SetAbsoluteExpiration(DateTime.Now.AddSeconds(DelayRequest)));
            //}
            ////  base.OnActionExecuting(filterContext);

            //base.OnException();
            throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
