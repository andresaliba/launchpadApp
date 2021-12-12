using System;
using Microsoft.AspNetCore.Mvc;
using userAuthentication.Models;

namespace userAuthentication.Controllers {

    public class LoginController : Controller {

        public IActionResult Index() {
            return View();
        }

        public IActionResult Submit(string myUsername, string myPassword) {
            // construct WebLogin object and set properties
            WebLogin webLogin = new WebLogin(Connection.CONNECTION_STRING, HttpContext);
            webLogin.username = myUsername;
            webLogin.password = myPassword;

            // attempt to login!
            if (webLogin.unlock()) {
                return RedirectToAction("Index", "Home");
            } else {
                ViewData["feedback"] = "Incorrect login. Please try again...";
            }
            // generate new hashed pass
            // webLogin.newPass();

            return View("Index");
        }
    }
}
