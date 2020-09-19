using Aplication.Lotes.ModelView;
using Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Lotes
{
    public class ConsultarLotesQuery : IRequestHandler<ConsultarLotesRequest, ConsultarLotesResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarLotesQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarLotesResponse> Handle(ConsultarLotesRequest request, CancellationToken cancellationToken)
        {
            var lotes = _palmAppUnitOfWork.LoteRepository.Gets();
            var lotesView = lotes.Select(t => new LoteModelView()
            {
                Id = t.Id,
                CultivoId = t.CultivoId,
                Estado = t.Estado,
                NumeroHectareas = t.NumeroHectareas,
                Nombre = t.Nombre
            }).ToList();

            return Task.FromResult(new ConsultarLotesResponse(lotesView));
        }
    }
    public class ConsultarLotesRequest : IRequest<ConsultarLotesResponse>
    {
    }
    public class ConsultarLotesResponse
    {
        public ConsultarLotesResponse(List<LoteModelView> lotes)
        {
            Lotes = lotes;
        }

        public List<LoteModelView> Lotes { get; set; }
    }
}
