using Domain.Base;
using Domain.Lotes;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Lotes
{
    public interface ILoteRepository
    {
        ICollection<Lote> Gets();
        ICollection<Lote> Gets(ISpecification<Lote> especificacion);
        Lote Get(ISpecification<Lote> especificacion);
    }
}
