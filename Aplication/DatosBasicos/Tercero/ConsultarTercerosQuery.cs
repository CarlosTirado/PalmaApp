using Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.DatosBasicos.Tercero
{
    public class ConsultarTercerosQuery : IRequestHandler<ConsultarTercerosQueryRequest, ConsultarTercerosQueryResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarTercerosQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarTercerosQueryResponse> Handle(ConsultarTercerosQueryRequest request, CancellationToken cancellationToken)
        {
            var terceros = _palmAppUnitOfWork.TerceroRepository.Gets();
            var tercerosView = terceros.Select(t => new TerceroModelView()
            {
                Apellidos = t.Apellidos,
                Direccion = t.Direccion, 
                Email = t.Email,
                Estado = t.Estado,
                FechaNacimiento = t.FechaNacimiento,
                Id = t.Id,
                Identificacion = t.Identificacion,
                Nombres = t.Nombres,
                Telefono = t.Telefono
            }).ToList();

            return Task.FromResult(new ConsultarTercerosQueryResponse(tercerosView));
        }
    }
    public class ConsultarTercerosQueryRequest : IRequest<ConsultarTercerosQueryResponse>
    {
    }
    public class ConsultarTercerosQueryResponse
    {
        public ConsultarTercerosQueryResponse(List<TerceroModelView> terceros)
        {
            Terceros = terceros;
        }

        public List<TerceroModelView> Terceros { get; set; }
    }
}
