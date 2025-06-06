# 🍔 Projeto de Microserviço para Gerenciamento do FastTechFood

Este projeto implementa um **microserviço assíncrono** para o gerenciamento de pedidos e orçamentos do sistema **FastTechFood**, utilizando **RabbitMQ** como mecanismo de mensageria. A arquitetura do sistema foi pensada para garantir **escalabilidade**, **resiliência** e **baixo acoplamento** entre os serviços.

---

## 🚀 Tecnologias Utilizadas

- .NET 8  
- ASP.NET Core (Web API)  
- RabbitMQ  
- PostgreSQL  
- Docker / Docker Compose  

---

## 🧩 Objetivo

O projeto visa representar um cenário real de um sistema de **pedido e orçamento** em uma rede de fast food digitalizada — o **FastTechFood** — aplicando conceitos modernos de arquitetura como:

- Microsserviços com responsabilidades únicas  
- Comunicação assíncrona com RabbitMQ  
- Processamento desacoplado e resiliente  
- Persistência relacional com PostgreSQL  
- Estrutura modular e escalável

---

## 🛠️ Funcionalidades

- Envio de dados de pedidos/orçamentos para uma fila RabbitMQ  
- Processamento assíncrono por um **worker** independente  
- Armazenamento dos dados em banco relacional (PostgreSQL)  
- Comunicação entre serviços desacoplada e rastreável  

---

## ⚙️ Como Executar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [Docker](https://www.docker.com/)  
- [Docker Compose](https://docs.docker.com/compose/)  

### Execução via Docker Compose

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/fasttechfood-microservice.git
   cd fasttechfood-microservice
