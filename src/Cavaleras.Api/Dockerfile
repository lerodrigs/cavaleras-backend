#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Cavaleras.Api/Cavaleras.Api.csproj", "Cavaleras.Api/"]
COPY ["Cavaleras.CrossCutting/Cavaleras.CrossCutting.csproj", "Cavaleras.CrossCutting/"]
COPY ["Cavaleras.Data/Cavaleras.Data.csproj", "Cavaleras.Data/"]
COPY ["Calaveras.Domain/Calaveras.Domain.csproj", "Calaveras.Domain/"]
COPY ["Cavaleras.Service/Cavaleras.Service.csproj", "Cavaleras.Service/"]
RUN dotnet restore "Cavaleras.Api/Cavaleras.Api.csproj"
COPY . .
WORKDIR "/src/Cavaleras.Api"
RUN dotnet build "Cavaleras.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cavaleras.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cavaleras.Api.dll"]