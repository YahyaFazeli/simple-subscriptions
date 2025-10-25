# Simple Subscription Management Service

A minimal backend service to manage subscription plans.  
Users can view available plans, subscribe to a plan, and cancel their active subscription.  
This project was created as an **interview task** to demonstrate clean architecture, API design, and technical decision-making.

---

## ✅ Features

- List available subscription plans
- Subscribe a user to a plan
- Get a user’s active subscription
- Cancel a user’s subscription
- Input validation using FluentValidation
- OpenAPI documentation with Scalar
- In-memory EF Core database for simplicity
- Clean, maintainable, and modular architecture

---

## 🏗️ Architecture & Technology Choices

This project follows a **layered Clean Architecture-inspired structure**:

- **API Layer (.API)**  
  Minimal APIs for fast, clear endpoint definition.

- **Application Layer (.Application)**  
  Business logic via services, DTOs, Result wrapper pattern, and validation.

- **Domain Layer (.Domain)**  
  Core entities and enums with encapsulated rules.

- **Infrastructure Layer (.Infrastructure)**  
  EF Core InMemory database & repositories.

### Why these choices?

| Decision | Reason |
|----------|--------|
| .NET 8 Minimal APIs | Lightweight, fast, clean syntax for small services |
| Clean Architecture | Separation of concerns & scalability |
| EF Core InMemory DB | No external setup needed for reviewing and testing |
| FluentValidation | Reliable, readable request validation |
| `Result<T>` pattern | Predictable API responses and error handling |
| Scalar + OpenAPI | Easy API testing + interactive documentation |

The main goal: **clarity, correctness, and maintainable design** within a short timeframe.

---

## 📁 Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/subscriptions/plans` | Get all available plans |
| `GET` | `/api/subscriptions/{userId}` | Get user’s active subscription |
| `POST` | `/api/subscriptions` | Activate a subscription for a user |
| `DELETE` | `/api/subscriptions/{userId}` | Cancel user’s subscription |

---

## 📌 Scaling Considerations

If this service were extended to production:

- Replace InMemory DB → PostgreSQL or SQL Server  
- Add authentication & authorization (JWT / IdentityServer)  
- Domain events for renewals and cancellations  
- Track plan pricing history & scheduling logic  
- Structured logging, metrics, tracing (Serilog + ELK / Prometheus)  
- Containerized deployment + CI/CD  
- Message queues for asynchronous workflows (e.g., renewals)  
- Multi-tenant support and high-traffic optimizations

---

## ⏱️ Time Spent

**~2 hour** (architecture setup, coding, validation, and documentation)

---

## 🤖 AI Assistance Disclosure
AI was used as a **pair-programming assistant** for:

- Brainstorming architecture structure
- Drafting README structure

All implementation, code decisions, and final design choices were done manually.

---

## 🧪 Tests

A placeholder test project is included for future extensions.  
Due to time constraints, no unit tests were implemented, but the structure allows easy testing of services and endpoints.

---

## 📎 Project Structure

```

src/
├─ SubscriptionService.API/            # Endpoints & configuration
├─ SubscriptionService.Application/    # DTOs, Services, Validators
├─ SubscriptionService.Domain/         # Core Models & Enums
└─ SubscriptionService.Infrastructure/ # EF Core + Repository

````

## 🚀 Running the Project

```bash
# 1. Clone repository
git clone https://github.com/YahyaFazeli/simple-subscriptions.git

# 2. Navigate to API project folder
cd simple-subscriptions/src/SubscriptionService.API

# 3. Run the app
dotnet run

# 4. Access API docs (development only)
# Interactive API UI: /scalar
````

---

## 🔚 Closing Notes

Designed to **demonstrate architecture clarity, maintainability, and correctness** rather than feature count.
The service is intentionally simple but flexible enough to scale into a real subscription platform.
