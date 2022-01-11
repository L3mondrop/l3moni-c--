
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app
EXPOSE 80 
COPY --from=build-env /app/published-app /app

RUN apk add build-base
COPY . .
RUN g++ -o test test.cpp
CMD ["./test"]
ENTRYPOINT [ "dotnet", "/app/l3moni-c++.dll" ]


