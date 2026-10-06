# Mapeamento Manual de DTOs em .NET

[English](README.md) | Português

[![CI](https://github.com/ceseidl/mapeamento-dtos-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/ceseidl/mapeamento-dtos-dotnet/actions/workflows/ci.yml) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

> **Início rápido**

```bash
dotnet test
```

Precisa apenas do SDK do .NET 10.

Código executável do artigo **"Como Mapear DTOs Manualmente em .NET — Parte 3"**: mapeamento manual além de copiar propriedades, sem biblioteca de mapeamento.

- **Invariantes no domínio**: o DTO só carrega dados; `Cliente` valida e normaliza.
- **Objetos aninhados e coleções**: `Pedido` com `ItemPedido`.
- **Atualização parcial (PATCH)**: `null` significa "não altera".
- **Domínio para DTO de resposta**: mapeamento simples e explícito.
- **Organizado por feature** (`Clientes/`, `Pedidos/`) e **testado** com xUnit.

## Projetos

```
src/MapeamentoDtos/
├── Clientes/
│   ├── CriarClienteDto.cs              # DTO de entrada
│   ├── Cliente.cs                      # entidade com invariantes
│   ├── ClienteMapeamentos.cs           # DTO -> domínio
│   ├── AtualizarClienteDto.cs          # PATCH
│   ├── ClientePatch.cs                 # aplica o patch
│   ├── ClienteRespostaDto.cs
│   └── ClienteRespostaMapeamentos.cs   # domínio -> resposta
└── Pedidos/
    ├── CriarPedidoDto.cs               # DTOs de criação + itens aninhados
    ├── Pedido.cs
    └── PedidoMapeamentos.cs
tests/MapeamentoDtos.Tests/             # xUnit
```

## Executar

```bash
dotnet build
dotnet test
```

## O que vale saber

- **Não sobrescreva com `null`.** `ClientePatch.Aplicar` só mexe nos campos que vieram; a validação continua no domínio.
- **Mantenha o mapeamento perto do tipo e do caso de uso** (pasta da feature), em vez de um `Mapeamentos.cs` gigante.
- **Mapeamento é código, então teste**: normalização, defaults, coleções e patch.
- A entidade `Cliente` é mutável por clareza. Com um domínio totalmente imutável, retorne uma nova instância.

## Licença

[MIT](LICENSE). Autor: Carlos Eduardo Seidl.
