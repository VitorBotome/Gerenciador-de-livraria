# 📚 Gerenciador de Livraria

API REST desenvolvida em **C# com ASP.NET Core** para gerenciamento completo de uma livraria, com CRUD de livros, validações de negócio e documentação via Swagger.

---

## 🚀 Tecnologias Utilizadas

- **C#** — Linguagem principal
- **ASP.NET Core** — Framework para construção da API REST
- **.NET** — Plataforma de execução
- **Swagger** — Documentação interativa da API
- **System.Text.Json** — Serialização JSON com suporte a enums como string e formatação customizada de datas

---

## ✨ Funcionalidades

- ➕ **Criar livro** — Cadastra um novo livro com validações completas
- 📋 **Listar livros** — Retorna todos os livros cadastrados
- 🔍 **Buscar por ID** — Consulta um livro específico pelo seu GUID
- ✏️ **Atualizar livro** — Edita as informações de um livro existente
- 🗑️ **Excluir livro** — Remove um livro do acervo

---

## 🔗 Endpoints da API

| Método   | Endpoint         | Descrição                         |
|----------|------------------|-----------------------------------|
| `POST`   | `/api/book`      | Criar um novo livro               |
| `GET`    | `/api/book`      | Listar todos os livros            |
| `GET`    | `/api/book/{id}` | Buscar um livro pelo ID           |
| `PUT`    | `/api/book/{id}` | Atualizar informações de um livro |
| `DELETE` | `/api/book/{id}` | Excluir um livro da livraria      |

---

## 📦 Modelos e Validações

### Criar livro — `POST /api/book`

**Request body:**
```json
{
  "title": "O Senhor dos Anéis",
  "author": "J.R.R. Tolkien",
  "genre": "Ficcao",
  "price": 59.90,
  "stock": 10
}
```

**Response `201 Created`:**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "title": "O Senhor dos Anéis",
  "author": "J.R.R. Tolkien",
  "genre": "Ficcao",
  "price": 59.90,
  "stock": 10,
  "createdAt": "2025-01-01 10:00:00",
  "updatedAt": null
}
```

---

### Listar todos os livros — `GET /api/book`

**Response `200 OK`:**
```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "title": "O Senhor dos Anéis",
    "author": "J.R.R. Tolkien",
    "genre": "Ficcao",
    "price": 59.90,
    "stock": 10,
    "createdAt": "2025-01-01 10:00:00",
    "updatedAt": null
  }
]
```

---

### Buscar livro por ID — `GET /api/book/{id}`

**Response `200 OK`:**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "title": "O Senhor dos Anéis",
  "author": "J.R.R. Tolkien",
  "genre": "Ficcao",
  "price": 59.90,
  "stock": 10,
  "createdAt": "2025-01-01 10:00:00",
  "updatedAt": null
}
```

**Response `404 Not Found`:**
```json
"Livro nao encontrado"
```

---

### Atualizar livro — `PUT /api/book/{id}`

**Request body:**
```json
{
  "title": "O Senhor dos Anéis - Edição Especial",
  "author": "J.R.R. Tolkien",
  "genre": "Ficcao",
  "price": 79.90,
  "stock": 5
}
```

**Response `200 OK`:**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "title": "O Senhor dos Anéis - Edição Especial",
  "author": "J.R.R. Tolkien",
  "genre": "Ficcao",
  "price": 79.90,
  "stock": 5,
  "createdAt": "2025-01-01 10:00:00",
  "updatedAt": "2025-01-02 15:30:00"
}
```

**Response `404 Not Found`:**
```json
"Livro nao encontrado"
```

---

### Excluir livro — `DELETE /api/book/{id}`

**Response `200 OK`:**
```json
"Livro deletado"
```

---

### Campos obrigatórios

| Campo    | Tipo      | Obrigatório | Regras de Validação                                                  |
|----------|-----------|-------------|----------------------------------------------------------------------|
| `id`     | `GUID`    | Automático  | Gerado automaticamente pelo sistema                                  |
| `title`  | `string`  | ✅ Sim      | Entre 2 e 120 caracteres                                             |
| `author` | `string`  | ❌ Não      | Entre 2 e 120 caracteres                                             |
| `genre`  | `enum`    | ✅ Sim      | Valores válidos: `Ficcao`, `Romance`, `Misterio`, `Terror`, `Outros` |
| `price`  | `decimal` | ✅ Sim      | Deve ser maior ou igual a 0                                          |
| `stock`  | `int`     | ✅ Sim      | Deve ser maior ou igual a 0                                          |

### Regras de Negócio

- `title` não pode ser igual ao `author`
- `price` não pode ser negativo
- `stock` não pode ser negativo
- `genre` deve ser um dos valores válidos do enum `GeneroLivroEnum`
- `createdAt` é preenchido automaticamente na criação do livro
- `updatedAt` é atualizado automaticamente a cada edição
- Em caso de exclusão de um livro inexistente, atualmente é lançada uma exceção *(melhoria futura: retornar 404)*
- *(Melhoria futura)* Evitar duplicidade de livros com mesmo título e autor

---

## 📁 Estrutura do Projeto

```
GerenciadorDeLivraria/
├── Controllers/
│   └── BookController.cs          # Endpoints da API
├── Convertes/
│   └── DateTimeConverter.cs       # Formatação customizada de DateTime
├── DTOs/
│   ├── CreateBookDto.cs           # DTO de criação com validações
│   └── UpdateBookDto.cs           # DTO de atualização
├── Models/
│   ├── BaseEntity.cs              # Classe base com campos comuns (Id, CreatedAt, UpdatedAt)
│   ├── Book.cs                    # Modelo principal do livro
│   └── Enums.cs                   # Enum de gêneros (GeneroLivroEnum)
├── Repositories/
│   └── BookRepository.cs          # Armazenamento em memória
├── Service/
│   └── BookService.cs             # Regras de negócio
├── .gitignore
├── appsettings.json
├── appsettings.Development.json
├── GerenciadorDeLivraria.http
└── Program.cs                     # Ponto de entrada da aplicação
```

---

## ▶️ Como Executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado (versão 6.0 ou superior)

### Passos

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/VitorBotome/Gerenciador-de-livraria.git
   cd Gerenciador-de-livraria
   ```

2. **Restaure as dependências:**
   ```bash
   dotnet restore
   ```

3. **Execute a aplicação:**
   ```bash
   dotnet run
   ```

4. **Acesse a documentação Swagger** *(disponível apenas em ambiente de desenvolvimento):*
   ```
   https://localhost:{porta}/swagger
   ```

> A porta é exibida no terminal ao iniciar a aplicação.

### Configurações de Serialização JSON

A API utiliza as seguintes configurações globais de serialização:

- **Enums serializado como string** — o campo `genre` é enviado e recebido como texto (ex: `"Ficcao"`) em vez de número
- **Propriedades case-insensitive** — os campos do JSON não diferenciam maiúsculas de minúsculas
- **Datas com formatação customizada** — `createdAt` e `updatedAt` utilizam um conversor próprio de `DateTime`

---

## 👨‍💻 Autor

Desenvolvido por **[VitorBotome](https://github.com/VitorBotome)**

---

## 📄 Licença

Este projeto está sob a licença MIT. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.
