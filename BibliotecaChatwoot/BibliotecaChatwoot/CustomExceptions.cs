using System;

namespace BibliotecaChatwoot
{
    internal class CustomExceptions : Exception
    {
        public CustomExceptions(string message) : base(message) { }
    }
}
