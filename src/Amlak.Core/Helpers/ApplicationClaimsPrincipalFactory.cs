using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Amlak.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Amlak.Core.Helpers
{
    public class ApplicationClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        /// <summary>
        ///Add implemented User Claims
        /// </summary>

        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public static readonly string PropCanLoginToAdmin = nameof(PropCanLoginToAdmin);


        public ApplicationClaimsPrincipalFactory(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)


        {
            _userManager = userManager;
            _roleManager = roleManager;
            _optionsAccessor = optionsAccessor;
        }


        // TODO : syntax error in net core 2
        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user).ConfigureAwait(false); // adds all `Options.ClaimsIdentity.RoleClaimType -> Role Claims` automatically + `Options.ClaimsIdentity.UserIdClaimType -> userId` & `Options.ClaimsIdentity.UserNameClaimType -> userName`
            AddCustomClaims(user, principal);
            return principal;
        }

        private static void AddCustomClaims(User user, IPrincipal principal)
        {
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim(ClaimTypes.GivenName, user.FriendlyName ?? string.Empty),
                new Claim(ClaimTypes.Sid, user.Id.ToString() , ClaimValueTypes.Integer),
                
                //new Claim(CustomClaimsSSOT.BidsTillQuestion.ToString(), user.PropBidsTillQuestion.ToString(), ClaimValueTypes.Integer),
                //new Claim(CustomClaimsSSOT.MasterKeys.ToString(), user.MasterKeys.ToString(), ClaimValueTypes.Integer),

                //new Claim(CustomClaimsSSOT.MagicKeys.ToString(), user.MagicKeys.ToString(), ClaimValueTypes.Integer),
                //new Claim(CustomClaimsSSOT.BidsTillMagicKey.ToString(), user.PropBidsTillMagicKey.ToString(), ClaimValueTypes.Integer),
            });
        }


    }
}