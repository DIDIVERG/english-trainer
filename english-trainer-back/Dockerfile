FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["english-trainer-back/english-trainer-back.csproj", "english-trainer-back/"]
RUN dotnet restore "english-trainer-back/english-trainer-back.csproj"
COPY . .
WORKDIR "/src/english-trainer-back"
RUN dotnet build "english-trainer-back.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "english-trainer-back.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "english-trainer-back.dll"]
