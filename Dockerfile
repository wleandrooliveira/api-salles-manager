# Etapa 1: Constru��o
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar os arquivos do projeto e restaurar depend�ncias
COPY *.csproj .
RUN dotnet restore

# Copiar o restante do c�digo e compilar a aplica��o
COPY . .
RUN dotnet publish -c Release -o out

# Etapa 2: Execu��o
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Exp�e a porta usada pela aplica��o
EXPOSE 80
ENTRYPOINT ["dotnet", "api_salles_manager.dll"]
