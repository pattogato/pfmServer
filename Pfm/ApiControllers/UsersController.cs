using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Pfm.Models;

namespace Pfm.ApiControllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UsersController()
        {
        }

        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [Route("register")]
        public async Task<HttpResponseMessage> RegisterUser(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return await this.BadRequest(this.ModelState).ExecuteAsync(new CancellationToken());
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name
            };

            IdentityResult result = await this.UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new ObjectContent(result.Errors.GetType(), result.Errors, new JsonMediaTypeFormatter())
                };
            }

            return await Ok().ExecuteAsync(new CancellationToken());
        }
    }
}
