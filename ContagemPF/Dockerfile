# Etapa base: imagem de runtime do ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build: imagem com SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos do projeto
COPY ["contagemAPI.csproj", "./"]
RUN dotnet restore "./contagemAPI.csproj"

# Copia o restante dos arquivos e compila
COPY . .
RUN dotnet publish "contagemAPI.csproj" -c Release -o /app/publish

# Etapa final: junta tudo e define o entrypoint
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "contagemAPI.dll"]
