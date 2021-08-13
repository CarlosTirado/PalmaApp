using Domain.Base;
using Domain.DatosBasicos;
using Domain.Terceros;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.DatosBasicos.Tercero
{
    public class ConsultarTerceroQuery : IRequestHandler<ConsultarTerceroQueryRequest, ConsultarTerceroQueryResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarTerceroQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarTerceroQueryResponse> Handle(ConsultarTerceroQueryRequest request, CancellationToken cancellationToken)
        {
            var tercero = _palmAppUnitOfWork.TerceroRepository.Get(new ConsultaTerceroPorIdentificacionSpecification(request.Identificacion));
            var terceroView = new TerceroModelView()
            {
                Apellidos = tercero.Apellidos,
                Direccion = tercero.Direccion,
                Email = tercero.Email,
                Estado = tercero.Estado,
                FechaNacimiento = tercero.FechaNacimiento,
                Id = tercero.Id,
                Identificacion = tercero.Identificacion,
                Nombres = tercero.Nombres,
                Telefono = tercero.Telefono
            };

            return Task.FromResult(new ConsultarTerceroQueryResponse(terceroView));
        }
    }
    public class ConsultarTerceroQueryRequest : IRequest<ConsultarTerceroQueryResponse>
    {
        public ConsultarTerceroQueryRequest(string identificacion)
        {
            Identificacion = identificacion;
        }

        public string Identificacion { get; private set; }
    }
    public class ConsultarTerceroQueryResponse
    {
        public ConsultarTerceroQueryResponse(TerceroModelView tercero)
        {
            Tercero = tercero;
        }

        public TerceroModelView Tercero { get; set; }
    }
}
