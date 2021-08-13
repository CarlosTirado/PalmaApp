using Aplication.Palmas.ModelView;
using Aplication.Lotes.ModelView;
using Domain.Base;
using Domain.Lotes;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Palmas;

namespace Aplication.Palmas
{
    public class ConsultarPalmaPorIdQuery : IRequestHandler<ConsultarPalmaPorIdRequest, ConsultarPalmaPorIdResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarPalmaPorIdQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarPalmaPorIdResponse> Handle(ConsultarPalmaPorIdRequest request, CancellationToken cancellationToken)
        {
            var palma = _palmAppUnitOfWork.PalmaRepository.Get(new ConsultaPalmaPorIdSpecification(request.PalmaId));
            var palmaView = new PalmaModelView()
            {
                Id = palma.Id,
                Consecutivo = palma.Consecutivo,
                Estado = palma.Estado,
                FechaSiembra = palma.FechaSiembra,
                Descripcion = palma.Descripcion,
                Altura = palma.Altura,
                LoteId = palma.LoteId
            };

            return Task.FromResult(new ConsultarPalmaPorIdResponse(palmaView));
        }
    }
    public class ConsultarPalmaPorIdRequest : IRequest<ConsultarPalmaPorIdResponse>
    {
        public long PalmaId { get; set; }
    }
    public class ConsultarPalmaPorIdResponse
    {
        public ConsultarPalmaPorIdResponse(PalmaModelView palma)
        {
            Palma = palma;
        }

        public PalmaModelView Palma { get; set; }
    }
}
