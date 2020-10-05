using Domain.Base;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Linq.Expressions;

namespace Domain.Tareas
{
    public class ConsultaTareaPorIdSpecification : ISpecification<Tarea>
    {
        private readonly long _id;
        public ConsultaTareaPorIdSpecification(long id)
        {
            _id = id;
        }

        public Expression<Func<Tarea, bool>> Criteria => GetCriterio();

        public Expression<Func<Tarea, bool>> GetCriterio()
        {
            Expression<Func<Tarea, bool>> criterio = (t) => t.Id == _id &&
            t.Estado == EstadoGeneralEnumeration.Activo.Id;
            return criterio;
        }
    }
}
