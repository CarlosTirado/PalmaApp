using Domain.Base;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Linq.Expressions;

namespace Domain.Lotes
{
    public class ConsultaLotePorIdSpecification : ISpecification<Lote>
    {
        private readonly long _id;
        public ConsultaLotePorIdSpecification(long id)
        {
            _id = id;
        }

        public Expression<Func<Lote, bool>> Criteria => GetCriterio();

        public Expression<Func<Lote, bool>> GetCriterio()
        {
            Expression<Func<Lote, bool>> criterio = (t) => t.Id == _id &&
            t.Estado == EstadoGeneralEnumeration.Activo.Id;
            return criterio;
        }
    }
}
