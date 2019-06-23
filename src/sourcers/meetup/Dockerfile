FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["svc/Tehk.Sourcers.Meetup.Svc.csproj", "svc/"]
RUN dotnet restore "svc/Tehk.Sourcers.Meetup.Svc.csproj"
COPY . .
WORKDIR "/src/svc"
RUN dotnet build "Tehk.Sourcers.Meetup.Svc.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Tehk.Sourcers.Meetup.Svc.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tehk.Sourcers.Meetup.Svc.dll"]
