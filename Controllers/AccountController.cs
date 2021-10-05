using ltap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ltap.Controllers
{
    public class AccountController : Controller
    {
        public object FormAuthentication { get; private set; }

        public ViewResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult login(AccountModel acc, string returnUrl)
        {
            //Neu vuot qua duoc validation o accountmodel
            if (ModelState.IsValid)
            {
                //Kiem tra thong tin dang nhap
                if (acc.Username == "admin" && acc.Password == "123456")
                {
                    //Set Cookie
                    FormsAuthentication.SetAuthCookie(acc.Username, true);
                    return RedirectToLocal(returnUrl);
                }
            }
            return View(acc);
        }
        //Ham dang xuat khoi chuong trinh
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //Kiem tra ReturnUrl co thuoc he thong hay khong
         private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }       
        }            
    }
