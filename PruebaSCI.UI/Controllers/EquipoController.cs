using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PruebaSCI.Business.Servicios;
using PruebaSCI.UI.Models;

namespace PruebaSCI.UI.Controllers
{
    public class EquipoController : Controller
    {
        public IEquipoServicio EquipoServicio { get; set; }

        // GET: Equipo
        public ActionResult Index()
        {
            var list = EquipoServicio.Todos().Select(Mapper.Map<EquipoModel>);
            return View(list);
        }

        // GET: Equipo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Equipo/Create
        [HttpPost]
        public ActionResult Create(EquipoModel model)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Equipo/Edit/5
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

        // GET: Equipo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Equipo/Delete/5
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
