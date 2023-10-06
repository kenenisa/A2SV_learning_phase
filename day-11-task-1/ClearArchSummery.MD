# Clean architecture
Clean architecture is a domain-centric approach to organizing dependencies, emphasizing clean separation of concerns. It encourages dependency inversion, focusing on interfaces over concrete dependencies, and minimizing direct dependencies on infrastructure.

Clean architecture is best suited for applications with complex business logic, aligned with domain-driven design. It helps keep the domain model pure and free from dependencies. However, it might be overkill for simple CRUD applications or projects with minimal conditional logic in the domain model.

The architecture consists of three main projects:

1. **Core:** Contains business logic, including entities, value objects, domain services, custom exceptions, domain events, and specifications.

2. **Infrastructure:** Handles external dependencies and implementations of abstractions, such as data access (e.g., DbContext), caching, third-party APIs, file system operations, and email/SMS sending.

3. **Web:** An ASP.Net Core project serving as the entry point. It includes API endpoints, controllers, views, DTOs, request/response models, filters, and other ASP.Net Core components.

*Additionally, a shared kernel project houses common types (base classes, interfaces, exceptions) used across solutions, ideally distributed as a NuGet package.*