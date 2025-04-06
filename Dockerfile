# 1. Aşama: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Tüm projeyi kopyala
COPY . .

# WebAPI projesini publish et
RUN dotnet publish WebAPI/WebAPI.csproj -c Release -o /app/out

# 2. Aşama: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "WebAPI.dll"]
