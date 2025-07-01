# JWT Authentication with Middleware in .NET

This repository demonstrates how to implement **JWT (JSON Web Token) authentication** and **middleware** in a clean and secure way using **.NET**.

## 🔐 Features

- JWT-based authentication using bearer tokens
- Custom authentication middleware
- Support for `[AllowAnonymous]` endpoints
- Policy-based authorization registered in `Program.cs`
- Minimal API with clean separation of concerns
- Token validation via middleware

---

## 🚀 Getting Started

### Prerequisites

- [.NET 6 or later](https://dotnet.microsoft.com/en-us/download)
- Postman or any API testing tool (optional, for testing JWT flow)
- Swagger is Enabled.

---

## 🧩 Project Structure

```bash
.
├── Controllers/
│   └── AuthController.cs       # Handles login and anonymous routes
├── Middleware/
│   └── JwtMiddleware.cs        # Custom middleware to validate JWT token
├── Models/
│   └── JwtSettings.cs          # Configurations for token creation and validation
├── Program.cs                  # Configuration for DI, authentication, and policies
├── Services/
│   └── IJwtService.cs
│   └── JwtService.cs           # Handles JWT generation
├── appsettings.json            # JWT secret and issuer settings
└── README.md                   # You're here
```

## 🛡️ JWT Authentication Flow
User logs in with valid credentials.

The API returns a JWT access token.

On subsequent requests, the token must be sent in the Authorization header:
`Authorization: Bearer <your_token>`

Middleware validates the token and sets the user context.

Endpoint executes if the token is valid and user is authorized.

## ✋ Allow Anonymous
You can allow public access to specific routes using the `[AllowAnonymous]` attribute.

Middleware automatically skips token validation for these routes.

```bash
[HttpPost("login")]
[AllowAnonymous]
public IActionResult Login(LoginRequest request) { ... }
```

## ✅ Policy-Based Authorization
Authorization policies are added in Program.cs:

```bash
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser().Build();
});
```
Build and execute the project.
Swagger is enabled to test the available endpoints.
