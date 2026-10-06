namespace MapeamentoDtos.Clientes;

// DTO -> Domínio: o DTO só fornece dados;
// o domínio garante a integridade.
public static class ClienteMapeamentos
{
    public static Cliente ParaDominio(this CriarClienteDto dto)
        => Cliente.Criar(dto.Nome, dto.Email);
}
