# WhatsApp Order Automation Engine




\

Aplicação backend desenvolvida em **C# e .NET** para automatizar o atendimento e o processamento de pedidos realizados pelo WhatsApp de restaurantes.

O sistema foi projetado para receber mensagens de clientes, interpretar pedidos escritos em linguagem natural, coletar informações ausentes, validar o pedido e transformar a conversa em dados estruturados que possam ser processados pelo restaurante sem necessidade de redigitação manual.

---

## 🎯 O Problema

Pequenos restaurantes frequentemente recebem pedidos diretamente pelo WhatsApp.

Embora esse processo seja conveniente para o cliente, ele gera diversas tarefas repetitivas para a equipe do estabelecimento, como:

* ler manualmente cada conversa;
* identificar produtos e quantidades solicitadas;
* perguntar informações que ficaram faltando;
* coletar o endereço de entrega;
* confirmar a forma de pagamento;
* verificar a necessidade de troco em pagamentos em dinheiro;
* transcrever manualmente o pedido;
* encaminhar o pedido para produção ou impressão.

O objetivo deste projeto é automatizar esse fluxo, preservando para o cliente a simplicidade de realizar um pedido através de uma conversa pelo WhatsApp.

---

## 💡 Solução

A aplicação funciona como uma camada de automação entre o cliente e a operação do restaurante.

Um fluxo típico de atendimento é:

```text
Cliente envia uma mensagem
             ↓
      WhatsApp Cloud API
             ↓
      Webhook da aplicação
             ↓
   Conversa é identificada
             ↓
Mensagem do cliente é interpretada
             ↓
Dados do pedido são extraídos
             ↓
Informações ausentes são identificadas
             ↓
Sistema realiza novas perguntas
             ↓
Resumo do pedido é apresentado
             ↓
      Cliente confirma
             ↓
       Pedido é criado
             ↓
 Pedido é enviado para impressão
```

O objetivo é permitir que a equipe do restaurante receba um pedido estruturado sem precisar transcrever manualmente as informações da conversa.

---

## ✨ Principais Funcionalidades

O sistema está sendo projetado para suportar:

* recebimento de mensagens através do WhatsApp do restaurante;
* resposta automática aos clientes;
* envio do cardápio vigente;
* realização de pedidos diretamente pela conversa;
* interpretação de pedidos escritos em linguagem natural;
* extração de informações estruturadas das mensagens do cliente;
* identificação de informações ausentes necessárias para concluir o pedido;
* perguntas sobre bebidas e complementos;
* coleta do endereço de entrega;
* coleta da forma de pagamento;
* tratamento de pagamentos em dinheiro e necessidade de troco;
* apresentação de um resumo antes da confirmação;
* confirmação do pedido pelo cliente;
* criação automática do pedido;
* envio do pedido concluído para o fluxo de impressão;
* redução da necessidade de transcrição manual pela equipe do restaurante.

---

## 📋 Requisitos Funcionais

| ID       | Requisito                                                                              |
| -------- | -------------------------------------------------------------------------------------- |
| **RF01** | Receber mensagens através do WhatsApp da loja.                                         |
| **RF02** | Responder automaticamente ao cliente.                                                  |
| **RF03** | Enviar a imagem do cardápio vigente.                                                   |
| **RF04** | Permitir que o cliente realize o pedido através da conversa.                           |
| **RF05** | Interpretar pedidos escritos em linguagem natural.                                     |
| **RF06** | Identificar informações ainda ausentes no pedido.                                      |
| **RF07** | Perguntar ao cliente sobre bebidas ou complementos.                                    |
| **RF08** | Coletar o endereço de entrega.                                                         |
| **RF09** | Coletar a forma de pagamento.                                                          |
| **RF10** | Quando o pagamento for em dinheiro, coletar informações sobre troco quando necessário. |
| **RF11** | Apresentar um resumo do pedido antes da finalização.                                   |
| **RF12** | Permitir que o cliente confirme e finalize o pedido.                                   |
| **RF13** | Criar automaticamente o pedido após a confirmação.                                     |
| **RF14** | Enviar o pedido concluído para o fluxo de impressão.                                   |
| **RF15** | Evitar a necessidade de redigitação manual das informações pela equipe do restaurante. |

---

## 🧠 Interpretação de Pedidos em Linguagem Natural

O cliente não precisa seguir obrigatoriamente um formato rígido de comandos.

