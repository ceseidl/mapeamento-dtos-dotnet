using MapeamentoDtos.Clientes;

namespace MapeamentoDtos.Tests;

public class ClienteMapeamentosTests
{
    [Fact]
    public void Deve_normalizar_nome_e_email()
    {
        var dto = new CriarClienteDto(
            "  Ana Souza ", " ANA@Mail.com ");

        var cliente = dto.ParaDominio();

        Assert.Equal("Ana Souza", cliente.Nome);
        Assert.Equal("ana@mail.com", cliente.Email);
    }

    [Fact]
    public void Deve_falhar_sem_nome()
    {
        var dto = new CriarClienteDto(" ", "ana@mail.com");

        Assert.Throws<ArgumentException>(() => dto.ParaDominio());
    }

    [Fact]
    public void Deve_falhar_com_email_invalido()
    {
        var dto = new CriarClienteDto("Ana", "ana.mail.com");

        Assert.Throws<ArgumentException>(() => dto.ParaDominio());
    }

    [Fact]
    public void Patch_com_null_nao_altera()
    {
        var cliente = Cliente.Criar("Ana", "ana@mail.com");

        cliente.Aplicar(new AtualizarClienteDto(null, null));

        Assert.Equal("Ana", cliente.Nome);
        Assert.Equal("ana@mail.com", cliente.Email);
    }

    [Fact]
    public void Patch_altera_somente_o_que_veio()
    {
        var cliente = Cliente.Criar("Ana", "ana@mail.com");

        cliente.Aplicar(
            new AtualizarClienteDto("Ana Souza", null));

        Assert.Equal("Ana Souza", cliente.Nome);
        Assert.Equal("ana@mail.com", cliente.Email);
    }

    [Fact]
    public void Resposta_espelha_o_dominio()
    {
        var cliente = Cliente.Criar("Ana", "ana@mail.com");

        var resposta = cliente.ParaResposta();

        Assert.Equal(cliente.Id, resposta.Id);
        Assert.Equal("Ana", resposta.Nome);
    }
}
