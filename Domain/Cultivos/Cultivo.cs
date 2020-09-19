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

        public long Id { get; private set; }
        public string Nombre { get; private set; }
        public DateTime FechaSiembra { get; private set; }
        public string Estado { get; private set; }

        public void Editar(string nombre, DateTime fechaSiembra, string estado)
        {
            Nombre = nombre;
            FechaSiembra = fechaSiembra;
            Estado = estado;
        }
    }
}
