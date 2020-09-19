using Aplication.Lotes.ModelView;
using Domain.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Lotes
{
    public class ConsultarLotePorIdQuery : IRequestHandler<ConsultarLotePorIdRequest, ConsultarLotePorIdResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarLotePorIdQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarLotePorIdResponse> Handle(ConsultarLotePorIdRequest request, CancellationToken cancellationToken)
        {
            var lote = _palmAppUnitOfWork.CultivoRepository.GetLotePorId(request.LoteId);
            var loteView = new LoteModelView()
            {
                Id = lote.Id,
                CultivoId = lote.CultivoId,
                Estado = lote.Estado,
                NumeroHectareas = lote.NumeroHectareas,
                Nombre = lote.Nombre
            };

            return Task.FromResult(new ConsultarLotePorIdResponse(loteView));
        }
    }
    public class ConsultarLotePorIdRequest : IRequest<ConsultarLotePorIdResponse>
    {
        public long LoteId { get; set; }
    }
    public class ConsultarLotePorIdResponse
    {
        public ConsultarLotePorIdResponse(LoteModelView lote)
        {
            Lote = lote;
        }

        public LoteModelView Lote { get; set; }
    }
}
