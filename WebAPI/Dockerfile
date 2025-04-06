# 1. aşama: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Proje dosyalarını kopyala
COPY . . 

# Projeyi publish et (çıkışı /out klasörüne al)
RUN dotnet publish -c Release -o /out

# 2. aşama: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Publish edilmiş dosyaları kopyala
COPY --from=build /out .

# Uygulamayı başlat
ENTRYPOINT ["dotnet", "WebAPI.dll"]
