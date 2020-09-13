using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DatosBasicos.Tercero
{
    public class TerceroModelView
    {
        public long Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Estado { get; set; }
    }
}
