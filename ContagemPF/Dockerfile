# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o .csproj corretamente
COPY ["contagemAPI/contagemAPI.csproj", "contagemAPI/"]
RUN dotnet restore "contagemAPI/contagemAPI.csproj"

# Copia o restante dos arquivos
COPY . .
WORKDIR "/src/contagemAPI"
RUN dotnet publish "contagemAPI.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "contagemAPI.dll"]
