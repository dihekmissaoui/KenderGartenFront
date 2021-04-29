using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KenderGartenFront.Controllers
{
    public class questionForumController : Controller
    {
        // GET: questionForum
        public ActionResult Index()
        {
            return View();
        }

        // GET: questionForum/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: questionForum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: questionForum/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: questionForum/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: questionForum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: questionForum/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: questionForum/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }











    }
}
