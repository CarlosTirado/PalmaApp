using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DatosBasicos
{
    public interface ITerceroRepository
    {
        ICollection<Tercero> Gets();
        Tercero Get(string identificacion);
        Tercero GetPorCorreo(string correo);
    }
}
