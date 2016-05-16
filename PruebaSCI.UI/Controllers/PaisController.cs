using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PruebaSCI.Business.DTO;
using PruebaSCI.Business.Servicios;
using PruebaSCI.UI.Models;

namespace PruebaSCI.UI.Controllers
{
    public class PaisController : Controller
    {
        public INacioanlidadServicio NacionalidadServicio { get; set; }

        // GET: Pais
        public ActionResult Index()
        {
            var list = NacionalidadServicio.Todos().Select(Mapper.Map<PaisModel>);
            return View(list);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        [HttpPost]
        public ActionResult Create(PaisModel model)
        {
            try
            {
                NacionalidadServicio.Insertar(Mapper.Map<PaisDTO>(model));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = Mapper.Map<PaisModel>(NacionalidadServicio.ObtenerPorId(id));
            return View(model);
        }

        // POST: Pais/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, PaisModel model)
        {
            try
            {
                NacionalidadServicio.Actualizar(Mapper.Map<PaisDTO>(model));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = Mapper.Map<PaisModel>(NacionalidadServicio.ObtenerPorId(id));
            return View(model);
        }

        // POST: Pais/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, PaisModel model)
        {
            try
            {
                NacionalidadServicio.Borrar(model.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
