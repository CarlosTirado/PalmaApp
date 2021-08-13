using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public interface ICloneable<T>
    {
        T Clonar();
    }
}
