# Используем образ SDK для сборки проекта
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем .csproj файл и восстанавливаем зависимости
COPY ["LearningCourses.csproj", "./"]
RUN dotnet restore

# Копируем все файлы и собираем проект
COPY . .
RUN dotnet build -c Release -o /app/build

# Публикуем собранный проект
RUN dotnet publish -c Release -o /app/publish

# Используем образ для ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

# Копируем опубликованные файлы
COPY --from=build /app/publish .

# Копируем .csproj файл в рабочую директорию контейнера
COPY ["LearningCourses.csproj", "./"]

# Устанавливаем EF Core CLI tools
RUN dotnet tool install --global dotnet-ef

# Обеспечиваем доступ к установленным глобальным инструментам
ENV PATH="${PATH}:/root/.dotnet/tools"

# Указываем команду запуска
ENTRYPOINT ["dotnet", "LearningCourses.dll"]