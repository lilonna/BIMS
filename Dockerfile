# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the csproj file and restore dependencies
COPY BIMS/BIMS.csproj ./BIMS/
RUN dotnet restore ./BIMS/BIMS.csproj

# Copy the full source code and build
COPY . .
WORKDIR /src/BIMS
RUN dotnet publish -c Release -o /app/out

# Use the ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Set environment variable and expose port
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "BIMS.dll"]
