using Domain.Base;
using Domain.Cultivos;
using Domain.Lotes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Lotes
{
    public class EditarLoteQuery : IRequestHandler<EditarLoteRequest, EditarLoteResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public EditarLoteQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<EditarLoteResponse> Handle(EditarLoteRequest request, CancellationToken cancellationToken)
        {
            var cultivo = _palmAppUnitOfWork.CultivoRepository.Get(new ConsultaCultivoPorIdSpecification(request.CultivoId));
            if(cultivo == null)
            {
                return Task.FromResult(new EditarLoteResponse("No se ha podido encontrar el Cultivo que contenga ese Lote"));
            }

            var lote = cultivo.Lotes.FirstOrDefault(t => t.Id == request.LoteId);
            if (lote == null)
            {
                return Task.FromResult(new EditarLoteResponse("No se ha podido encontrar el Lote que intenta editar"));
            }

            lote.Editar(request.Nombre, request.NumeroHectareas, request.Estado);

            _palmAppUnitOfWork.Commit();

            return Task.FromResult(new EditarLoteResponse(lote.Id));
        }
    }
    public class EditarLoteRequest : IRequest<EditarLoteResponse>
    {
        public long CultivoId { get; set; }
        public long LoteId { get; set; }
        public string Nombre { get; set; }
        public decimal NumeroHectareas { get; set; }
        public string Estado { get; set; }
    }
    public class EditarLoteResponse
    {
        public EditarLoteResponse(long loteEditadoId)
        {
            LoteEditadoId = loteEditadoId;
            Mensaje = "Operación realizada correctamente";
        }

        public EditarLoteResponse(string mensajeError)
        {
            Mensaje = mensajeError;
        }

        public long LoteEditadoId { get; set; }
        public string Mensaje { get; set; }
    }
}
