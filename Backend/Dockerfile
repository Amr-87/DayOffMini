# ===============================
# Runtime
# ===============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 5000

# ===============================
# Build
# ===============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution
COPY DayOffMini.sln .

# Copy project files (cache-friendly)
COPY DayOffMini.API/DayOffMini.API.csproj DayOffMini.API/
COPY DayOffMini.Application/DayOffMini.Application.csproj DayOffMini.Application/
COPY DayOffMini.Domain/DayOffMini.Domain.csproj DayOffMini.Domain/
COPY DayOffMini.Infrastructure/DayOffMini.Infrastructure.csproj DayOffMini.Infrastructure/
COPY DayOffMini.Infrastructure.Repository/DayOffMini.Infrastructure.Repository.csproj DayOffMini.Infrastructure.Repository/
COPY DayOffMini.Infrastructure.UnitOfWork/DayOffMini.Infrastructure.UnitOfWork.csproj DayOffMini.Infrastructure.UnitOfWork/

# Restore
RUN dotnet restore DayOffMini.sln

# Copy remaining source
COPY . .

# Publish API
RUN dotnet publish DayOffMini.API/DayOffMini.API.csproj -c Release -o /app

# ===============================
# Final
# ===============================
FROM runtime
WORKDIR /app
COPY --from=build /app .

# Just start the API
ENTRYPOINT ["dotnet", "DayOffMini.API.dll"]
