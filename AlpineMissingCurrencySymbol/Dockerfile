# Builder image
FROM mcr.microsoft.com/dotnet/core/sdk:2.1.700-alpine AS builder
WORKDIR /sln

COPY ./*.sln ./

# Copy the main source project files
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

# Copy the test project files
COPY test/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p test/${file%.*}/ && mv $file test/${file%.*}/; done

RUN dotnet restore

# Copy across the rest of the source files
COPY ./test ./test
COPY ./src ./src

RUN dotnet build -c Release

RUN dotnet test "./test/AlpineMissingCurrencySymbol.Tests/AlpineMissingCurrencySymbol.Tests.csproj" \
    -c Release --no-build --no-restore

RUN dotnet publish "./src/AlpineMissingCurrencySymbol/AlpineMissingCurrencySymbol.csproj" \
    -c Release -o "../../dist" --no-restore

# App image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1.11-alpine
# TWO LINES MAKE THE GLOBALIZATION WORK IN ALPINE IMAGES
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs
WORKDIR /app
ENTRYPOINT ["dotnet", "AlpineMissingCurrencySymbol.dll"]
COPY --from=builder /sln/dist .