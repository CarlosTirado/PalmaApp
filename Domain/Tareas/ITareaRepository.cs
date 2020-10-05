using Domain.Tareas;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Tareas
{
    public interface ITareaRepository
    {
        ICollection<Tarea> Gets();
        ICollection<Tarea> Gets(ISpecification<Tarea> especificacion);
        Tarea Get(ISpecification<Tarea> especificacion);
        void Add(Tarea Tarea);
    }
}
