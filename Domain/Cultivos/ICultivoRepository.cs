using Domain.Base;
using Domain.Cultivos;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Cultivos
{
    public interface ICultivoRepository
    {
        ICollection<Cultivo> Gets();
        ICollection<Cultivo> Gets(ISpecification<Cultivo> especificacion);
        Cultivo Get(ISpecification<Cultivo> especificacion);
        void Add(Cultivo cultivo);
    }
}
