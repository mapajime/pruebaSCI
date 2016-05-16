using System;

namespace PruebaSCI.Business.DTO
{
    public class PilotoDTO
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public PaisDTO Nacionalidad { get; set; }

        public int NumeroCarro { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public EquipoDTO Equipo { get; set; }
    }
}
