namespace MapeamentoDtos.Pedidos;

// Objetos aninhados e coleções: cada tipo sabe mapear o seu pedaço.
public static class PedidoMapeamentos
{
    public static ItemPedido ParaDominio(this CriarItemDto dto)
    {
        if (dto.Quantidade <= 0)
            throw new ArgumentException("Quantidade inválida.");
        return new ItemPedido(
            dto.Produto.Trim(),
            dto.Quantidade,
            dto.PrecoUnitario);
    }

    public static Pedido ParaDominio(this CriarPedidoDto dto)
        => new(dto.ClienteId,
               dto.Itens.Select(i => i.ParaDominio()));
}
