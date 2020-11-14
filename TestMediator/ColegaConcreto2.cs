using System;

namespace TestMediator
{
    public class ColegaConcreto2 : Colega
    {
        public ColegaConcreto2(IMediator m) 
        {
            mediador = m;
            mediador.agregarColega(this);
        }
        
        public override void recibir(string mensaje)
        {
            Console.WriteLine("ColegaConcreto2 recibe mensaje: " + mensaje + " --> Realiza operaciones necesarias");
        }
    }
}