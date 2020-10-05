using Domain.Base;
using Domain.DatosBasicos;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Linq.Expressions;

namespace Domain.Cultivos
{
    public class ConsultaCultivoPorIdSpecification : ISpecification<Cultivo>
    {
        private readonly long _id;
        public ConsultaCultivoPorIdSpecification(long id)
        {
            _id = id;
        }

        public Expression<Func<Cultivo, bool>> Criteria => GetCriterio();

        public Expression<Func<Cultivo, bool>> GetCriterio()
        {
            Expression<Func<Cultivo, bool>> criterio = (t) =>
                t.Id == _id &&
                t.Estado == EstadoGeneralEnumeration.Activo.Id;

            return criterio;
        }
    }
}
