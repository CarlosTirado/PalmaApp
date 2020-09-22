using Aplication.Palmas.ModelView;
using Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Palmas
{
    public class ConsultarPalmasQuery : IRequestHandler<ConsultarPalmasRequest, ConsultarPalmasResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarPalmasQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarPalmasResponse> Handle(ConsultarPalmasRequest request, CancellationToken cancellationToken)
        {
            var palmas = _palmAppUnitOfWork.PalmaRepository.Gets(request.LoteId);
            var palmasView = palmas.Select(palma  => new PalmaModelView()
            {
                Id = palma.Id,
                Consecutivo = palma.Consecutivo,
                Estado = palma.Estado,
                FechaSiembra = palma.FechaSiembra,
                Descripcion = palma.Descripcion,
                Altura = palma.Altura,
                LoteId = palma.LoteId
            }).ToList();

            return Task.FromResult(new ConsultarPalmasResponse(palmasView));
        }
    }
    public class ConsultarPalmasRequest : IRequest<ConsultarPalmasResponse>
    {
        public long LoteId { get; set; }
    }
    public class ConsultarPalmasResponse
    {
        public ConsultarPalmasResponse(List<PalmaModelView> palmas)
        {
            Palmas = palmas;
        }

        public List<PalmaModelView> Palmas { get; set; }
    }
}
