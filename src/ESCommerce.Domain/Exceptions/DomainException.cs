namespace ESCommerce.Domain.Exceptions
{
    internal class DomainException : Exception
    {
        public DomainException() { }

        public DomainException(string message) : base(message)
        {

        }
    }
}