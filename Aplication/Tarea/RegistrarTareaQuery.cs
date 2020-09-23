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
    public class RegistrarTareaQuery : IRequestHandler<RegistrarTareaRequest, RegistrarTareaResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public RegistrarTareaQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<RegistrarTareaResponse> Handle(RegistrarTareaRequest request, CancellationToken cancellationToken)
        {
            var tarea = new Tarea(request.Nombre, request.Descripcion, request.Estado);
            _palmAppUnitOfWork.TareaRepository.Add(tarea);
            _palmAppUnitOfWork.Commit();
            return Task.FromResult(new RegistrarTareaResponse(tarea.Id));
        }
    }
    public class RegistrarTareaRequest : IRequest<RegistrarTareaResponse>
    {
        public RegistrarTareaRequest() { }
        public long Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public string Estado { get; private set; }
    }
    public class RegistrarTareaResponse
    {
        public RegistrarTareaResponse(long tareaRegistradaId)
        {
            TareaRegistradaId = tareaRegistradaId;
            Mensaje = "Operación realizada correctamente";

        }

        public RegistrarTareaResponse(string mensajeError)
        {
            Mensaje = mensajeError;
        }

        public string Mensaje { get; set; }
        public long TareaRegistradaId { get; set; }
    }
}
