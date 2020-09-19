using Domain.Base;
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
            var Lote = _palmAppUnitOfWork.LoteRepository.Get(request.LoteId);

            Lote.Editar(request.Nombre, request.NumeroHectareas, request.Estado);
            _palmAppUnitOfWork.Commit();
            return Task.FromResult(new EditarLoteResponse(Lote.Id));
        }
    }
    public class EditarLoteRequest : IRequest<EditarLoteResponse>
    {
        public long LoteId { get; set; }
        public string Nombre { get; set; }
        public int NumeroHectareas { get; set; }
        public string Estado { get; set; }
    }
    public class EditarLoteResponse
    {
        public EditarLoteResponse(long loteEditadoId)
        {
            LoteEditadoId = loteEditadoId;
            Mensaje = "Operación realizada correctamente";
        }

        public long LoteEditadoId { get; set; }
        public string Mensaje { get; set; }
    }
}
