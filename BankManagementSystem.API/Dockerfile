FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../BankManagementSystem.API/BankManagementSystem.API.csproj", "../BankManagementSystem.API/"]
COPY ["MyServiceDefaults/MyServiceDefaults.csproj", "MyServiceDefaults/"]
COPY ["CleanArchitecture/BankManagementSystem.Presentation/BankManagementSystem.Presentation.csproj", "CleanArchitecture/BankManagementSystem.Presentation/"]
COPY ["CleanArchitecture/BankManagementSystem.Application/BankManagementSystem.Application.csproj", "CleanArchitecture/BankManagementSystem.Application/"]
COPY ["CleanArchitecture/BankManagementSystem.Domain/BankManagementSystem.Domain.csproj", "CleanArchitecture/BankManagementSystem.Domain/"]
COPY ["CleanArchitecture/BankManagementSystem.Infrastructure/BankManagementSystem.Infrastructure.csproj", "CleanArchitecture/BankManagementSystem.Infrastructure/"]
RUN dotnet restore "../BankManagementSystem.API/BankManagementSystem.API.csproj"
COPY . .
WORKDIR "/src/../BankManagementSystem.API"
RUN dotnet build "BankManagementSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BankManagementSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankManagementSystem.API.dll"]
