# Base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage for the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Ace_Aufgabe/Ace_Aufgabe.csproj", "Ace_Aufgabe/"]
RUN dotnet restore "Ace_Aufgabe/Ace_Aufgabe.csproj"
COPY . .
WORKDIR "/src/Ace_Aufgabe"
RUN dotnet build "Ace_Aufgabe.csproj" -c Release -o /app/build

# Publish stage to create the app
FROM build AS publish
RUN dotnet publish "Ace_Aufgabe.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ace_Aufgabe.dll"]
