using Domain.Palmas;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Palmas
{
    public interface IPalmaRepository
    {
        ICollection<Palma> Gets(ISpecification<Palma> especificacion);
        Palma Get(ISpecification<Palma> especificacion);
        void Add(Palma Palma);
    }
}
