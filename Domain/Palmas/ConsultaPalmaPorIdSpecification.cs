using Domain.Base;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Linq.Expressions;

namespace Domain.Palmas
{
    public class ConsultaPalmaPorIdSpecification : ISpecification<Palma>
    {
        private readonly long _palmaId;
        public ConsultaPalmaPorIdSpecification(long palmaId)
        {
            _palmaId = palmaId;
        }

        public Expression<Func<Palma, bool>> Criteria => GetCriterio();

        public Expression<Func<Palma, bool>> GetCriterio()
        {
            Expression<Func<Palma, bool>> criterio = (t) => t.Id == _palmaId &&
            t.Estado == EstadoGeneralEnumeration.Activo.Id;

            return criterio;
        }
    }
}
