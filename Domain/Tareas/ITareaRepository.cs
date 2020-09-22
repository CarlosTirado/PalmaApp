using Domain.Tareas;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tareas
{
    public interface ITareaRepository
    {
        ICollection<Tarea> Gets();
        Tarea Get(long id);
        void Add(Tarea Tarea);
    }
}