Por exemplo, ele poderia enviar:

```text
Quero duas marmitas médias,
uma de frango e uma de carne.

Entrega na Rua Principal, 120.

Vou pagar no Pix.
```

A aplicação deve ser capaz de transformar essa mensagem em informações estruturadas semelhantes a:

```text
Pedido
├── Itens
│   ├── Marmita Média - Frango x1
│   └── Marmita Média - Carne x1
│
├── Endereço de entrega
│   └── Rua Principal, 120
│
├── Forma de pagamento
│   └── Pix
│
└── Informações ausentes
    └── Horário desejado
```

Em vez de reiniciar todo o processo, o sistema identifica apenas as informações ausentes e continua a conversa a partir daquele ponto.

---

## 🏗️ Arquitetura

O projeto segue princípios de **Clean Architecture**, separando as regras de negócio da infraestrutura e das integrações externas.

```text
┌──────────────────────────────┐
│        Presentation          │
│   Webhooks / HTTP Endpoints  │
└───────────────┬──────────────┘
                │
┌───────────────▼──────────────┐
│         Application          │
│ Casos de Uso / Orquestração  │
└───────────────┬──────────────┘
                │
┌───────────────▼──────────────┐
│            Domain            │
│ Entidades / Regras de Negócio│
└───────────────▲──────────────┘
                │
┌───────────────┴──────────────┐
│        Infrastructure        │
│ Banco / WhatsApp / IA        │
│ Impressão / APIs Externas    │
└──────────────────────────────┘
```

Essa separação permite que tecnologias externas sejam alteradas sem acoplar diretamente as principais regras de negócio ao WhatsApp, ao provedor de IA, ao banco de dados ou à infraestrutura de impressão.

---

## 🧩 Modelagem de Domínio

O domínio foi dividido de acordo com as principais responsabilidades da operação do restaurante.

```text
Domain
├── Catalog
├── Conversations
├── Customers
├── Orders
├── Printing
└── Restaurants
```

### Restaurants

Contém as informações relacionadas ao restaurante e suas configurações operacionais.

Exemplos:

```text
Restaurant
RestaurantSettings
```

### Catalog

Representa a estrutura do cardápio e os produtos disponíveis para venda.

Exemplos:

```text
MenuCategory
MenuItem
MenuItemVariant
```

### Customers

Representa os clientes que interagem com o restaurante através do WhatsApp.

### Conversations

Responsável pelo contexto e pelo estado das conversas realizadas pelo WhatsApp.

O contexto da conversa permite compreender se o cliente está:

* iniciando um pedido;
* escolhendo itens;
* fornecendo informações ausentes;
* informando o endereço;
* escolhendo uma forma de pagamento;
* revisando o pedido;
* confirmando o pedido.

### Orders

Contém as principais regras de negócio relacionadas aos pedidos.

Alguns dos conceitos presentes nesse domínio incluem:

```text
Order
OrderItem
OrderStatus
OrderType
PaymentMethod
```

### Printing

Responsável pelo fluxo de envio dos pedidos confirmados para a infraestrutura de impressão do restaurante.

---

## 🔄 Estado da Conversa

Uma conversa no WhatsApp não é tratada simplesmente como um conjunto de mensagens isoladas.

A aplicação mantém o contexto ao longo de toda a interação.

Conceitualmente:

```text
Started
   ↓
WaitingForItems
   ↓
WaitingForAddress
   ↓
WaitingForPayment
   ↓
WaitingForAdditionalInformation
   ↓
WaitingForConfirmation
   ↓
Confirmed
```

A transição entre os estados depende das informações que o cliente já forneceu.

Por exemplo, se o cliente informar os itens, o endereço e a forma de pagamento na primeira mensagem, o sistema não deverá perguntar novamente essas informações.

---

## 🤖 Papel da Inteligência Artificial

O modelo de linguagem é utilizado como um componente da aplicação, e não como responsável por controlar todo o fluxo de negócio.

Sua principal responsabilidade é auxiliar na transformação de mensagens não estruturadas do cliente em informações que possam ser processadas pela aplicação.

```text
Mensagem não estruturada
          ↓
Processamento de linguagem natural
          ↓
Informações estruturadas
          ↓
 Validação pela aplicação
          ↓
    Regras de negócio
```

As decisões de negócio permanecem sob responsabilidade da aplicação.

Por exemplo, a IA pode identificar que o cliente informou:

