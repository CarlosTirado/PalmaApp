using Domain.Base;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataInFile.Lotes
{
    public class LoteInFileRepository : ILoteRepository
    {
        private readonly StreamReader _fileData;

        public LoteInFileRepository(StreamReader fileData)
        {
            _fileData = fileData;
        }

        public Lote Get(ISpecification<Lote> especificacion)
        {
            /// Logica de consultar un Lote en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new Lote(cultivoId: 1, nombre: "Lote_Fake 1", numeroHectareas: 3);
        }

        public ICollection<Lote> Gets(ISpecification<Lote> especificacion)
        {
            /// Logica de consultar una lista de Lote en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new List<Lote>()
            {
                new Lote(1, "Lote_Fake 1", 5),
                new Lote(1, "Lote_Fake 2", 5),
                new Lote(1, "Lote_Fake 3", 5)
            };
        }
    }
}
