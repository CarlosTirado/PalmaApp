using Aplication.Tareas.ModelView;
using Domain.Base;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Tareas
{
    public class ConsultarTareaPorIdQuery : IRequestHandler<ConsultarTareaPorIdRequest, ConsultarTareaPorIdResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public ConsultarTareaPorIdQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<ConsultarTareaPorIdResponse> Handle(ConsultarTareaPorIdRequest request, CancellationToken cancellationToken)
        {
            var tarea = _palmAppUnitOfWork.TareaRepository.Get(request.TareaId);
            var tareaView = new TareaModelView()
            {
                Id = tarea.Id,
                Estado = tarea.Estado,
                Descripcion = tarea.Descripcion,
                Nombre = tarea.Nombre,
                
            };

            return Task.FromResult(new ConsultarTareaPorIdResponse(tareaView));
        }
    }
    public class ConsultarTareaPorIdRequest : IRequest<ConsultarTareaPorIdResponse>
    {
        public long TareaId { get; set; }
    }
    public class ConsultarTareaPorIdResponse
    {
        public ConsultarTareaPorIdResponse(TareaModelView tarea)
        {
            Tarea = tarea;
        }

        public TareaModelView Tarea { get; set; }
    }
}
