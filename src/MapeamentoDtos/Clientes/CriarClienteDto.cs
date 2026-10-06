namespace MapeamentoDtos.Clientes;

// DTO de entrada: o que veio da borda (API, UI, mensagem).
// Só carrega dados, sem regra de negócio.
public sealed record CriarClienteDto(string? Nome, string? Email);
