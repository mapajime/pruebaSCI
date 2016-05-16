using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSCI.Data.Entities
{
    [Table("Pilotos")]
    public class Piloto
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public Pais Nacionalidad { get; set; }
        [Required]
        public int NumeroCarro { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public Equipo Equipo { get; set; }
    }
}
