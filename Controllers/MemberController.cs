using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;
using System.Data.OleDb;
using CapStone.Models;


namespace CapStone.Controllers
{
    public class MemberController : Controller
    {
        private MemberModel client = new MemberModel();
        private RolesModel db = new RolesModel();
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        // GET: Member/Create
        public ActionResult Register()
        {
            //var getclass = ["admin", "member"];
            //SelectList list = new SelectList(getclass);
            //ViewBag.SelectClass = list;
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "Id")] Member NewMember)
        {
            try
            {
                // TODO: Add insert logic here

                NewMember.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(NewMember.Password, "SHA1");
                var getMember = client.Members.Where(n => n.Email == NewMember.Email && n.Password == NewMember.Password).FirstOrDefault();

                if (getMember!=null)
                {
                    ViewBag.NotAdded = "Member already exists, login instead";
                    return View("Register");
                }

                client.Members.Add(NewMember);
                client.SaveChanges();
                var getM = client.Members.Where(n => n.Email == NewMember.Email && n.Password == NewMember.Password).FirstOrDefault();

                Role newRole = new Role();
                newRole.Role1 = "user";
                newRole.userId = getM.Id;
                db.Roles.Add(newRole);
                db.SaveChanges();

                //NewMember.Type = "member";
              
                ModelState.Clear();
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Login(Member NewMember, string returnUrl)
        {
            
            
                // TODO: Add insert logic here
                string hashedpasswrd = FormsAuthentication.HashPasswordForStoringInConfigFile(NewMember.Password, "SHA1");
                var getMember = client.Members.Where(n => n.Email == NewMember.Email && n.Password == hashedpasswrd).FirstOrDefault();

            Session["logged"] = null;

            if (getMember != null)
            {
                var admin = db.Roles.Where(n => n.userId == getMember.Id && n.Role1 == "admin").FirstOrDefault();
                Session["admin"] = false;
                if (admin != null)
                    Session["admin"] =true;
            

                FormsAuthentication.SetAuthCookie(NewMember.Email, true);
                Session["logged"] = true;

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction(controllerName: "Class", actionName: "Index");
               
            }
            else
            {
                ViewBag.Mess = "Invalid username/password";
                return View("Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["logged"] = null;
            Session["isAdmin"] = null;
            return View("Login");
        }
    }
}
