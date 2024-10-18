# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

ARG CONNECTION_STRING
ARG DATABASE_NAME
ARG COLLECTION_NAME

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DynamicForms.API/DynamicForms.Presentation.csproj", "DynamicForms.API/"]
RUN dotnet restore "./DynamicForms.API/DynamicForms.Presentation.csproj"
COPY . .
WORKDIR "/src/DynamicForms.API"
RUN dotnet build "./DynamicForms.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DynamicForms.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV CompanyRepositorySettings__ConnectionString=${CONNECTION_STRING} \
    CompanyRepositorySettings__DatabaseName=${DATABASE_NAME} \
    CompanyRepositorySettings__CollectionName=${COLLECTION_NAME}

ENTRYPOINT ["dotnet", "DynamicForms.Presentation.dll"]