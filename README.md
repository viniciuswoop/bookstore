# Book Purchase – MVP

## 📌 Purpose
This project demonstrates a **Saga Pattern** implementation using **.NET 8**, **Blazor Server**, **RabbitMQ**, and **Docker**.  
The goal is to provide a small but complete **distributed application** that processes a book purchase order through multiple services while supporting compensating actions when failures occur.

This MVP serves as:
- A learning resource for event-driven architecture.
- A starting point for experimenting with distributed workflows.
- A foundation for adding more services, testing strategies, and scaling scenarios.

---

## 📖 Application Context
Imagine an **online bookstore** where a user buys a book through a web interface.  
The purchase process involves multiple services that must complete successfully; otherwise, the workflow is rolled back.

**Flow:**
1. User selects a book and places an order from the **Blazor Web UI**.
2. The **Order Service** starts a saga to coordinate:
   - **Inventory Service** → Reserve the book.
   - **Payment Service** → Process the payment.
   - **Shipping Service** → Arrange delivery.
3. If any step fails, the saga triggers compensating actions to undo previous steps.
4. The UI updates in real-time as the order progresses or fails.

---

## 🏗 Architecture

### Services
- **Blazor Web UI** – Displays order status and triggers saga workflows.
- **Order Service (Saga Orchestrator)** – Manages workflow and compensating actions.
- **Inventory Service** – Reserves or releases stock.
- **Payment Service** – Processes or refunds payments.
- **Shipping Service** – Arranges or cancels shipping.

### Communication
- **RabbitMQ** is used for asynchronous messaging between services.
- **Commands** and **events** follow a contract-first approach.

## 🚀 How to Run the Application

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [Git](https://git-scm.com/)

