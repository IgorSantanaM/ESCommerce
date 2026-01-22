using ESCommerce.Domain.Products;

namespace ESCommerce.QueryAPI.DTOs
{
    public record VariationDTO(Guid? Id, string? Name, string? Description, Category? Category, string? SKU);
}
