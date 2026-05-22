# LoginApi

API de autenticação desenvolvida com ASP.NET Core, JWT e SQLite.

## Tecnologias

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- JWT (JSON Web Token)
- BCrypt
- Swagger

## Endpoints

### POST /api/Auth/register
Registra um novo usuário e retorna um token JWT.

**Body:**
```json
{
  "username": "seu_usuario",
  "password": "sua_senha"
}
```

**Resposta:**
```json
{
  "token": "eyJhbGci..."
}
```

---

### POST /api/Auth/login
Autentica um usuário e retorna um token JWT.

**Body:**
```json
{
  "username": "seu_usuario",
  "password": "sua_senha"
}
```

**Resposta:**
```json
{
  "token": "eyJhbGci..."
}
```

## Como rodar

1. Clone o repositório
```bash
git clone https://github.com/Mgrsantos/LoginApi.git
```

2. Entre na pasta do projeto
```bash
cd LoginApi/LoginApi
```

3. Rode o projeto
```bash
dotnet run
```

4. Acesse o Swagger
```
https://localhost:7269/swagger
```
