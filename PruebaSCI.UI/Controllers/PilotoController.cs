using AutoMapper;
using PruebaSCI.Business.DTO;
using PruebaSCI.Business.Servicios;
using PruebaSCI.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaSCI.UI.Controllers
{
    public class PilotoController : Controller
    {
        public IPilotoServicio PilotoServicio { get; set; }
        public INacioanlidadServicio NacionalidadServicio { get; set; }
        public IEquipoServicio EquipoServicio { get; set; }

        // GET: Piloto
        public ActionResult Index()
        {
            var list = PilotoServicio.Todos().Select(Mapper.Map<PilotoModel>);
            return View(list);
        }

        // GET: Piloto/Details/5
        public ActionResult Details(Guid id)
        {
            var list = PilotoServicio.Todos().Select(Mapper.Map<PilotoModel>);
            return View();
        }

        // GET: Piloto/Create
        public ActionResult Create()
        {
            var model = new PilotoModel();
            model.Paises = NacionalidadServicio.Todos().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Nombre });
            model.Equipos = EquipoServicio.Todos().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Nombre });

            return View(model);
        }

        // POST: Piloto/Create
        [HttpPost]
        public ActionResult Create(PilotoModel model)
        {
            try
            {
                PilotoServicio.Insertar(Mapper.Map<PilotoDTO>(model));

                return RedirectToAction("Index");
            }
            catch
            {
                return View(new PilotoModel());
            }
        }

        // GET: Piloto/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = Mapper.Map<PilotoModel>(PilotoServicio.ObtenerPorId(id));
            model.Paises = NacionalidadServicio.Todos().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Nombre, Selected = p.Id == model.Nacionalidad });
            model.Equipos = EquipoServicio.Todos().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Nombre, Selected = p.Id == model.Equipo });

            return View(model);
        }

        // POST: Piloto/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, PilotoModel model)
        {
            try
            {
                PilotoServicio.Actualizar(Mapper.Map<PilotoDTO>(model));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Piloto/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = Mapper.Map<PilotoModel>(PilotoServicio.ObtenerPorId(id));
            return View(model);
        }

        // POST: Piloto/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, PilotoModel model)
        {
            try
            {
                PilotoServicio.Borrar(model.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
