namespace MapeamentoDtos.Clientes;

public static class ClientePatch
{
    // Aplica somente o que veio; a validação continua no domínio.
    public static void Aplicar(
        this Cliente cliente, AtualizarClienteDto dto)
    {
        if (dto.Nome is not null)
            cliente.AlterarNome(dto.Nome);

        if (dto.Email is not null)
            cliente.AlterarEmail(dto.Email);
    }
}
