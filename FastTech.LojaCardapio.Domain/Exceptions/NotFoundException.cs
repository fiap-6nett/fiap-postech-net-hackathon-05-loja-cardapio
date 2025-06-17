using System.Net;

namespace FastTech.LojaCardapio.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
        public NotFoundException(string message) : base(message) { }
    }
}
