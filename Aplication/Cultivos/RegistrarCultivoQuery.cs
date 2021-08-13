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
    public class RegistrarCultivoQuery : IRequestHandler<RegistrarCultivoRequest, RegistrarCultivoResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public RegistrarCultivoQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<RegistrarCultivoResponse> Handle(RegistrarCultivoRequest request, CancellationToken cancellationToken)
        {
            var cultivo = new Cultivo(request.Nombre, request.FechaSiembra);
            _palmAppUnitOfWork.CultivoRepository.Add(cultivo);
            _palmAppUnitOfWork.Commit();
            return Task.FromResult(new RegistrarCultivoResponse(cultivo.Id));
        }
    }
    public class RegistrarCultivoRequest : IRequest<RegistrarCultivoResponse>
    {
        public RegistrarCultivoRequest() { }
        public RegistrarCultivoRequest(string nombre, DateTime fechaSiembra)
        {
            Nombre = nombre;
            FechaSiembra = fechaSiembra;
        }

        public string Nombre { get; set; }
        public DateTime FechaSiembra { get; set; }
    }
    public class RegistrarCultivoResponse
    {
        public RegistrarCultivoResponse(long cultivoRegistradoId)
        {
            CultivoRegistradoId = cultivoRegistradoId;
            Mensaje = "Operación realizada correctamente";

        }
        public string Mensaje { get; set; }
        public long CultivoRegistradoId { get; set; }
    }
}
