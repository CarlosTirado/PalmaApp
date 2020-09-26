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
    public class RegistrarPalmaQuery : IRequestHandler<RegistrarPalmaRequest, RegistrarPalmaResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public RegistrarPalmaQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<RegistrarPalmaResponse> Handle(RegistrarPalmaRequest request, CancellationToken cancellationToken)
        {
            var cultivo = _palmAppUnitOfWork.CultivoRepository.Get(request.CultivoId);
            if (cultivo == null)
            {
                return Task.FromResult(new RegistrarPalmaResponse("No se ha podido encontrar el Cultivo que contenga ese Lote"));
            }

            var lote = cultivo.Lotes.FirstOrDefault(t=> t.Id == request.LoteId);
            if (lote == null)
            {
                return Task.FromResult(new RegistrarPalmaResponse("No se ha podido encontrar el Lote al que intenta agregarle la Palma"));
            }

            var palma = new Palma(request.Altura, request.Descripcion, request.FechaSiembra);

            lote.AgregarPalma(palma);

            _palmAppUnitOfWork.Commit();

            return Task.FromResult(new RegistrarPalmaResponse(palma.Id));
        }
    }
    public class RegistrarPalmaRequest : IRequest<RegistrarPalmaResponse>
    {
        public RegistrarPalmaRequest() { }

        public long CultivoId { get; set; }
        public long LoteId { get; set; }
        public decimal Altura { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaSiembra { get; set; }
    }
    public class RegistrarPalmaResponse
    {
        public RegistrarPalmaResponse(long palmaRegistradoId)
        {
            PalmaRegistradoId = palmaRegistradoId;
            Mensaje = "Operación realizada correctamente";

        }

        public RegistrarPalmaResponse(string mensajeError)
        {
            Mensaje = mensajeError;
        }

        public string Mensaje { get; set; }
        public long PalmaRegistradoId { get; set; }
    }
}
