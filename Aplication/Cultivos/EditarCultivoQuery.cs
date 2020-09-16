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
    public class EditarCultivoQuery : IRequestHandler<EditarCultivoRequest, EditarCultivoResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public EditarCultivoQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<EditarCultivoResponse> Handle(EditarCultivoRequest request, CancellationToken cancellationToken)
        {
            var cultivo = _palmAppUnitOfWork.CultivoRepository.Get(request.CultivoId);

            cultivo.Editar(request.Nombre, request.FechaSiembra, request.Estado);

            return Task.FromResult(new EditarCultivoResponse(cultivo.Id));
        }
    }
    public class EditarCultivoRequest : IRequest<EditarCultivoResponse>
    {
        public EditarCultivoRequest(long cultivoId, string nombre, DateTime fechaSiembra)
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
    public class EditarCultivoResponse
    {
        public EditarCultivoResponse(long cultivoEditadoId)
        {
            CultivoEditadoId = cultivoEditadoId;
            Mensaje = "Operación realizada correctamente";
        }

        public long CultivoEditadoId { get; set; }
        public string Mensaje { get; set; }
    }
}
