namespace CartAPI.Dtos
{
    public record CartDto(Guid Id, Guid ProductId, string ProductName, int QuantityOrdered, double unitprice);

    public record CreateCartDto(Guid ProductId, string ProductName, int QuantityOrdered, double unitprice);

    public record UpdateCartDto(string ProductName, int QuantityUpdate, double unitprice);
}
