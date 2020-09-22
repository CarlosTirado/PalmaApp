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
        }

        public long Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public void Editar(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;            
        }
    }
}
