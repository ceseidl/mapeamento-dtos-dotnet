# Manual DTO Mapping in .NET

Full article: <https://ceseidl.com.br/en/artigos/mapear-dtos-manualmente/>

English | [Português](README.pt-BR.md)

[![CI](https://github.com/ceseidl/mapeamento-dtos-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/ceseidl/mapeamento-dtos-dotnet/actions/workflows/ci.yml) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

> **Quick start**

```bash
dotnet test
```

Needs only the .NET 10 SDK.

Runnable code from the article **"Como Mapear DTOs Manualmente em .NET — Parte 3"**: manual mapping beyond copying properties, with no mapping library.

- **Invariants in the domain**: the DTO only carries data; `Cliente` validates and normalizes.
- **Nested objects and collections**: `Pedido` with `ItemPedido`.
- **Partial update (PATCH)**: `null` means "do not change".
- **Domain to response DTO**: simple, explicit mapping.
- **Organized by feature** (`Clientes/`, `Pedidos/`) and **tested** with xUnit.

## Projects

```
src/MapeamentoDtos/
├── Clientes/
│   ├── CriarClienteDto.cs              # input DTO
│   ├── Cliente.cs                      # entity with invariants
│   ├── ClienteMapeamentos.cs           # DTO -> domain
│   ├── AtualizarClienteDto.cs          # PATCH
│   ├── ClientePatch.cs                 # apply patch
│   ├── ClienteRespostaDto.cs
│   └── ClienteRespostaMapeamentos.cs   # domain -> response
└── Pedidos/
    ├── CriarPedidoDto.cs               # create DTOs + nested items
    ├── Pedido.cs
    └── PedidoMapeamentos.cs
tests/MapeamentoDtos.Tests/             # xUnit
```

## Run

```bash
dotnet build
dotnet test
```

## Things worth knowing

- **Do not overwrite with `null`.** `ClientePatch.Aplicar` only touches the fields that came in; validation stays in the domain.
- **Keep mappings close to the type and use case** (feature folder) instead of one giant `Mapeamentos.cs`.
- **Mapping is code, so test it**: normalization, defaults, collections and patch.
- The `Cliente` entity is mutable for clarity. With a fully immutable domain, return a new instance instead.

## License

[MIT](LICENSE). Author: Carlos Eduardo Seidl.
