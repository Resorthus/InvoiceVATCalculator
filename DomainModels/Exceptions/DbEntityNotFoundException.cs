using DomainModels.Entities;
using System.Net;

namespace DomainModels.Exceptions
{
    public class DbEntityNotFoundException : Exception 
    {
        public string customMessage { get; set; }

        public DbEntityNotFoundException(string message)
        {
            customMessage = message;
        }

        public override string Message
        {
            get
            {
                return customMessage;
            }
        }
    }
}
