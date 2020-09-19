using Aplication.Cultivos.ModelView;
using Aplication.Lotes.ModelView;
using Domain.Base;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Cultivos
{
    public class ConsultarCultivoPorIdQuery : IRequestHandler<ConsultarCultivoPorIdRequest, ConsultarCultivoPorIdResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarCultivoPorIdQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarCultivoPorIdResponse> Handle(ConsultarCultivoPorIdRequest request, CancellationToken cancellationToken)
        {
            var cultivo = _palmAppUnitOfWork.CultivoRepository.Get(request.CultivoId);
            var cultivoView = new CultivoModelView()
            {
                Id = cultivo.Id,
                Estado = cultivo.Estado,
                FechaSiembra = cultivo.FechaSiembra,
                Nombre = cultivo.Nombre,
                Lotes = cultivo.Lotes.Select(t=> new LoteModelView()
                {
                    Id = t.Id,
                    Estado = t.Estado,
                    Nombre = t.Nombre,
                    NumeroHectareas = t.NumeroHectareas
                }).ToList()
            };

            return Task.FromResult(new ConsultarCultivoPorIdResponse(cultivoView));
        }
    }
    public class ConsultarCultivoPorIdRequest : IRequest<ConsultarCultivoPorIdResponse>
    {
        public long CultivoId { get; set; }
    }
    public class ConsultarCultivoPorIdResponse
    {
        public ConsultarCultivoPorIdResponse(CultivoModelView cultivo)
        {
            Cultivo = cultivo;
        }

        public CultivoModelView Cultivo { get; set; }
    }
}
