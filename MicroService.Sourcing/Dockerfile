#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["MicroService.Sourcing/MicroService.Sourcing.csproj", "MicroService.Sourcing/"]
COPY ["EventBusRabbitMQ/EventBusRabbitMQ.csproj", "EventBusRabbitMQ/"]
RUN dotnet restore "MicroService.Sourcing/MicroService.Sourcing.csproj"
COPY . .
WORKDIR "/src/MicroService.Sourcing"
RUN dotnet build "MicroService.Sourcing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService.Sourcing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService.Sourcing.dll"]