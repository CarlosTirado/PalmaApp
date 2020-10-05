using Domain.Tareas;
using Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aplication.Tareas.ModelView;

namespace Aplication.Tareas
{
    public class ConsultarTareasQuery : IRequestHandler<ConsultarTareasRequest, ConsultarTareasResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarTareasQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarTareasResponse> Handle(ConsultarTareasRequest request, CancellationToken cancellationToken)
        {
            var tareas = _palmAppUnitOfWork.TareaRepository.Gets();
            var tareasView = tareas.Select(t => new TareaModelView()
            {
                Id = t.Id,
                Estado = t.Estado,
                Descripcion = t.Descripcion,
                Nombre = t.Nombre
            }).ToList();

            return Task.FromResult(new ConsultarTareasResponse(tareasView));
        }
    }

    public class ConsultarTareasRequest : IRequest<ConsultarTareasResponse>
    {
    }

    public class ConsultarTareasResponse
    {
        public ConsultarTareasResponse(List<TareaModelView> tareas)
        {
            Tareas = tareas;
        }

        public List<TareaModelView> Tareas { get; set; }
    }
}
