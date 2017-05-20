using System;

namespace ReactiveSearch.Services.Disconnected
{
    public class DisconnectedErrorException : Exception
    {
        public DisconnectedErrorException()
        {
        }

        public DisconnectedErrorException(string message) : base(message)
        {
        }

        public DisconnectedErrorException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}