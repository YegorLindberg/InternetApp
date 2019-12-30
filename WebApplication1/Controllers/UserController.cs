using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(User user)
        {
            using (DbModels dbModel = new DbModels())
            {
                try
                {
                    if (dbModel.Users.Any( x => x.fullName == user.fullName))
                    {
                        ViewBag.DuplicateMessage = "User already exist.";
                        return View("AddOrEdit", user);
                    }

                    dbModel.Users.Add(user);
                    dbModel.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        Response.Write("Object: " + validationError.Entry.Entity.ToString());
                        Response.Write("\n");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            Response.Write(err.ErrorMessage + "\n");
                        }
                    }
                }
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successfull.";
            return View("AddOrEdit");
        }
    }
}