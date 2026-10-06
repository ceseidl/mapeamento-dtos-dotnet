namespace MapeamentoDtos.Pedidos;

public sealed class Pedido
{
    private readonly List<ItemPedido> _itens = new();

    public Guid Id { get; } = Guid.NewGuid();
    public Guid ClienteId { get; }
    public IReadOnlyList<ItemPedido> Itens => _itens;
    public decimal Total => _itens.Sum(i => i.Subtotal);

    public Pedido(Guid clienteId, IEnumerable<ItemPedido> itens)
    {
        ClienteId = clienteId;
        _itens.AddRange(itens);
        if (_itens.Count == 0)
            throw new ArgumentException("Pedido sem itens.");
    }
}

public sealed record ItemPedido(
    string Produto, int Quantidade, decimal PrecoUnitario)
{
    public decimal Subtotal => Quantidade * PrecoUnitario;
}
