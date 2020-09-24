
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tareas
{
    public class Tarea
    {
        public Tarea(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Estado= EstadoGeneralEnumeration.Activo.Id;
        }

        public long Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public string Estado { get; private set; }

        public void Editar(string nombre, string descripcion, string estado)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Estado = estado;
        }
    }
}
