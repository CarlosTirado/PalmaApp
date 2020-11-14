using System;
using System.Collections.Generic;

namespace TestMediator
{
    public class Mediator : IMediator
    {
        private List<Colega> colegas;
        
        public Mediator()
        {
            this.colegas = new List<Colega>();
        }
        
        public void agregarColega(Colega colega)
        {
            this.colegas.Add(colega);
        }
        
        public void enviar(String mensaje, Colega originator)
        {
            foreach (var colega in colegas)
            {
                if( colega != originator )
                {
                    colega.recibir( mensaje );
                }
            }
        }
    }
}
