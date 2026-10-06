namespace MapeamentoDtos.Clientes;

// Entidade (mutável, por clareza) que garante as invariantes:
// nome obrigatório e e-mail válido.
// Os valores também são normalizados aqui.
public sealed class Cliente
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Nome { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public static Cliente Criar(string? nome, string? email)
    {
        var c = new Cliente();
        c.AlterarNome(nome);
        c.AlterarEmail(email);
        return c;
    }

    public void AlterarNome(string? nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório.");
        Nome = nome.Trim();
    }

    public void AlterarEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email)
            || !email.Contains('@'))
            throw new ArgumentException("E-mail inválido.");
        Email = email.Trim().ToLowerInvariant();
    }
}
