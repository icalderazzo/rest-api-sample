# Cars API

This API is starting point for the example we saw on the presentation before. These are the endpoints developed in this solution:

```
POST   /api/cars
GET    /api/cars
GET    /api/cars?plateNumber={0}&brand={1}&model={2}
POST   /api/cars/{vin}/services
GET    /api/cars/{vin}
PUT    /api/cars/{vin}
DELETE /api/cars/{vin}
```

This API has been developed in .NET 8 with C#

### Requirements
* .NET 8 Runtime
* .NET 8 SDK

### Project Structure
The project is organized following the Domain-Driven Design (DDD) pattern to ensure clean, scalable, and maintainable code:

* **CarsApi.Domain**: Houses core domain logic, including entities, repositories, exceptions, and validators.

* **CarsApi.Infrastructure**: Includes the infrastructure-related code, focusing on persistence.

* **CarsApi.Application**: Contains the application logic, including car services and Data Transfer Objects (DTOs).

* **CarsApi.WebApi**: Starting point of the application responsible for configurations and the web API layer.

### Getting started
Open the solution your IDE of preference and go the `src` folder on a terminal.

Build the solution
```
dotnet build
```
Run the API
```
dotnet run --project CarsApi.WebApi
```