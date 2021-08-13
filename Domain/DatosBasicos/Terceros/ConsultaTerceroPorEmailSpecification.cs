using Domain.Base;
using Domain.DatosBasicos;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Linq.Expressions;

namespace Domain.Terceros
{
    public class ConsultaTerceroPorEmailSpecification : ISpecification<Tercero>
    {
        private readonly string _email;
        public ConsultaTerceroPorEmailSpecification(string email)
        {
            _email = email;
        }

        public Expression<Func<Tercero, bool>> Criteria => GetCriterio();

        public Expression<Func<Tercero, bool>> GetCriterio()
        {
            Expression<Func<Tercero, bool>> criterio = (t) => 
            t.Email == _email &&
            t.Estado == EstadoGeneralEnumeration.Activo.Id;
            return criterio;
        }
    }
}
