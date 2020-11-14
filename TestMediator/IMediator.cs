using System;

namespace TestMediator
{
    public interface IMediator
    {
        void enviar(string mensaje, Colega emisor);
        void agregarColega(Colega colega);
    }
}