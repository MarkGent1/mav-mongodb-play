# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Stage 1: Build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG VERSION=1.0.0

WORKDIR /src

COPY ["src/Mav.MongoWithDdd.Api/Mav.MongoWithDdd.Api.csproj", "Mav.MongoWithDdd.Api/"]
COPY ["src/Mav.MongoWithDdd.Infrastructure/Mav.MongoWithDdd.Infrastructure.csproj", "Mav.MongoWithDdd.Infrastructure/"]
COPY ["src/Mav.MongoWithDdd.Application/Mav.MongoWithDdd.Application.csproj", "Mav.MongoWithDdd.Application/"]
COPY ["src/Mav.MongoWithDdd.Core/Mav.MongoWithDdd.Core.csproj", "Mav.MongoWithDdd.Core/"]

RUN dotnet restore "Mav.MongoWithDdd.Api/Mav.MongoWithDdd.Api.csproj" -r linux-x64 -v n
RUN dotnet restore "Mav.MongoWithDdd.Infrastructure/Mav.MongoWithDdd.Infrastructure.csproj" -r linux-x64 -v n
RUN dotnet restore "Mav.MongoWithDdd.Application/Mav.MongoWithDdd.Application.csproj" -r linux-x64 -v n
RUN dotnet restore "Mav.MongoWithDdd.Core/Mav.MongoWithDdd.Core.csproj" -r linux-x64 -v n

COPY ["src/", "."]

WORKDIR "Mav.MongoWithDdd.Api"
RUN dotnet publish "Mav.MongoWithDdd.Api.csproj" -v n -c ${BUILD_CONFIGURATION} -o /app -r linux-x64 --no-restore /p:Version=${VERSION}

# Stage 2: Runtime image for debugging in VS
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS vsdebug
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=build /app .
ENTRYPOINT ["./Mav.MongoWithDdd.Api"]