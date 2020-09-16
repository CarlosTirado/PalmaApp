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
    public class EditarCultivoQuery : IRequestHandler<EditarCultivoQueryRequest, EditarCultivoQueryResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public EditarCultivoQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<EditarCultivoQueryResponse> Handle(EditarCultivoQueryRequest request, CancellationToken cancellationToken)
        {
            var cultivo = _palmAppUnitOfWork.CultivoRepository.Get(request.CultivoId);

            cultivo.Editar(request.Nombre, request.FechaSiembra, request.Estado);

            return Task.FromResult(new EditarCultivoQueryResponse(cultivo.Id));
        }
    }
    public class EditarCultivoQueryRequest : IRequest<EditarCultivoQueryResponse>
    {
        public EditarCultivoQueryRequest(long cultivoId, string nombre, DateTime fechaSiembra)
        {
            Nombre = nombre;
            FechaSiembra = fechaSiembra;
            CultivoId = cultivoId;
        }
        public long CultivoId { get; private set; }
        public string Nombre { get; private set; }
        public DateTime FechaSiembra { get; private set; }
        public string Estado { get; private set; }
    }
    public class EditarCultivoQueryResponse
    {
        public EditarCultivoQueryResponse(long cultivoEditadoId)
        {
            CultivoEditadoId = cultivoEditadoId;
            Mensaje = "Operación realizada correctamente";
        }

        public long CultivoEditadoId { get; set; }
        public string Mensaje { get; set; }
    }
}
