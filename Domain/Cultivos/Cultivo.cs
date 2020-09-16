using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Cultivos
{
    public class Cultivo
    {
        public Cultivo(string nombre, DateTime fechaSiembra)
        {
            Nombre = nombre;
            FechaSiembra = fechaSiembra;
            Estado = EstadoGeneralEnumeration.Activo.Id;
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaSiembra { get; set; }
        public string Estado { get; set; }

        public void Editar(string nombre, DateTime fechaSiembra, string estado)
        {
            Nombre = nombre;
            FechaSiembra = fechaSiembra;
            Estado = estado;
        }
    }
}
