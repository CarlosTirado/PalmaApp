using Domain.DatosBasicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public interface IPalmAppUnitOfWork
    {
        DateTime DateNow { get; }
        int Commit();
        ITerceroRepository TerceroRepository { get; }
    }
}
