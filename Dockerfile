FROM microsoft/dotnet:2.2-sdk-alpine AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers,
# We must import all the required dependencies in the solution.
COPY IPMA.sln ./
COPY IPMA.Core/*.csproj ./IPMA.Core/
COPY IPMA.Web/*.csproj ./IPMA.Web/

RUN dotnet restore

# Copy everything else and build
COPY . ./
WORKDIR /app/IPMA.Core
RUN dotnet publish -c Release -o out

WORKDIR /app/IPMA.Web
RUN dotnet publish -c Release -o out

# Build the image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=build-env /app/IPMA.Web/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet IPMA.Web.dll