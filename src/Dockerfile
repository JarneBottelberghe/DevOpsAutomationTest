# Build stage, focal is voor ubuntu 22.04
FROM mcr.microsof.com/dotnet/sdk:6.0-focal As build
WORKDIR /source
COPY . .
RUN dotnet restore "../SportStore.sln" --disable-parallel
RUN dotnet publish "../SportStore.sln" -c release -o /app --no-restore
#serve stage
FROM mcr.microsof.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet","SportStore.API.dll"]
