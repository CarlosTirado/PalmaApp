using Domain.Base;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Linq.Expressions;

namespace Domain.Lotes
{
    public class ConsultaLotesPorCultivoIdSpecification : ISpecification<Lote>
    {
        private readonly long _cultivoId;
        public ConsultaLotesPorCultivoIdSpecification(long cultivoId)
        {
            _cultivoId = cultivoId;
        }

        public Expression<Func<Lote, bool>> Criteria => GetCriterio();

        public Expression<Func<Lote, bool>> GetCriterio()
        {
            Expression<Func<Lote, bool>> criterio = (t) => t.CultivoId == _cultivoId &&
            t.Estado == EstadoGeneralEnumeration.Activo.Id;
            return criterio;
        }
    }
}
