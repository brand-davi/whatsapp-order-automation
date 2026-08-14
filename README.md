# WhatsApp Order Automation Engine

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![Clean Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-blue)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
[![OpenAI](https://img.shields.io/badge/AI-OpenAI%20GPT--4o--mini-412991?style=flat&logo=openai)](https://openai.com/)
[![WhatsApp Cloud API](https://img.shields.io/badge/Integration-WhatsApp%20Cloud%20API-25D366?style=flat&logo=whatsapp)](https://developers.facebook.com/)

SaaS multi-tenant para automação conversacional de pedidos de restaurantes e marmitarias via **WhatsApp Business Cloud API**, utilizando **Inteligência Artificial (LLMs)** para parsing em linguagem natural, **Máquina de Estados** para condução do diálogo e **SignalR** para despacho de comandas em tempo real para impressoras térmicas locais.

---

## 📐 Arquitetura do Sistema

O projeto adota os princípios de **Clean Architecture** (Arquitetura Limpa) organizados em um **Monorepo** .NET. O core da aplicação é responsável por gerenciar a inteligência da conversa e a persistência dos pedidos, enquanto um agente local (*PrintAgent*) consome os eventos de novos pedidos confirmados para efetuar a impressão física na loja.

```mermaid
sequenceDiagram
    autonumber
    actor Cliente
    participant WhatsApp as WhatsApp Cloud API
    participant API as ASP.NET Core API
    participant StateMachine as Conversation Engine
    participant AI as OpenAI (GPT-4o-mini)
    participant DB as PostgreSQL (EF Core)
    participant Hub as SignalR Hub
    participant Agent as PrintAgent (Local)
    participant Printer as Impressora Térmica

    Cliente->>WhatsApp: Envia mensagem ("Quero 2 lasanhas P e 1 feijoada G")
    WhatsApp->>API: POST /webhooks/whatsapp (Webhook)
    API->>StateMachine: Processa mensagem & recupera estado da conversa
    StateMachine->>AI: Envia texto para Parsing (Structured Output JSON)
    AI-->>StateMachine: Retorna itens extraídos em JSON
    StateMachine->>DB: Valida preços/estoque no Cardápio & Atualiza Estado
    StateMachine->>WhatsApp: Responde solicitando Endereço/Pagamento
    
    Note over Cliente, WhatsApp: O cliente informa Endereço & Pagamento
    
    Cliente->>WhatsApp: Confirma Pedido ("Finalizar Pedido")
    WhatsApp->>API: Evento de confirmação
    API->>DB: Registra Pedido (Status: Confirmed)
    API->>Hub: Notifica evento OrderConfirmed
    Hub->>Agent: Dispara Job de Impressão via WebSocket
    Agent->>Printer: Envia comandos ESC/POS para impressão da comanda
