﻿using Domain.Base;
using Domain.Lotes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Lotes
{
    public class RegistrarLoteQuery : IRequestHandler<RegistrarLoteRequest, RegistrarLoteResponse>
    {
        private readonly IPalmAppUnitOfWork _palmAppUnitOfWork;
        public RegistrarLoteQuery(
            IPalmAppUnitOfWork palmAppUnitOfWork)
        {
            _palmAppUnitOfWork = palmAppUnitOfWork;
        }

        public Task<RegistrarLoteResponse> Handle(RegistrarLoteRequest request, CancellationToken cancellationToken)
        {
            var lote = new Lote(request.CultivoId, request.Nombre, request.NumeroHectareas);
            _palmAppUnitOfWork.LoteRepository.Add(lote);
            _palmAppUnitOfWork.Commit();
            return Task.FromResult(new RegistrarLoteResponse(lote.Id));
        }
    }
    public class RegistrarLoteRequest : IRequest<RegistrarLoteResponse>
    {
        public RegistrarLoteRequest() { }
        public RegistrarLoteRequest(long cultivoId, string nombre, int numeroHectareas)
        {
            CultivoId = cultivoId;
            Nombre = nombre;
            NumeroHectareas = numeroHectareas;
        }

        public long CultivoId { get; set; }
        public string Nombre { get; set; }
        public int NumeroHectareas { get; set; }
    }
    public class RegistrarLoteResponse
    {
        public RegistrarLoteResponse(long loteRegistradoId)
        {
            LoteRegistradoId = loteRegistradoId;
            Mensaje = "Operación realizada correctamente";

        }
        public string Mensaje { get; set; }
        public long LoteRegistradoId { get; set; }
    }
}
