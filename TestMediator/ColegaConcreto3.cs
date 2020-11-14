using System;

namespace TestMediator
{
    public class ColegaConcreto3 : Colega
    {
        public ColegaConcreto3(IMediator m) 
        {
            mediador = m;
            mediador.agregarColega(this);
        }
        
        public override void recibir(string mensaje)
        {
            Console.WriteLine("ColegaConcreto3 recibe mensaje: " + mensaje + " --> Realiza operaciones necesarias");
        }
    }
}