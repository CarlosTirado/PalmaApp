using Domain.Cultivos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Lotes
{
    public interface ILoteRepository
    {
        ICollection<Lote> Gets();
        Lote Get(long id);
        void Add(Lote lote);
    }
}
