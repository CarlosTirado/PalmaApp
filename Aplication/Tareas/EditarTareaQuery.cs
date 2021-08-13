using Domain.Base;
using Domain.Tareas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Tareas
{
    public class EditarTareaQuery : IRequestHandler<EditarTareaRequest, EditarTareaResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public EditarTareaQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<EditarTareaResponse> Handle(EditarTareaRequest request, CancellationToken cancellationToken)
        {
            var tarea = _palmAppUnitOfWork.TareaRepository.Get(new ConsultaTareaPorIdSpecification(request.TareaId));

            tarea.Editar(request.Nombre, request.Descripcion, request.Estado);
            _palmAppUnitOfWork.Commit();
            return Task.FromResult(new EditarTareaResponse(tarea.Id));
        }
    }
    public class EditarTareaRequest : IRequest<EditarTareaResponse>
    {
        public long TareaId { get; set; }
        public string Nombre { get; set; }        
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
    public class EditarTareaResponse
    {
        public EditarTareaResponse(long tareaEditadaId)
        {
            TareaEditadaId = tareaEditadaId;
            Mensaje = "Operación realizada correctamente";
        }

        public long TareaEditadaId { get; set; }
        public string Mensaje { get; set; }
    }
}
