using System;

namespace Flyon.Domain.DomainExceptions
{
    public class InvalidOfferCityException : Exception
    {
        public InvalidOfferCityException(): base(ModifyMessage())
        {
        }
        
        private static string ModifyMessage()
        {
            return $"You have to provide a city name.";
        }
    }
}