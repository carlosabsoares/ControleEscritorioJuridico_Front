# BUILD
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet publish ./CEJ_WebApp/CEJ_WebApp.csproj -c Release -o /app/publish

# RUNTIME
FROM nginx:alpine

COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

EXPOSE 80