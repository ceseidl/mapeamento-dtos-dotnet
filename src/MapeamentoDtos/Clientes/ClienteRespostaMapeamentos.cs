namespace MapeamentoDtos.Clientes;

// Domínio -> DTO de resposta: simples, explícito e rápido.
public static class ClienteRespostaMapeamentos
{
    public static ClienteRespostaDto ParaResposta(this Cliente c)
        => new(c.Id, c.Nome, c.Email);

    public static List<ClienteRespostaDto> ParaResposta(
        this IEnumerable<Cliente> clientes)
        => clientes.Select(c => c.ParaResposta()).ToList();
}
