using Data.Context;
using Domain.Tareas;
using Domain.DatosBasicos;
using Domain.DatosBasicos.EstadosGenerales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Base;
using Domain.Base;

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
            return _context.Tareas.ToList();
        }
        public ICollection<Tarea> Gets(ISpecification<Tarea> especificacion)
        {
            return SpecificationEvaluator<Tarea>.GetQuery(_context.Tareas.AsQueryable(), especificacion).ToList();
        }

        public Tarea Get(ISpecification<Tarea> especificacion)
        {
            return SpecificationEvaluator<Tarea>.GetQuery(_context.Tareas.AsQueryable(), especificacion).FirstOrDefault();
        }

        public void Add(Tarea Tarea)
        {
            _context.Tareas.Add(Tarea);
        }
    }
}
