using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Alamut.Service.Messaging.Configration;
using Alamut.Service.Messaging.Contracts;
using Amlak.Core.Entities;
using Amlak.Core.ViewModel.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Amlak.Site.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        
        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILoggerFactory loggerFactory,
            IEmailService emailService
           )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _logger = loggerFactory.CreateLogger<AccountController>();
            }

        public IActionResult SendMail(string mail, string subject, string body)
        {
            _emailService.SendEmail(new EmailBody<int>
            {
                To = mail,
                Subject = subject,
                Body = body
            });


            return Json("succeed");
        }

        //public async Task<IActionResult> SendMessage(string phoneNumber, string code, SmsType smsType = SmsType.Free)
        //{
        //    var token = new Token();
        //    var secretToken = await token.GetToken();

        //    if (!string.IsNullOrWhiteSpace(secretToken))
        //    {
        //        #region Add Sms to SmsTable

        //        var smsViewModel = new SmsViewModel
        //        {
        //            UserId = Convert.ToInt32(User.Identity.GetId()),
        //            PhoneNumber = phoneNumber,
        //            Body = code,
        //            IsSucceded = false,
        //            EvenTime = DateTime.Now,
        //            Smstype = smsType,
        //        };

        //        _smsRepository.Create(smsViewModel);
        //        #endregion

        //        var ultraModel = new UltraFastViewModel
        //        {
        //            SecretToken = secretToken,
        //            PhoneNumber = phoneNumber,
        //            VerificationCode = code,
        //            TemplateId = _smsSetting.TemplateId
        //        };

        //        var ultraFast = new UltraFastSend();
        //        var result = await ultraFast.Send(ultraModel);

        //        #region Update Sms to SmsTable

        //        if (!string.IsNullOrWhiteSpace(result))
        //        {
        //            var model = new SmsViewModel
        //            {
        //                IsSucceded = true,
        //                ResponseJson = result,
        //                PhoneNumber = phoneNumber
        //            };
        //            _smsRepository.Update(model);
        //        }

        //        #endregion
        //    }

        //    return Json("");

        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> ReSendCode(string phoneNumber)
        //{
        //    var user = _userRepository.FindByPhoneNumber(phoneNumber);
        //    // Send an SMS to verify the phone number
        //    var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);


        //    await SendMessage(phoneNumber, code);


        //    return RedirectToAction("VerifyPhoneNumber", new { phoneNumber });
        //}


      
       // #region default Action Identity


        /// <summary>
        /// defualt Action 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            // Clear the existing external cookie to ensure a clean login process
            //await HttpContext.Authentication.SignOutAsync(_externalCookieScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        //
        // POST: /Account/Login
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        //{
        //    //ViewData["ReturnUrl"] = returnUrl;
        //    //int? checksessionCaptcha = this.HttpContext.Session.GetInt32("Captcha");

        //    //if (checksessionCaptcha == null || checksessionCaptcha.ToString() != model.Captcha)
        //    //{
        //    //    ViewBag.FailMessage = "مجموع  وارد شده اشتباه است";
        //    //    return View(new LoginViewModel { PhoneNumber = model.PhoneNumber, RememberMe = model.RememberMe });
        //    //}
 
        //    if (ModelState.IsValid)
        //    {
        //        // This doesn't count login failures towards account lockout
        //        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        //   //     var user = _userRepository.FindByPhoneNumber(model.PhoneNumber);
        //        if (user == null)
        //        {
        //            ViewBag.FailMessage = "نام کاربری / کلمه عبور نامعتبر می باشد.";
        //            return View(model);
        //        }
        //        if (await _userManager.IsPhoneNumberConfirmedAsync(user))
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

        //            if (result.Succeeded)
        //            {
        //                _logger.LogInformation(1, "User logged in.");
        //                return RedirectToLocal(returnUrl);
        //            }

        //            //if (result.RequiresTwoFactor)
        //            //{
        //            //    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        //            //}
        //            if (result.IsLockedOut)
        //            {
        //                _logger.LogWarning(2, "User account locked out.");
        //                return View("Lockout");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //                ViewBag.FailMessage = "نام کاربری / کلمه عبور نامعتبر می باشد.";
        //                return View(model);
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.FailMessage = "نام کاربری / کلمه عبور نامعتبر می باشد.";
        //            // return RedirectToAction("VerifyPhoneNumber", new { phoneNumber = model.PhoneNumber });
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}



        ////
        //// POST: /Account/Login
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //    int? checksessionCaptcha = this.HttpContext.Session.GetInt32("Captcha");

        //    if (checksessionCaptcha == null || checksessionCaptcha.ToString() != model.Captcha)
        //    {
        //        ViewBag.FailMessage = "مجموع  وارد شده اشتباه است";
        //        return View(new LoginViewModel { Email = model.Email, RememberMe = model.RememberMe });
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        // This doesn't count login failures towards account lockout
        //        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user == null)
        //        {
        //            ViewBag.FailMessage = "نام کاربری / کلمه عبور نامعتبر می باشد.";
        //            return View(model);
        //        }
        //        if (await _userManager.IsEmailConfirmedAsync(user))
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
        //                lockoutOnFailure: false);

        //            if (result.Succeeded)
        //            {
        //                _logger.LogInformation(1, "User logged in.");
        //                return RedirectToLocal(returnUrl);
        //            }

        //            //if (result.RequiresTwoFactor)
        //            //{
        //            //    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        //            //}
        //            if (result.IsLockedOut)
        //            {
        //                _logger.LogWarning(2, "User account locked out.");
        //                return View("Lockout");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //                ViewBag.FailMessage = "نام کاربری / کلمه عبور نامعتبر می باشد.";
        //                return View(model);
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.FailMessage = "حساب کاربری فعال نمی باشد.جهت فعال سازی به پست الکترونیکی خود مراجعه نمایید.";
        //            return View(model);
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //

        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl)
        {
           
            // If we got this far, something failed, redisplay form
            return View(model);
        }


       

    }
}

