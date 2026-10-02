<div align="center">

# ⚙️ TaskPulse

**API de gerenciamento de tarefas de alta performance desenvolvida em .NET 10, estruturada com Clean Architecture e CQRS.**

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-blue?style=flat-square)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
[![Pattern](https://img.shields.io/badge/Pattern-CQRS%20%2F%20MediatR-orange?style=flat-square)](https://github.com/jbogard/MediatR)
[![Tests](https://img.shields.io/badge/Tests-xUnit-success?style=flat-square&logo=dotnet&logoColor=white)](https://xunit.net/)

</div>

---

## ⚙️ Sobre o Projeto

O **TaskPulse** é um projeto robusto de backend criado para explorar e aplicar as melhores práticas de desenvolvimento de software moderno em ecossistemas C#. Focado em manutenibilidade, testabilidade e baixo acoplamento, o sistema implementa um CRUD completo de tarefas utilizando o padrão **CQRS** com **MediatR** e princípios de **Domain-Driven Design (DDD)** para o encapsulamento de regras de negócio.

---

## ⚙️ Tecnologias e Padrões

* **Linguagem:** C# (.NET 10)
* **Arquitetura:** Clean Architecture (Domain, Application, Infrastructure, Api)
* **Padrões:** CQRS, Mediator Pattern, Domain Encapsulation
* **Bibliotecas & Ferramentas:**
  * **MediatR** (Desacoplamento de comandos e consultas)
  * **Entity Framework Core** (ORM e persistência de dados)
  * **FluentAssertions** (Testes expressivos e legíveis)
  * **xUnit** (Framework de testes unitários)

---

## ⚙️ Estrutura da Solução

```text
TaskPulse/
│
├── src/
│   ├── TaskPulse.Domain/         # Entidades de negócio, Enums e regras centrais
│   ├── TaskPulse.Application/    # Casos de uso (Commands, Queries, Handlers e DTOs)
│   ├── TaskPulse.Infrastructure/ # Configurações de persistência e EF Core
│   └── TaskPulse.Api/            # Minimal APIs, Endpoints e Injeção de Dependência
│
└── TaskPulse.UnitTests/          # Projeto de testes unitários (xUnit)

```

## ⚙️ Como Executar Localmente

### Pré-requisitos
* Ter o [.NET 10 SDK](https://dotnet.microsoft.com/) instalado na máquina.

### Passos:

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/LucasSilva1717/Task-Pulsev2.git
   cd TaskPulse
   ```
2. **Restaure as dependências e compile o projeto:**
   ```bash
   dotnet restore
   dotnet build
   ```
3. **Execute a aplicação:**
   ```bash
   dotnet run --project src/TaskPulse.Api/TaskPulse.Api.csproj
   ```
