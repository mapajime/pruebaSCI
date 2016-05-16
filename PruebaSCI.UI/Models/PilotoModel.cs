using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PruebaSCI.Business.Servicios;
using System.Web.Mvc;

namespace PruebaSCI.UI.Models
{
    public class PilotoModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El Piloto es requerido"), StringLength(50), Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        public Guid Nacionalidad { get; set; }
        [Required]
        public int NumeroCarro { get; set; }
        [Required]
        public DateTime? FechaNacimeinto { get; set; }
        [Required]
        public Guid Equipo { get; set; }

        [ScaffoldColumn(false)]
        public string NombrePais { get; set; }

        [ScaffoldColumn(false)]
        public string NombreEquipo{ get; set; }

        public IEnumerable<SelectListItem> Paises
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> Equipos
        {
            get;
            set;
        }
    }
}