using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PruebaSCI.Business.Servicios;
using PruebaSCI.UI.Models;
using PruebaSCI.Business.DTO;

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

                EquipoServicio.Insertar(Mapper.Map<EquipoDTO>(model));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = Mapper.Map<EquipoModel>(EquipoServicio.ObtenerPorId(id));
            return View(model);
        }

        // POST: Equipo/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, EquipoModel model)
        {
            try
            {
                EquipoServicio.Actualizar(Mapper.Map<EquipoDTO>(model));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipo/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = Mapper.Map<EquipoModel>(EquipoServicio.ObtenerPorId(id));
            return View(model);
        }

        // POST: Equipo/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, EquipoModel model)
        {
            try
            {
                EquipoServicio.Borrar(model.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
