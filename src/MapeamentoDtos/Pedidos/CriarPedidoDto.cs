namespace MapeamentoDtos.Pedidos;

public sealed record CriarPedidoDto(
    Guid ClienteId,
    List<CriarItemDto> Itens);

public sealed record CriarItemDto(
    string Produto,
    int Quantidade,
    decimal PrecoUnitario);
