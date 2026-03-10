# Estágio 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura as dependências (cache em camadas)
COPY ["*.csproj", "."]
RUN dotnet restore

# Copia o resto do código e publica a aplicação
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Estágio 2: Imagem de runtime para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copia os arquivos publicados do estágio de build
COPY --from=build /app/publish .

# Comando para iniciar a aplicação
CMD find . -name "*.dll" -type f -not -name "*.Views.dll" | head -1 | xargs dotnet