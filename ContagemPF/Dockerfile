# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o .csproj corretamente
COPY ["ContagemPF/ContagemPF.csproj", "ContagemPF/"]
RUN dotnet restore "ContagemPF/ContagemPF.csproj"

# Copia o restante dos arquivos
COPY . .
WORKDIR "/src/ContagemPF"
RUN dotnet publish "ContagemPF.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ContagemPF.dll"]
