using Domain.Palmas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contrato
{
    public interface IBuilder
    {
        Palma Build();
    }
}
