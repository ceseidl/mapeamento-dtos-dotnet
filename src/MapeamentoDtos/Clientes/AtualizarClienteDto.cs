namespace MapeamentoDtos.Clientes;

// DTO de atualização parcial (PATCH): null significa "não altera".
public sealed record AtualizarClienteDto(
    string? Nome,
    string? Email);
