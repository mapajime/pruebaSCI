using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaSCI.Business.DTO
{
   
    public class EquipoDTO
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }
    }
}
