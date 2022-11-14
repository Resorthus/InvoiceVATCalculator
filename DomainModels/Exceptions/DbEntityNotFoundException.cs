using DomainModels.Entities;
using System.Net;

namespace DomainModels.Exceptions
{
    public class DbEntityNotFoundException<T> : Exception 
        where T : Entity
    {
        public HttpStatusCode StatusCode = HttpStatusCode.NotFound;

        public string Message { get; set; }

        public DbEntityNotFoundException(int id)
        {
            Message = $"{typeof(T).Name} entry {id} not found";
        }
    }
}
