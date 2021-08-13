using Domain.Base;
using Domain.Palmas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Palmas
{
    public class EditarPalmaQuery : IRequestHandler<EditarPalmaRequest, EditarPalmaResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public EditarPalmaQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<EditarPalmaResponse> Handle(EditarPalmaRequest request, CancellationToken cancellationToken)
        {
            var Palma = _palmAppUnitOfWork.PalmaRepository.Get(new ConsultaPalmaPorIdSpecification(request.PalmaId));

            Palma.Editar(request.Altura, request.Descripcion, request.FechaSiembra, request.Estado);

            _palmAppUnitOfWork.Commit();

            return Task.FromResult(new EditarPalmaResponse(Palma.Id));
        }
    }
    public class EditarPalmaRequest : IRequest<EditarPalmaResponse>
    {
        public long PalmaId { get; set; }
        public decimal Altura { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaSiembra { get; set; }
        public string Estado { get; set; }
    }
    public class EditarPalmaResponse
    {
        public EditarPalmaResponse(long palmaEditadoId)
        {
            PalmaEditadoId = palmaEditadoId;
            Mensaje = "Operación realizada correctamente";
        }

        public long PalmaEditadoId { get; set; }
        public string Mensaje { get; set; }
    }
}
