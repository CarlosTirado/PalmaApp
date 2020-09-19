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
        Cultivo Get(long id);
        void Add(Cultivo cultivo);
        Lote GetLotePorId(long loteId);
        ICollection<Lote> GetLotes(long cultivoId);
    }
}
