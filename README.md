# ApiByVibeCoding

A .NET 8 Web API project that demonstrates clean architecture principles by consuming JSONPlaceholder API endpoints.

## Features

- **Posts API**: Full CRUD operations for posts
- **Comments API**: Full CRUD operations for comments
- **Swagger Documentation**: Interactive API documentation
- **Clean Architecture**: Layered structure with proper separation of concerns

## Architecture

The project follows a layered architecture pattern:

- **Controllers**: Handle HTTP requests and responses
- **Services**: Business logic and orchestration
- **Repositories**: Data access and external API calls
- **Models**: Data structures and entities

## API Endpoints

### Posts
- `GET /api/posts` - Get all posts
- `POST /api/posts` - Create a new post
- `PUT /api/posts/{id}` - Update an existing post
- `DELETE /api/posts/{id}` - Delete a post

### Comments
- `GET /api/comments` - Get all comments
- `POST /api/comments` - Create a new comment
- `PUT /api/comments/{id}` - Update an existing comment
- `DELETE /api/comments/{id}` - Delete a comment

## Technologies

- .NET 8
- ASP.NET Core Web API
- Swagger/OpenAPI
- HttpClient for external API consumption

## Getting Started

1. Clone the repository
2. Run `dotnet restore`
3. Run `dotnet run`
4. Navigate to `/swagger` to explore the API documentation

## External APIs

This project consumes data from [JSONPlaceholder](https://jsonplaceholder.typicode.com/):
- Posts: `https://jsonplaceholder.typicode.com/posts`
- Comments: `https://jsonplaceholder.typicode.com/comments`