using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alamut.Data.Paging;
using Alamut.Data.Structure;
using Alamut.Helpers.Linq;
using Amlak.Core.Entities;
using Amlak.Core.Helpers;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Amlak.Data.Repository
{
    public class UserRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IDbConnection _connection;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;


        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Constructor
        public UserRepository(AppDbContext context,
            IDbConnection connection,
            UserManager<User> userManager,
            RoleManager<Role> roleManager, SignInManager<User> signInManager,
            IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _connection = connection;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
        }
        #endregion

        #region CRUD
        

        //public List<UserSummary> GetAllAdmin()
        //{
        //    return _context.Users
        //        .Where(q => q.PropCanLoginToAdmin)
        //        .ProjectTo<UserSummary>().ToList();
        //}
        ////public IPaginated<UserSummary> GetAll(UserSearch vm)
        //{
        //    var model = _context.Users

        //            .WhereIf(vm.IsWinner, q => vm.Winners.Contains(q.Id))
        //            .WhereIf(!string.IsNullOrEmpty(vm.Term), q => q.PropFriendlyName.Contains(vm.Term) || q.PhoneNumber.Contains(vm.Term));

        //    return model.ProjectTo<UserSummary>().ToPaginated(new PaginatedCriteria(vm.Page, vm.PageSize));
        //}


        
        //public ServiceResult<UserPrsonalInformationViewModel> UpdatePrsonalInformation(UserPrsonalInformationViewModel model, int userId)
        //{
        //    var oldEntity = _context.Users.FirstOrDefault(q => q.Id == userId);

        //    oldEntity.NationalCode = model.NationalCode;
        //    oldEntity.PropAddress = model.PropAddress;
        //    oldEntity.PropPostCode = model.PropPostCode;
        //    oldEntity.PropBirthDate = model.PropBirthDate;

        //    _context.SaveChanges();
        //    var result = ServiceResult<UserPrsonalInformationViewModel>.Okay(model);
        //    return result;
        //}

        public ServiceResult Delete(int id)
        {
            var entity = _context.Users.Find(id);
            _context.Users.Remove(entity);
            _context.SaveChanges();
            return ServiceResult.Okay("کاربر با موفقیت حذف شد");
        }
        #endregion

        #region Methods
        public User GetById(int userId)
        {
            return _context.Users.Find(userId);
        }

        //public bool ValidateNationalCode(string nationalCode)
        //{
        //    var model = _context.Users.FirstOrDefault(p => p.NationalCode == nationalCode.ToLowerInvariant().Trim());
        //    return model == null;
        //}


        //public ServiceResult UpdateFriendlyName(string propFriendlyName, int id)
        //{
        //    var entity = _context.Users.Find(id);
        //    entity.PropFriendlyName = propFriendlyName;

        //    _context.Attach(entity);
        //    var model = _context.Entry(entity).Property(p => p.PropFriendlyName).IsModified;

        //    _context.SaveChanges(model);

        //    return ServiceResult.Okay("نام کاربری با موفقیت ویرایش شد");
        //}

        public bool HasEmail(string email)
        {
            var model = _context.Users.FirstOrDefault(p => p.Email == email && p.EmailConfirmed);
            if (model != null) return false;
            return true;
        }
        public bool HasPhoneNumber(string phoneNumber)
        {
            var model = _context.Users.FirstOrDefault(p => p.PhoneNumber == phoneNumber && p.PhoneNumberConfirmed);
            if (model != null) return false;
            return true;
        }

        public bool HasPhoneNumberAndConfimed(string phoneNumber)
        {
            var model = _context.Users.FirstOrDefault(p => p.PhoneNumber == phoneNumber && p.PhoneNumberConfirmed == false);
            if (model != null) return false;
            return true;
        }

        //public bool HasInvalidName(string friendlyName)
        //{
        //    //var listName = InvalidNames.List.ToList();
        //    var listName = _context.Users.Select(q => q.PropFriendlyName.Replace(" ", ""));
        //    var model = listName.FirstOrDefault(p => p.Equals(friendlyName));
        //    if (model != null) return false;
        //    return true;
        //}


        public ServiceResult ChangeUserName(string userName, int id)
        {
            var entity = _context.Users.Find(id);

            entity.UserName = userName;

            _context.Users.Attach(entity);
            var model = _context.Entry(entity).Property(p => p.UserName).IsModified;

            _context.SaveChanges(model);

            return ServiceResult.Okay("نام کاربری با موفقیت ویرایش شد");
        }
        public async Task<bool> ChangePassword(string password, int id)
        {
            var entity = _context.Users.Find(id);
            await _userManager.RemovePasswordAsync(entity);

            var result = await _userManager.AddPasswordAsync(entity, password);

            return result.Succeeded;
        }
        public ServiceResult ChangeEmail(string email, int id)
        {
            var entity = _context.Users.Find(id);

            entity.Email = email;

            _context.Users.Attach(entity);
            var model = _context.Entry(entity).Property(p => p.Email).IsModified;

            _context.SaveChanges(model);

            return ServiceResult.Okay("پست الکترونیکی با موفقیت ویرایش شد");
        }


        public async void UpdateCookie(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString()).ConfigureAwait(false);

            await _signInManager.RefreshSignInAsync(user).ConfigureAwait(false);

        }

        public User FindByPhoneNumber(string phoneNumber)
        {
            var user = _context.Users.FirstOrDefault(q => q.PhoneNumber.Equals(phoneNumber));
            return user;
        }

        public async Task<bool> HasPhoneNumberAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString()).ConfigureAwait(false);
            return user?.PhoneNumber != null;
        }

        public void ConfirmPhoneNumber(string phoneNumber)
        {
            var entity = FindByPhoneNumber(phoneNumber);
            entity.PhoneNumberConfirmed = true;

            _context.Users.Attach(entity);
            var model = _context.Entry(entity).Property(p => p.PhoneNumberConfirmed).IsModified;

            _context.SaveChanges(model);

        }


        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(q => q.Email == email);
        }



        #endregion


        
       
    }
}
