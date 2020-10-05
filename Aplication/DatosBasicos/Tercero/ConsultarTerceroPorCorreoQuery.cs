using Domain.Base;
using Domain.Terceros;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.DatosBasicos.Tercero
{
    public class ConsultarTerceroPorCorreoQuery : IRequestHandler<ConsultarTerceroPorCorreoQueryRequest, ConsultarTerceroPorCorreoQueryResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarTerceroPorCorreoQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarTerceroPorCorreoQueryResponse> Handle(ConsultarTerceroPorCorreoQueryRequest request, CancellationToken cancellationToken)
        {
            var tercero = _palmAppUnitOfWork.TerceroRepository.Get(new ConsultaTerceroPorEmailSpecification(request.Correo));
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

            return Task.FromResult(new ConsultarTerceroPorCorreoQueryResponse(terceroView));
        }
    }
    public class ConsultarTerceroPorCorreoQueryRequest : IRequest<ConsultarTerceroPorCorreoQueryResponse>
    {
        public ConsultarTerceroPorCorreoQueryRequest(string correo)
        {
            Correo = correo;
        }

        public string Correo { get; private set; }
    }
    public class ConsultarTerceroPorCorreoQueryResponse
    {
        public ConsultarTerceroPorCorreoQueryResponse(TerceroModelView tercero)
        {
            Tercero = tercero;
        }

        public TerceroModelView Tercero { get; set; }
    }
}
