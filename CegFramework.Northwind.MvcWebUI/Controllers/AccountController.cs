using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using CegFramework.Core.CrossCuttingConcerns.Security.Web;
using CegFramework.Northwind.Business.Abstract;

namespace CegFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account
        public string Login(string userName, string password)
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(), user.UserName, user.Email,DateTime.Now.AddDays(15),
                    _userService.GetUserRoles(user).Select(x=> x.RoleName).ToArray(), false, user.FirstName, user.LastName
                );
                return "User is Authenticated!";
            }
            return "User is not Authenticated!";

            /*
            AuthenticationHelper.CreateAuthCookie(
                new Guid(), "codercengiz", "codercengiz@gmail.com", DateTime.Now.AddDays(15),
                new[] { "Admin" }, false, "Cengiz", "CengizL"
            );
            return "User is Authenticated!";*/


        }
         
    }
}