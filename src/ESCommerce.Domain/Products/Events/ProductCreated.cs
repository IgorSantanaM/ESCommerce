namespace ESCommerce.Domain.Products.Events
{
    public record ProductCreated(string Name);

    public record ProductFailedToCreate(ProductFailedToCreate.FailReason Reason)
    {
        public enum FailReason
        {
            InvalidName
        }
    }
}
