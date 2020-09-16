using Domain.Cultivos;
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
    }
}
