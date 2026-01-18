using ESCommerce.Domain.Boxes;
using ESCommerce.Domain.Core.Model;

namespace ESCommerce.Domain.Exceptions
{
    [Serializable]
    internal class DomainException : Exception
    {
        public DomainException() { }

        public DomainException(string message) : base(message)
        {
            
        }
    }
}