using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaSCI.UI.Controllers
{
    public class PilotoController : Controller
    {
        // GET: Piloto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Piloto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Piloto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Piloto/Create
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

        // GET: Piloto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Piloto/Edit/5
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

        // GET: Piloto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Piloto/Delete/5
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
