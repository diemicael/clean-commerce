# Projeto de Exemplo - ASP.NET com Arquitetura Limpa

Este repositório serve como um exemplo para futuras referências ao criar novos projetos. Ele implementa uma solução baseada em ASP.NET utilizando Arquitetura Limpa, CQRS, FluentValidation, AutoMapper, Entity Framework e PostgreSQL.

## Tecnologias Utilizadas
- **ASP.NET Core** - Framework para desenvolvimento web.
- **Arquitetura Limpa** - Padrão de arquitetura para separação de responsabilidades.
- **CQRS (Command Query Responsibility Segregation)** - Padrão para separação de leitura e escrita.
- **FluentValidation** - Biblioteca para validação de dados.
- **AutoMapper** - Mapeamento de objetos.
- **Entity Framework Core** - ORM para interação com banco de dados.
- **PostgreSQL** - Banco de dados relacional.

## Estrutura do Projeto
A solução segue o padrão de Arquitetura Limpa e está organizada da seguinte forma:

- **Application** - Contém as regras de negócio, use cases e validadores.
- **Domain** - Definição das entidades e interfaces.
- **Infrastructure** - Implementação da persistência, repositórios e integração com banco de dados.
- **Presentation** - API ou interface de comunicação.
- **Tests** - Testes unitários e de integração.

## Configuração e Execução
### 1. Clonar o Repositório
```sh
git clone https://github.com/diemicael/clean-commerce.git
cd cleancommerce
```

### 2. Configurar o Banco de Dados
Certifique-se de ter o PostgreSQL instalado e rodando. Atualize a string de conexão no arquivo `appsettings.json`.

```json
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=cleancommerce;Username=postgres;Password=sua-senha"
  },
```

Rodar as migrações:
```sh
dotnet ef database update --project CleanCommerce.Infrastructure --startup-project CleanCommerce.API
```

### 3. Executar o Projeto
```sh
Para rodar o projeto você pode usar o swagger
```
A API estará disponível em `http://localhost:5228/swagger/index.html`.

## Contribuição
Sinta-se à vontade para abrir issues e pull requests para melhorias.
