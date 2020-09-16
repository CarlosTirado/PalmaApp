using Aplication.Cultivos.ModelView;
using Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Cultivos
{
    public class ConsultarCultivosQuery : IRequestHandler<ConsultarCultivosQueryRequest, ConsultarCultivosQueryResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarCultivosQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarCultivosQueryResponse> Handle(ConsultarCultivosQueryRequest request, CancellationToken cancellationToken)
        {
            var cultivos = _palmAppUnitOfWork.CultivoRepository.Gets();
            var cultivosView = cultivos.Select(t => new CultivoModelView()
            {
                Id = t.Id,
                Estado = t.Estado,
                FechaSiembra = t.FechaSiembra,
                Nombre = t.Nombre
            }).ToList();

            return Task.FromResult(new ConsultarCultivosQueryResponse(cultivosView));
        }
    }
    public class ConsultarCultivosQueryRequest : IRequest<ConsultarCultivosQueryResponse>
    {
    }
    public class ConsultarCultivosQueryResponse
    {
        public ConsultarCultivosQueryResponse(List<CultivoModelView> cultivos)
        {
            Cultivos = cultivos;
        }

        public List<CultivoModelView> Cultivos { get; set; }
    }
}
