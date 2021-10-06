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
        LapTrinhQuanLyDBcontext db = new LapTrinhQuanLyDBcontext();
        Encrytion enc = new Encrytion();
        StringProcess strPro = new StringProcess();


        public ActionResult Login(string returnUrl)

        {
            if (CheckSession() == 1)

            {

                return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
            }
            else if (CheckSession() == 2)

            {
                return RedirectToAction("Index", "HomeEmp", new { Area = "Employees" });

            }
            ViewBag.ReturnUrl = returnUrl;
            return View();

        }
        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login(AccountModel acc, string returnUrl)

        {
            try
            {
                if (!string.IsNullOrEmpty(acc.UseName) && !string.IsNullOrEmpty(acc.PassWord))
                {

                    using (var db = new LapTrinhQuanLyDBcontext())

                    {
                        var passToMD5 = strPro.GetMD5(acc.PassWord);
                        var account = db.Accounts.Where(m => m.UseName.Equals(acc.UseName) && m.PassWord.Equals(passToMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.UseName, false);
                            Session["idUser"] = acc.UseName;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectTolocal(returnUrl);
                        }

                        ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");

                    }
                }
                ModelState.AddModelError("", "Username and password is required.");
            }

            catch
            {
                ModelState.AddModelError("", "Hệ thống đang được bảo trì, vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(AccountModel acc)
        {
            if (ModelState.IsValid)
            {
                //Mã Hóa mật khẩu trước khi cho vào database
                acc.PassWord = enc.PasswordEncrytion(acc.PassWord);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["iduser"] = null;
            return RedirectToAction("Login", "Account");
        }
        private ActionResult RedirectTolocal(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "HomeEmp", new { Area = "Employees" });
                }
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private int CheckSession()
        {
            using (var db = new LapTrinhQuanLyDBcontext())
            {
                var user = HttpContext.Session["idUser"];
                if (user != null)
                {
                    var role = db.Accounts.Find(user.ToString()).RoleID;
                    if (role != null)
                    {
                        if (role.ToString() == "Admin")
                        {
                            return 1;
                        }
                        else if (role.ToString() == "nv")
                        {
                            return 2;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
