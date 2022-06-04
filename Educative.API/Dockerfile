FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /educative-api

COPY *.csproj ./
RUN dotnet restore

COPY . /educative-api/
RUN dotnet publish -c Release -o Output

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime-env
WORKDIR /educative-api
EXPOSE 80
COPY --from=build-env /educative-api/Output .
ENTRYPOINT ["dotnet", "Educative.API.dll"]: