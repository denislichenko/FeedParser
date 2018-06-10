using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuth.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login(User user)
        {
            UserContext context = new UserContext();
            var users = context.users;

            foreach(User usr in users)
            {
                
            }

            return View();
        }
    }
}