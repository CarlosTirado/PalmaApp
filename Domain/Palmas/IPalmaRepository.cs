using Domain.Palmas;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Palmas
{
    public interface IPalmaRepository
    {
        ICollection<Palma> Gets(long loteId);
        Palma Get(long id);
        void Add(Palma Palma);
    }
}
