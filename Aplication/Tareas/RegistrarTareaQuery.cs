using Aplication.Tareas.ModelView;
using Domain.Base;
using MediatR;
using Domain.Tareas;
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
            var tarea = new Tarea(request.Nombre, request.Descripcion);
            _palmAppUnitOfWork.TareaRepository.Add(tarea);
            _palmAppUnitOfWork.Commit();
            return Task.FromResult(new RegistrarTareaResponse(tarea.Id));
        }
    }
    public class RegistrarTareaRequest : IRequest<RegistrarTareaResponse>
    {
        public RegistrarTareaRequest(){}

        public RegistrarTareaRequest(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
        public string Nombre { get;  set; }
        public string Descripcion { get;  set; }
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
