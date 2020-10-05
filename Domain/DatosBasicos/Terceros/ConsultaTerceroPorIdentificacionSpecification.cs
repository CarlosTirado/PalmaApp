using Domain.Base;
using Domain.DatosBasicos;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Linq.Expressions;

namespace Domain.Terceros
{
    public class ConsultaTerceroPorIdentificacionSpecification : ISpecification<Tercero>
    {
        private readonly string _identificacion;
        public ConsultaTerceroPorIdentificacionSpecification(string identificacion)
        {
            _identificacion = identificacion;
        }

        public Expression<Func<Tercero, bool>> Criteria => GetCriterio();

        public Expression<Func<Tercero, bool>> GetCriterio()
        {
            Expression<Func<Tercero, bool>> criterio = (t) => t.Identificacion == _identificacion &&
            t.Estado == EstadoGeneralEnumeration.Activo.Id;
            return criterio;
        }
    }
}
