using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaSCI.UI.Models
{
    public class EquipoModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El Equipo es requerido"), StringLength(50), Display(Name = "Equipo")]
        public string Nombre { get; set; }
    }
}