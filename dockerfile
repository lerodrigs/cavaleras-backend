FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build 
WORKDIR /src

COPY ./src /src
WORKDIR /src
RUN dotnet restore && dotnet build

FROM build AS runtime
WORKDIR /src/Cavaleras.Api
ENTRYPOINT ["dotnet", "run", "--urls", "http://*:5000;http://*:5001"]