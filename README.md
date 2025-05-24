# 🏍️ API - Gerenciador de Motos e Usuário

API RESTful desenvolvida com ASP.NET Core para gerenciamento de motos e usuários. Suporta operações de CRUD e utiliza Oracle como banco de dados.

## 📌 Funcionalidades

- Cadastro, listagem, atualização e exclusão de motos
- Cadastro, listagem, atualização e exclusão de usuários

## 🔗 Rotas da API

### Motos
- `GET /api/moto` — Lista todas as motos
- `GET /api/moto/{id}` — Busca uma moto por ID
- `POST /api/moto` — Cadastra uma nova moto
- `PUT /api/moto/{id}` — Atualiza uma moto existente
- `DELETE /api/moto/{id}` — Remove uma moto

### Usuários
- `GET /api/usuario` — Lista todos os usuários
- `GET /api/usuario/{id}` — Busca um usuário por ID
- `POST /api/usuario` — Cadastra um novo usuário
- `PUT /api/usuario/{id}` — Atualiza um usuário existente
- `DELETE /api/usuario/{id}` — Remove um usuário

## ⚙️ Instalação e Execução

### Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- Banco Oracle (e string de conexão válida)
- Visual Studio ou VS Code

### Clonando o repositório

```bash
git clone https://github.com/seu-usuario/webapi-motos.git
cd WebAPI.Net
