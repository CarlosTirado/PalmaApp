using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DatosBasicos
{
    public interface ITerceroRepository
    {
        ICollection<Tercero> Gets();
        ICollection<Tercero> Gets(ISpecification<Tercero> especificacion);
        Tercero Get(ISpecification<Tercero> especificacion);
    }
}
