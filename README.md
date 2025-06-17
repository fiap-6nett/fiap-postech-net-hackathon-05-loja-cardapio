# 🍔 Projeto de Microserviço para Gerenciamento do FastTechFood

Este projeto implementa um **microserviço assíncrono** para o gerenciamento de pedidos e orçamentos do sistema **FastTechFood**, utilizando **RabbitMQ** como mecanismo de mensageria. A arquitetura do sistema foi pensada para garantir **escalabilidade**, **resiliência** e **baixo acoplamento** entre os serviços.

## 🚀 Tecnologias Utilizadas

- ✅ .NET 8  
- ✅ ASP.NET Core (Web API)  
- ✅ PostgreSQL  
- ✅ Docker  
- ✅ Middleware de tratamento global de exceções  
- ✅ Validações com DataAnnotations  

---

## 🎯 Objetivo

Simular um cenário real de gestão de cardápios em uma rede de fast food, aplicando os seguintes conceitos de engenharia de software:

- Organização em camadas (Web, Application, Domain, Infra)  
- API REST com boas práticas de desenvolvimento  
- Integração com banco de dados relacional (PostgreSQL)  
- Validação de dados de entrada  
- Tratamento de erros centralizado com middleware

---

## 🧩 Funcionalidades

- ✅ Cadastro, listagem, atualização e exclusão de **lojas**  
- ✅ Cadastro, listagem, atualização e exclusão de **itens de cardápio** vinculados a uma loja  
- ✅ Validações de entrada com mensagens claras e personalizadas  
- ✅ Tratamento global de exceções com middleware  
- ✅ Persistência de dados utilizando PostgreSQL

---

## ⚙️ Como Executar o Projeto

### 🔧 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [Docker](https://www.docker.com/)  

### 🐘 Subindo o Banco de Dados PostgreSQL com Docker

Para baixar e executar o container do PostgreSQL localmente, utilize o comando abaixo:

```bash
docker run -p 5432:5432 \
  -v /tmp/database:/var/lib/postgresql/data \
  -e POSTGRES_PASSWORD=1234 \
  -d postgres
```

> Conexão padrão: `localhost:5432` com usuário `postgres` e senha `1234`.

---

### 🛠️ Executando a API

1. Clone o repositório:
   ```bash
   git clone https://github.com/CleberPSA/LojaCardapio.git
   cd LojaCardapio
   ```

2. Restaure os pacotes:
   ```bash
   dotnet restore
   ```

3. Execute o projeto Web:
   ```bash
   dotnet run --project FastTech.LojaCardapio.Web
   ```

---

## 📂 Estrutura do Projeto

```bash
FastTech.LojaCardapio/
├── Application/        # Casos de uso e validações de entrada
├── Domain/             # Entidades, interfaces e regras de negócio
├── Infra/              # Acesso a dados, contexto do EF Core e configurações de infraestrutura
├── Web/                # Controllers, middlewares, configuração de serviços e entrada da aplicação
```

---

Se quiser, posso ajudar a gerar um exemplo de requisição (ex: JSON de criação de loja) ou até mesmo um arquivo `http` para testar no VS Code/Insomnia/Postman. Deseja incluir isso também?
