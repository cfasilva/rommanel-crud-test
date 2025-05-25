# Rommanel CRUD Test

Este projeto é uma aplicação full stack desenvolvida para demonstrar um CRUD completo para fins avaliativos.

## Tecnologias Utilizadas

### Backend (.NET 8 + SQL Server)
- **ASP.NET Core 8.0**: Framework robusto para construção de APIs REST, com alta performance e suporte a injeção de dependência, validação e versionamento.
- **Entity Framework Core 8**: ORM para facilitar o mapeamento objeto-relacional, abstraindo queries SQL e facilitando a manutenção do código.
- **SQL Server (Docker)**: Banco de dados relacional amplamente utilizado no mercado corporativo, executado em container para facilitar o setup e portabilidade.
- **FluentValidation**: Biblioteca para validação de dados de entrada, promovendo regras de negócio claras e reutilizáveis.
- **xUnit + Moq**: Frameworks de testes unitários e mocks, garantindo qualidade e confiabilidade do código.
- **Swagger (Swashbuckle)**: Geração automática de documentação interativa da API, facilitando testes e integração com outros sistemas.
- **Docker**: Empacotamento e execução do backend em containers, garantindo ambiente padronizado e fácil deploy.

### Frontend (Angular 18)
- **Angular 18**: Framework moderno para construção de SPAs, com arquitetura modular, tipagem forte (TypeScript) e excelente integração com Material Design.
- **Angular Material**: Biblioteca de componentes visuais seguindo o Material Design, proporcionando UI moderna, responsiva e acessível.
- **SCSS**: Pré-processador CSS para facilitar a organização e reutilização de estilos.
- **Docker**: Containerização do frontend para garantir ambiente consistente e facilitar o deploy.

### Orquestração
- **Docker Compose**: Orquestração dos containers (banco, backend e frontend), simplificando o setup do ambiente de desenvolvimento e produção.

## Estrutura do Projeto
- `server/`: Código-fonte do backend (API, domínio, infraestrutura, serviços e testes).
- `client/`: Código-fonte do frontend (Angular).
- `docker-compose.yml`: Orquestração dos serviços (db, server, client).

## Por que essas escolhas?
- **.NET + EF Core**: Permite desenvolvimento rápido, seguro e escalável de APIs, com excelente suporte a testes e integração com SQL Server.
- **Angular + Material**: Proporciona desenvolvimento de interfaces ricas, responsivas e com ótima experiência do usuário.
- **Docker**: Facilita o setup, deploy e escalabilidade, eliminando problemas de "funciona na minha máquina".
- **Testes Automatizados**: Garantem qualidade, facilitam refatorações e reduzem bugs em produção.
- **Validação e Documentação**: FluentValidation e Swagger tornam a API mais robusta, segura e fácil de consumir.

## Como executar o projeto

1. **Pré-requisitos:**
   - Docker e Docker Compose instalados

2. **Subir todos os serviços:**
   ```sh
   docker-compose up --build
   ```
   - O frontend estará disponível em: http://localhost:4200
   - A API estará disponível em: http://localhost:5050
   - O banco de dados SQL Server estará rodando na porta 1433

3. **Testes:**
   - Os testes unitários do backend podem ser executados via Visual Studio, Rider ou CLI do .NET.

## Observações
- O projeto está pronto para ser expandido, com separação clara de camadas e boas práticas de programação.
- Segue os princípios SOLID, DDD, TDD e CQRS para aplicações que utilizam arquitetura de microserviços.

---

Desenvolvido com ❤️ para o desafio Rommanel.
