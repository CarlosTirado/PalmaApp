namespace TestMediator
{
    public abstract class Colega
    {
        protected IMediator mediador { get; set; }

        public void comunicar(string mensaje)
        {
            mediador.enviar(mensaje, this);
        }
        
        public abstract void recibir(string mensaje);
    }
}