# BitePaper - Document Management System

BitePaper is a comprehensive document management system built with ASP.NET Core that provides document approval workflows, user management, and Google Drive integration for secure document storage and sharing.

## 🏗️ Architecture

The project follows Clean Architecture principles with clear separation of concerns:

- **BitePaper.Api** - Web API layer with FastEndpoints
- **BitePaper.Application** - Business logic with CQRS pattern using MediatR
- **BitePaper.Infrastructure** - Data access layer with MongoDB repositories
- **BitePaper.Models** - Domain entities and DTOs

## 🚀 Features

### Core Functionality
- **Document Management** - Upload, store, and manage documents with Google Drive integration
- **Approval Workflows** - Configurable multi-step approval processes
- **User Management** - Role-based access control and authentication
- **Comment System** - Document commenting and collaboration
- **Audit Logging** - Comprehensive activity tracking
- **Notifications** - Real-time user notifications

### Technical Features
- **CQRS Pattern** - Command Query Responsibility Segregation with MediatR
- **MongoDB Integration** - NoSQL database for flexible data storage
- **Google Drive API** - Secure cloud storage integration
- **JWT Authentication** - Secure token-based authentication
- **FastEndpoints** - Modern API endpoint framework
- **Clean Architecture** - Maintainable and testable code structure

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core 8.0
- **Database**: MongoDB
- **Authentication**: JWT + Google OAuth
- **File Storage**: Google Drive API
- **API Framework**: FastEndpoints
- **Messaging**: MediatR
- **Documentation**: Swagger/OpenAPI

## 📋 Prerequisites

- .NET 8.0 SDK
- MongoDB instance
- Google Drive API credentials
- Visual Studio 2022 or JetBrains Rider

## ⚙️ Configuration

### 1. Database Configuration
Update `appsettings.json` with your MongoDB connection:

```json
{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "BitePaperDB"
  }
}
```

### 2. Google Drive API Setup
1. Create a project in [Google Cloud Console](https://console.cloud.google.com)
2. Enable Google Drive API
3. Create service account credentials
4. Download credentials JSON file
5. Update configuration:

```json
{
  "GoogleDrive": {
    "CredentialsPath": "path/to/credentials.json"
  }
}
```

### 3. JWT Configuration
```json
{
  "JWT": {
    "SecretKey": "your-secret-key",
    "Issuer": "BitePaper",
    "Audience": "BitePaper-Users",
    "ExpirationMinutes": 60
  }
}
```

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone <repository-url>
cd backend-bitepaper
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Update Configuration
- Update `appsettings.json` with your database and API credentials
- Place Google Drive credentials file in the project root

### 4. Run the Application
```bash
dotnet run --project BitePaper.Api
```

The API will be available at `https://localhost:7000` with Swagger documentation at `/swagger`.

## 📚 API Endpoints

### Documents
- `POST /document/upload` - Upload document to Google Drive
- `GET /document/{id}` - Get document by ID
- `PUT /document/update/{id}` - Update document
- `DELETE /document/delete/{id}` - Delete document

### Users
- `POST /user/create` - Create new user
- `GET /user/{id}` - Get user by ID
- `PUT /user/update/{id}` - Update user
- `DELETE /user/delete/{id}` - Delete user

### Approval Flows
- `POST /approval-flow/create` - Create approval workflow
- `GET /approval-flow/{id}` - Get approval flow
- `PUT /approval-flow/update/{id}` - Update approval flow

### Comments
- `POST /document-comment/create` - Add document comment
- `GET /document-comment/update/{id}` - Update comment

### Logging
- `POST /log/create` - Create audit log entry
- `DELETE /log/delete/{id}` - Delete log entry

## 🏛️ Project Structure

```
BitePaper/
├── BitePaper.Api/
│   ├── Controllers/          # FastEndpoints controllers
│   ├── Program.cs           # Application entry point
│   └── appsettings.json     # Configuration
├── BitePaper.Application/
│   ├── Commands/            # CQRS commands
│   ├── Queries/             # CQRS queries
│   └── Handlers/            # MediatR handlers
├── BitePaper.Infrastructure/
│   ├── Repositories/        # Data access layer
│   ├── Services/            # Business services
│   └── Interfaces/          # Service contracts
└── BitePaper.Models/
    ├── Entities/            # Domain models
    └── DTOs/                # Data transfer objects
```

## 🔒 Security Features

- JWT-based authentication
- Google OAuth integration
- Role-based authorization
- Secure file access controls
- Audit logging for compliance

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🐛 Known Issues

- Update endpoint for document comments uses GET instead of PUT method
- Some endpoints allow anonymous access (marked with TODO for proper authorization)

## 📞 Support

For support and questions, please open an issue in the GitHub repository.
