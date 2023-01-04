#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["MicroService.Order/MicroService.Order.csproj", "MicroService.Order/"]
COPY ["EventBusRabbitMQ/EventBusRabbitMQ.csproj", "EventBusRabbitMQ/"]
COPY ["Order.Infrastructure/Order.Infrastructure.csproj", "Order.Infrastructure/"]
COPY ["Order.Domain/Order.Domain.csproj", "Order.Domain/"]
COPY ["Order.Application/Order.Application.csproj", "Order.Application/"]
RUN dotnet restore "MicroService.Order/MicroService.Order.csproj"
COPY . .
WORKDIR "/src/MicroService.Order"
RUN dotnet build "MicroService.Order.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService.Order.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService.Order.dll"]
