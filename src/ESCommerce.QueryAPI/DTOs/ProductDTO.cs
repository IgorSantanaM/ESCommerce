namespace ESCommerce.QueryAPI.DTOs
{
    public record ProductDTO(Guid Id, string Name, string ImageUrl, IEnumerable<VariationDTO> Variations );
}
