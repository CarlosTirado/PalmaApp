using System;

namespace TestMediator
{
    public class ColegaConcreto1 : Colega
    {
        public ColegaConcreto1(IMediator m)
        {
            mediador = m;
            mediador.agregarColega(this);
        }
        
        public override void recibir(string mensaje)
        {
            Console.WriteLine("ColegaConcreto1 recibe mensaje: " + mensaje + " --> Realiza operaciones necesarias");
        }
    }
}