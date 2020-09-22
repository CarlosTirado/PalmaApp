using Data.Context;
using Domain.Tareas;
using Domain.DatosBasicos;
using Domain.DatosBasicos.EstadosGenerales;
using Domain.Tareas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Tareas
{
    public class TareaRepository : ITareaRepository
    {
        private readonly PalmAppContext _context;

        public TareaRepository(PalmAppContext context)
        {
            _context = context;
        }

        public ICollection<Tarea> Gets()
        {
            var Tareas = _context.Tareas.Where(t => t.Estado == EstadoGeneralEnumeration.Activo.Id).ToList();
            return Tareas;
        }

        public Tarea Get(long id)
        {
            var Tarea = _context.Tareas
                .FirstOrDefault(t =>
                    t.Estado == EstadoGeneralEnumeration.Activo.Id &&
                    t.Id == id);
            return Tarea;
        }

        public void Add(Tarea Tarea)
        {
            _context.Tareas.Add(Tarea);
        }
    }
}
