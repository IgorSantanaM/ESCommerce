using ESCommerce.Domain.Core.Model;

namespace ESCommerce.Domain.Products
{
    public class Variantion : Entity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; } = Category.None;
        public string SKU { get; set; } = string.Empty;
    }
}