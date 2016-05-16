using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaSCI.Data.Entities
{
    [Table("Equipos")]
    public class Equipo
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