```text
"Vou pagar em dinheiro e preciso de troco para 100."
```

e extrair dados semelhantes a:

```text
PaymentMethod: Cash
ChangeFor: 100.00
```

A aplicação é então responsável por validar e utilizar essas informações de acordo com as regras definidas no domínio.

---

## 🛠️ Tecnologias

### Backend

* C#
* .NET 10
* ASP.NET Core
* APIs REST

### Arquitetura e Design

* Clean Architecture
* Programação Orientada a Objetos
* Modelagem de Domínio
* Separação de Responsabilidades
* Injeção de Dependência

### Persistência

* Entity Framework Core
* Banco de Dados Relacional
* SQL

### Integrações Externas

* WhatsApp Cloud API
* API de LLM
* Infraestrutura de impressão

### Desenvolvimento

* Git
* GitHub

---

## 🧪 Conceitos Aplicados no Projeto

Este projeto utiliza e exercita diversos conceitos de desenvolvimento de software, incluindo:

* Programação Orientada a Objetos;
* classes e objetos;
* encapsulamento;
* modelagem de domínio;
* manipulação de objetos e coleções;
* estruturas condicionais;
* estruturas de repetição;
* tratamento de exceções;
* desenvolvimento de APIs REST;
* consumo de APIs externas;
* programação assíncrona;
* injeção de dependência;
* persistência de dados;
* SQL e bancos de dados relacionais;
* versionamento com Git;
* modelagem de regras de negócio;
* separação de responsabilidades.

---

## 📁 Estrutura do Projeto

A solution segue uma estrutura em camadas semelhante a:

```text
src/
├── Domain/
│   ├── Catalog/
│   ├── Conversations/
│   ├── Customers/
│   ├── Orders/
│   ├── Printing/
│   └── Restaurants/
│
├── Application/
│
├── Infrastructure/
│
└── WebApi/
```

Cada camada possui uma responsabilidade específica, reduzindo o acoplamento entre as regras de negócio e os detalhes de infraestrutura.

---

## 🚀 Como Executar

Clone o repositório:

```bash
git clone <repository-url>
```

Acesse o diretório do projeto:

```bash
cd <repository-directory>
```

Restaure as dependências:

```bash
dotnet restore
```

Compile a solution:

```bash
dotnet build
```

Execute a aplicação:

```bash
dotnet run
```

As integrações externas exigem suas respectivas credenciais e configurações, como:

* conexão com banco de dados;
* WhatsApp Cloud API;
* provedor de IA;
* infraestrutura de impressão.

Credenciais e informações sensíveis não devem ser adicionadas ao repositório.

---

## 🗺️ Roadmap

O projeto está em desenvolvimento ativo.

Próximas etapas planejadas:

* [x] Concluir a modelagem do domínio
* [ ] Configurar a persistência de dados
* [ ] Implementar o webhook do WhatsApp
* [ ] Implementar o envio de mensagens pelo WhatsApp
* [ ] Implementar o gerenciamento de estado das conversas
* [ ] Implementar a interpretação de pedidos em linguagem natural
* [ ] Implementar a identificação de informações ausentes
* [ ] Implementar a validação dos pedidos
* [ ] Implementar o fluxo de confirmação
* [ ] Implementar a persistência dos pedidos
* [ ] Implementar o fluxo de impressão
* [ ] Adicionar testes automatizados
* [ ] Melhorar observabilidade e tratamento de erros

---

## 📌 Status do Projeto

**Em desenvolvimento.**

O foco atual está na modelagem do domínio e na definição das regras de negócio necessárias para transformar conversas realizadas pelo WhatsApp em pedidos estruturados de forma confiável.

---

## 🎯 Objetivo do Projeto

Este projeto surgiu a partir de uma **necessidade real de negócio** e está sendo desenvolvido como uma solução backend completa, e não apenas como um protótipo de chatbot.

Seus principais objetivos técnicos são aplicar e aprofundar conhecimentos relacionados a:

* arquitetura de software;
* modelagem de domínio;
* integrações com APIs;
* fluxos conversacionais;
* processamento de linguagem natural;
* implementação de regras de negócio;
* persistência de dados;
* desenvolvimento de aplicações sustentáveis e organizadas em C#/.NET.

O objetivo final é proporcionar um fluxo no qual o pedido possa sair da mensagem enviada pelo cliente no WhatsApp e chegar à operação do restaurante com o mínimo possível de intervenção manual.
