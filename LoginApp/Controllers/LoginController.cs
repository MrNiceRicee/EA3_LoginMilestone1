using LoginApp.Models;
using LoginApp.Services.Business;
using LoginApp.Services.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(User user)
        {
            SecurityServices securityServices = new SecurityServices();
            if (securityServices.Authenticate(user))
            {
                return View("LoginSuccess",user);
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Register(User user)
        {
            SecurityDAO securityDAO = new SecurityDAO();
            securityDAO.RegisterUser(user);
            return View("Register");
        }
    }
}