
Chuks Kitchen – Food Ordering Backend API
Overview
This project is a backend implementation of a Food Ordering and Customer Management System built with .NET 10 using Clean Architecture and MediatR.
The goal of this deliverable was not just to create working APIs, but to demonstrate:
•	Clear system thinking
•	Proper separation of concerns
•	Logical handling of real-world scenarios
•	Clean and maintainable structure
The system allows customers to:
•	Register using email or phone
•	Verify their account using OTP
•	Browse food items
•	Add items to cart
•	Place orders
•	Track order status
Administrators can:
•	Add and update food items
•	Control item availability
•	Manage and update order statuses

Architectural Approach
The project follows Clean Architecture principles. The main idea is to keep business logic separate from frameworks and databases so the system remains clean and testable.
The solution is structured into four layers:
Domain Layer
•	Contains core entities such as User, FoodItem, Cart, and Order
•	Uses simple data models (anemic entities)
•	Has no external dependencies
The domain remains lightweight and independent.
Application Layer
This is where the decision-making happens.
•	Contains MediatR command and query handlers
•	Performs validation and orchestration
•	Enforces business rules
Examples of logic handled here include:
•	Checking if a user is verified before placing an order
•	Validating OTP expiration
•	Ensuring food items exist and are available
•	Controlling valid order status transitions
Infrastructure Layer
•	Implements repository interfaces
•	Configures EF Core
•	Uses an In-Memory database for storage
This layer handles persistence but does not contain business rules.
WebAPI Layer
•	Exposes HTTP endpoints
•	Forwards requests to MediatR
•	Does not contain business logic
Controllers remain thin and focused only on request handling.

How a Request Flows Through the System
For example, when a user places an order:
1.	The client sends a request to the API.
2.	The controller forwards the request to MediatR.
3.	MediatR routes it to the appropriate handler.
4.	The handler:
o	Validates the user
o	Checks cart contents
o	Verifies food availability
o	Calculates total price
o	Creates the order
5.	The repository saves the order to the database.
6.	A response is returned to the client.
The controller does not know how the order is created internally. This keeps the system decoupled and easier to maintain.

Key Design Decisions
Clean Architecture
Chosen to ensure:
•	Clear separation of responsibilities
•	Better maintainability
•	Easier testing
•	Long-term scalability
MediatR
Used to:
•	Decouple controllers from business logic
•	Centralize request handling
•	Keep API layer lightweight

CQRS
Applied to separate:
•	Commands (write operations)
•	Queries (read operations)
This improves clarity and organization as the system grows.
In-Memory Database
Chosen because:
•	It requires no setup
•	The project runs immediately after cloning
•	Reviewers can focus on logic and architecture
In a production setting, this would be replaced with a relational database.

Edge Case Handling
Several realistic edge cases were considered.
Registration
•	Duplicate email or phone is rejected
•	OTP includes expiration time
•	Expired OTPs are not accepted
Ordering
•	Unverified users cannot place orders
•	Food items must exist before ordering
•	Food availability is checked at order time
•	Invalid status transitions are prevented
Order states are carefully controlled to avoid inconsistent data.


Order Lifecycle
An order moves through the following states:
Pending → Confirmed → Preparing → OutForDelivery → Completed
At certain stages, it may also move to Cancelled.
All transitions are validated in the Application layer to maintain consistency.

Scalability Considerations
If the system grows to 10,000+ users, the following improvements would be implemented:
Database Upgrade
•	Replace In-Memory DB with PostgreSQL
•	Enable durable storage and indexing
Redis Caching
•	Cache frequently accessed data (e.g., food menu)
•	Reduce database load
Message Broker (RabbitMQ)
•	Handle order notifications asynchronously
•	Improve system resilience
•	Enable background processing
These changes would allow the system to scale while preserving the current architecture.


Relationship Explanation 
User → Order
One User can place many Orders.
Each Order belongs to exactly one User.
Order → OrderItem
One Order can contain multiple OrderItems.
Each OrderItem belongs to one Order.
FoodItem → OrderItem
One FoodItem can appear in many OrderItems.
OrderItem acts as a junction table that enables the Many-to-Many relationship between Order and FoodItem.

Conclusion
This project demonstrates:
•	The ability to translate product requirements into backend logic
•	Structured system design using Clean Architecture
•	Logical handling of edge cases
•	Awareness of scalability considerations
•	Clear and organized technical communication
The focus was not just to build endpoints, but to design a backend system that is clean, understandable, and maintainable.
 
 
