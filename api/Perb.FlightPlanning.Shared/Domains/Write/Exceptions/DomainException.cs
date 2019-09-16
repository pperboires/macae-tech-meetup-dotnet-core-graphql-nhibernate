using System;

namespace Perb.FlightPlanning.Shared.Domains.Write.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string code, string message = null) : base(message??code)
        {
            Code = code;
        }
        
        public string Code { get; set; }
    }
}