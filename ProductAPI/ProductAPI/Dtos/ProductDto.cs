using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Dtos
{
    public record ProductDto(Guid Id, string productName, int quantity, double unitprice);

    public record CUProductDto([Required] string productName, [Range(0, int.MaxValue)] int quantity, double unitprice);
}
