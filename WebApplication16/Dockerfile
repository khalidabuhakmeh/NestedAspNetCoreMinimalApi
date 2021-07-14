FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApplication16/WebApplication16.csproj", "WebApplication16/"]
RUN dotnet restore "WebApplication16/WebApplication16.csproj"
COPY . .
WORKDIR "/src/WebApplication16"
RUN dotnet build "WebApplication16.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication16.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication16.dll"]
