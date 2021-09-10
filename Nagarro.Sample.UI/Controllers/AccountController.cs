using Nagarro.Sample.EntityDataModel;
using Nagarro.Sample.Shared;
using Nagarro.Sample.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Nagarro.Sample.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "FirstName,LastName,Email,Password,ConfirmPassword")]SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                IUserFacade sampleFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
                UserDTO UserDTO = new UserDTO();
                EntityConverter.FillDTOFromEntity(signUpModel,UserDTO);
                OperationResult<UserDTO> result = sampleFacade.SignUp(UserDTO);
                if (result.IsValid())
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Email Already Exsits");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Email Already Exsits");
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if (loginModel.Email == "sneh@admin.com" && loginModel.Password == "admin")
                {
                    Session["emailID"] = "sneh@admin.com";
                    FormsAuthentication.SetAuthCookie("sneh@admin.com", false);
                    return RedirectToAction("AdminHome", "Event");

                }
                IUserFacade sampleFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
                LoginDTO userDTO = new LoginDTO();
                userDTO.Email = loginModel.Email;
                userDTO.Password = loginModel.Password;
                OperationResult<LoginDTO> result = sampleFacade.Login(userDTO);
                if (result.IsValid())
                {
                    FormsAuthentication.SetAuthCookie(loginModel.Email, false);
                    Session["userID"] = result.Data.ID.ToString();
                    Session["emailID"] = result.Data.Email;
                    return RedirectToAction("Index", "Event");
                }
                else
                {
                    ModelState.AddModelError("", "Email Already Exsits");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Website Coudn't Load");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["userID"] = null;
            Session["emailID"] = null;
            return RedirectToAction("Index", "Event");
        }
    }
}