using Domain.Base;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Linq.Expressions;

namespace Domain.Palmas
{
    public class ConsultaPalmasPorLoteIdSpecification : ISpecification<Palma>
    {
        private readonly long _loteId;
        public ConsultaPalmasPorLoteIdSpecification(long loteId)
        {
            _loteId = loteId;
        }

        public Expression<Func<Palma, bool>> Criteria => GetCriterio();

        public Expression<Func<Palma, bool>> GetCriterio()
        {
            Expression<Func<Palma, bool>> criterio = (t) => t.LoteId == _loteId &&
            t.Estado == EstadoGeneralEnumeration.Activo.Id;

            return criterio;
        }
    }
}
