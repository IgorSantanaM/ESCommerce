using ESCommerce.Domain.Core.Model;

namespace ESCommerce.Domain.Products
{
    public class Variation : Entity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public Category Category { get; set; } = Category.None;
        public string SKU { get; set; } = string.Empty;

        public bool IsValid(string name, Category category, string sku)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(sku)) return false;
            if(category == Category.None) return false;

            return true;
        }
    }
}