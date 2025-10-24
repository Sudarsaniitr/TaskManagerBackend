# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything
COPY . .

# Restore dependencies
RUN dotnet restore

# Build the app
RUN dotnet publish -c Release -o out

# Stage 2: Run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose default port for ASP.NET
EXPOSE 8080

# Start the app
ENTRYPOINT ["dotnet", "TaskManagerAPI.dll"]
