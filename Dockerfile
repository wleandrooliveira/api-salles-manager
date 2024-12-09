# Etapa 1: Construção
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar os arquivos do projeto e restaurar dependências
COPY *.csproj .
RUN dotnet restore

# Copiar o restante do código e compilar a aplicação
COPY . .
RUN dotnet publish -c Release -o out

# Etapa 2: Execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta usada pela aplicação
EXPOSE 80
ENTRYPOINT ["dotnet", "api_salles_manager.dll"]
