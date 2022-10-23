using CBBApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBBApplication.Controllers
{
    [Route("Account")]

    public class AccountController : BaseController
    {
        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("LoginAction")]
        public async Task<ActionResult> LoginAction(AccountLoginModel model)
        {
            var loginResult = await PostRequest("account/login", model);
            string token = loginResult.data;
            string message = loginResult.message;
            if (token != null)
            {
                HttpContext.Session.SetComplexData("UserToken", token);
                return RedirectToAction("Index", "QuanLyDanhSachChuyenBay");
            }
            else
            {
                TempData["loginError"] = message;
                return RedirectToAction("Login", "Account");
            }
            
        }

    }
}
