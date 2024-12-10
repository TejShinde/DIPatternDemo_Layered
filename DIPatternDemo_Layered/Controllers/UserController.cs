using DIPatternDemo_Layered .Models;
using DIPatternDemo_Layered .Services;
using Humanizer;
using Microsoft .AspNetCore .Http;
using Microsoft .AspNetCore .Mvc;

namespace DIPatternDemo_Layered .Controllers
    {
 
    public class UserController : Controller
        {
        private readonly IUserService service;
        private readonly IHttpContextAccessor HttpContextAccessor;

        public UserController ( IUserService service )
            {
           this. service = service;
            this .HttpContextAccessor = HttpContextAccessor;
            }

        [HttpGet]
        public IActionResult Register ()
            {
            return View();
            }

        [HttpPost]
        public IActionResult Register ( User user )
        //{
        //if ( ModelState .IsValid )
        //    {
        //    _userService .Register(user);
        //    return RedirectToAction("Login");
        //    }
        //return View(user);
        //}
            {
            try
                {
                var res = service .Register(user);
                if ( res != null )
                    {
                    ViewBag .Error = "Registered Succcessfully";
                    return RedirectToAction(nameof(Login));
                
                    }
                else
                    {
                    ViewBag .Error = "Something Went Wrong";
                    return View();
                    }
                }
            catch ( Exception ex )
                {
                ViewBag .Error = ex .Message;
                return View();
                }
            }

        [HttpGet]
        public IActionResult Login ()
            {
            return View();
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login ( User user )
            {
            try
                {
                var res = service .ValidateUser(user);
                if ( res != null )
                    {
                    string username = user .UserName;
                    HttpContext .Session .SetString("username" ,username);

                    return RedirectToAction("Index" , "Product");
                    }
                else
                    {
                    ViewBag .Error = "Invalid Email or Password";
                    return View();
                    }
                }
            catch ( Exception ex )
                {
                ViewBag .Error = ex .Message;
                return View();
                }
            }

        public IActionResult Logout ()
            {
            HttpContext .Session .Clear();
            return RedirectToAction("Login");
            }
        }
    }
