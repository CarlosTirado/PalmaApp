using Domain.Base;
using Domain.Cultivos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Cultivos
{
    public class RegistrarCultivoQuery : IRequestHandler<RegistrarCultivoQueryRequest, RegistrarCultivoQueryResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public RegistrarCultivoQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<RegistrarCultivoQueryResponse> Handle(RegistrarCultivoQueryRequest request, CancellationToken cancellationToken)
        {
            var cultivo = new Cultivo(request.Nombre, request.FechaSiembra);
            _palmAppUnitOfWork.CultivoRepository.Add(cultivo);
            return Task.FromResult(new RegistrarCultivoQueryResponse(cultivo.Id));
        }
    }
    public class RegistrarCultivoQueryRequest : IRequest<RegistrarCultivoQueryResponse>
    {
        public RegistrarCultivoQueryRequest(string nombre, DateTime fechaSiembra)
        {
            Nombre = nombre;
            FechaSiembra = fechaSiembra;
        }

        public string Nombre { get; set; }
        public DateTime FechaSiembra { get; set; }
    }
    public class RegistrarCultivoQueryResponse
    {
        public RegistrarCultivoQueryResponse(long cultivoRegistradoId)
        {
            CultivoRegistradoId = cultivoRegistradoId;
            Mensaje = "Operación realizada correctamente";

        }
        public string Mensaje { get; set; }
        public long CultivoRegistradoId { get; set; }
    }
}
