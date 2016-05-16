using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaSCI.UI.Models
{
    public class PaisModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El pais es requerido"), StringLength(50), Display(Name = "Pais")]
        public string Nombre { get; set; }
    }
}