# Estágio de Compilação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar tudo e restaurar as dependências
COPY . ./
RUN dotnet restore

# Buildar e publicar o projeto de forma otimizada
RUN dotnet publish -c Release -o out

# Estágio de Execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Definir as variáveis de ambiente necessárias
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "FreightManagement.Api.dll"]