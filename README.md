# LivrosApi

API REST para gerenciamento de livros e autores, desenvolvida em ASP.NET Core (.NET 8) com Entity Framework Core e PostgreSQL.

## Funcionalidades

- CRUD de Autores
- CRUD de Livros
- Associação de livros a autores
- Documentação via Swagger

## Tecnologias Utilizadas

- ASP.NET Core (.NET 8)
- Entity Framework Core
- PostgreSQL
- Swagger

## Como Executar

1. **Clone o repositório:**

   git clone https://github.com/1nicolasj/BooksApi/

2. **Configure a string de conexão no `appsettings.json`:**

   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=livrosdb;Username=postgres;Password=senha"
   }

3. **Restaure os pacotes e execute as migrações:**

   dotnet restore
   dotnet ef database update

4. **Execute a aplicação:**

   dotnet run --project LivrosApi

5. **Acesse a documentação Swagger:**

   https://localhost:5001/swagger

## Estrutura do Projeto

- `Controllers/` - Endpoints da API
- `Models/` - Modelos de dados
- `Dto/` - Objetos de transferência de dados (DTOs)
- `Services/` - Lógica de negócio

## Exemplos de Endpoints

- `GET /api/Author/ListAuthors` - Lista todos os autores
- `POST /api/Author/CreateAuthor` - Cria um novo autor
- `GET /api/Book/ListBooks` - Lista todos os livros
- `POST /api/Book/CreateBook` - Cria um novo livro
