using MapeamentoDtos.Pedidos;

namespace MapeamentoDtos.Tests;

public class PedidoMapeamentosTests
{
    [Fact]
    public void Deve_mapear_itens_e_calcular_total()
    {
        var dto = new CriarPedidoDto(Guid.NewGuid(),
        [
            new(" Café ", 2, 10m),
            new("Pão", 1, 5m),
        ]);

        var pedido = dto.ParaDominio();

        Assert.Equal(2, pedido.Itens.Count);
        Assert.Equal("Café", pedido.Itens[0].Produto);
        Assert.Equal(25m, pedido.Total);
    }

    [Fact]
    public void Deve_falhar_com_quantidade_invalida()
    {
        var dto = new CriarPedidoDto(Guid.NewGuid(),
            [new("Café", 0, 10m)]);

        Assert.Throws<ArgumentException>(() => dto.ParaDominio());
    }

    [Fact]
    public void Deve_falhar_sem_itens()
    {
        var dto = new CriarPedidoDto(Guid.NewGuid(), []);

        Assert.Throws<ArgumentException>(() => dto.ParaDominio());
    }
}
