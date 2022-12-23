#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Log.Accenture.Api/Log.Accenture.Api.csproj", "Log.Accenture.Api/"]
COPY ["Log.Accenture.Application/Log.Accenture.Application.csproj", "Log.Accenture.Application/"]
COPY ["Log.Accenture.Domain/Log.Accenture.Domain.csproj", "Log.Accenture.Domain/"]
COPY ["Log.Accenture.Domain.Core/Log.Accenture.Domain.Core.csproj", "Log.Accenture.Domain.Core/"]
COPY ["Log.Accenture.Infra.Data/Log.Accenture.Infra.Data.csproj", "Log.Accenture.Infra.Data/"]
COPY ["Log.Accenture.Infra.Logs/Log.Accenture.Infra.Logs.csproj", "Log.Accenture.Infra.Logs/"]
RUN dotnet restore "Log.Accenture.Api/Log.Accenture.Api.csproj"
COPY . .
WORKDIR "/src/Log.Accenture.Api"
RUN dotnet build "Log.Accenture.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Log.Accenture.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Log.Accenture.Api.dll"]