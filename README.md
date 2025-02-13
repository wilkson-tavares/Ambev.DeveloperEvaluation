# Developer Evaluation Project

API (CRUD completo) que manipula registros de vendas. A API precisa ser capaz de informar:

- Número de venda
- Data em que a venda foi realizada
- Cliente
- Valor total da venda
- Filial onde foi efetuada a venda
- Produtos
- Quantidades
- Preços unitários
- Descontos
- Valor total de cada item
- Cancelado/Não Cancelado

## Arquitetura

A arquitetura deste projeto segue os princípios do SOLID, DDD (Domain-Driven Design) e Clean Architecture. A estrutura do projeto está organizada em camadas que separam as responsabilidades de forma clara e coesa. 
Aqui está uma descrição das principais camadas e componentes:

1. **Camada de Apresentação (Presentation Layer):**
   - Contém a API que expõe os endpoints para interação com o sistema.
   - Utiliza o Swagger para documentação dos endpoints.

2. **Camada de Aplicação (Application Layer):**
   - Contém a lógica de aplicação e orquestração de operações.
   - Define interfaces para serviços que são implementados na camada de infraestrutura.
   
3. **Camada de Domínio (Domain Layer):**
   - Contém as entidades de domínio, agregados, value objects e regras de negócio.
   - Implementa validações e lógica de negócio central.

4. **Camada de Infraestrutura (Infrastructure Layer):**
   - Contém implementações de serviços, repositórios e acesso a dados.
   - Implementa a persistência de dados utilizando Entity Framework Core e SQLite.

5. **Camada de Testes (Test Layer):**
   - Contém testes unitários e de integração para garantir a qualidade do código.
   - Utiliza frameworks de teste como xUnit e bibliotecas como Moq para mocks.

## Princípios e Padrões Utilizados

   - **SOLID:** Princípios de design orientados a objetos que promovem a coesão e reduzem o acoplamento.
   - **DDD (Domain-Driven Design):** Foco no domínio e na lógica de negócio central, utilizando entidades, agregados e value objects.
   - **Clean Architecture:** Separação de responsabilidades em camadas, onde a camada de domínio é independente de detalhes de implementação.

## Fluxo de Dados

   1. **Requisição:** A API recebe uma requisição HTTP.
   2.  **Aplicação:** A camada de aplicação processa a requisição, chamando os serviços necessários.
   3. **Domínio:** A lógica de negócio é aplicada utilizando as entidades e regras de domínio.
   4. **Infraestrutura:** A camada de infraestrutura persiste ou recupera dados do banco de dados.
   5. **Resposta:** A resposta é enviada de volta ao cliente através da API.

Esta arquitetura permite uma fácil manutenção e escalabilidade, além de promover a reutilização de código e a separação de responsabilidades.

## Tecnologias Utilizadas

   - C#: Linguagem de programação principal utilizada no projeto.
   - .NET 9: Framework para desenvolvimento de aplicações.
   - Entity Framework Core: ORM (Object-Relational Mapping) para acesso a dados.
   - MediatR: Biblioteca para implementação do padrão Mediator.
   - AutoMapper: Biblioteca para mapeamento de objetos.
   - SQLite: Banco de dados utilizado para persistência de dados.
   - xUnit: Framework de testes unitários.
   - Moq: Biblioteca para criação de mocks em testes.
   - Bogus: Biblioteca para geração de dados falsos para testes.
   - FluentValidation: Biblioteca para validação de objetos.
   - Swagger: Ferramenta para documentação de APIs.
   - JetBrains Rider: IDE utilizada para desenvolvimento.

## Como Executar

Para executar a API vamos utilizar o Docker e aplicar as migrations, siga os passos abaixo:  

   1. **Certifique-se de que o Docker e o Docker Compose estão instalados:**  
      - Verifique se o Docker está instalado executando docker --version.
      - Verifique se o Docker Compose está instalado executando docker-compose --version.

   2. **Construa e inicie os contêineres:**  
      - Navegue até o diretório raiz do projeto onde o arquivo docker-compose.yml está localizado.
      - Execute o comando para construir e iniciar os contêineres: docker-compose up --build

   
   3. **Aplique as migrations:**  
      - Abra um novo terminal e execute o comando abaixo para acessar o contêiner da API:
      - docker exec -it ambev_developer_evaluation_webapi /bin/bash
      - Dentro do contêiner, aplique as migrations executando o comando: dotnet ef database update

       
   4. **Verifique se a API está em execução:**  
      - A API deve estar disponível nos endereços configurados no docker-compose.yml (por exemplo, http://localhost:8080 para HTTP e https://localhost:8081 para HTTPS).
      - Seguindo esses passos, você conseguirá executar a API e aplicar as migrations corretamente.