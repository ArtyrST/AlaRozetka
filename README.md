# 🏠 AlaRozetka

Платформа для оренди нерухомості з можливістю спілкування між ріелторами та користувачами.

---

## 🛠 Технології

### Backend
- **ASP.NET Core** — REST API
- **Entity Framework Core** — ORM
- **SQL Server** — база даних
- **MailKit** — відправка email
- **SignalR** — чат в реальному часі
- **BCrypt** — хешування паролів
- **AutoMapper** — маппінг сутностей
- **JWT** — автентифікація

### Frontend
- **React + Vite** — UI
- **TypeScript** — типізація
- **SCSS** — стилі

---

## 🚀 Запуск проєкту

### Backend

1. Клонуй репозиторій
```bash
git clone https://github.com/ArtyrST/AlaRozetka.git
```

2. Створи `appsettings.json` в папці `BackEnd/AlaBackEnd/AlaBackEnd/` на основі прикладу:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=AlaRozetka;Trusted_Connection=True;"
  },
  "EmailSettings": {
    "Host": "smtp.gmail.com",
    "Email": "your@gmail.com",
    "Password": "your_app_password"
  },
  "JwtSettings": {
    "Secret": "your_secret_key",
    "Issuer": "AlaRozetka",
    "Audience": "AlaRozetka"
  }
}
```

3. Застосуй міграції
```bash
dotnet ef database update
```

4. Запусти проєкт
```bash
dotnet run
```

### Frontend

```bash
cd vite-project
npm install
npm run dev
```

---

## 📌 Функціонал

- ✅ Реєстрація з підтвердженням email (OTP)
- ✅ Авторизація через JWT
- ✅ Перегляд оголошень нерухомості
- ✅ Кошик
- ✅ Чат між ріелтором та користувачем (SignalR)
- ✅ Ролі користувачів (юзер / ріелтор / адмін)

---

## 📁 Структура проєкту

```
AlaRozetka/
├── BackEnd/
│   └── AlaBackEnd/
│       ├── AlaBackEnd/          # API layer (Controllers)
│       ├── AlaBackEnd.BLL/      # Business Logic Layer (Services)
│       └── AlaBackEnd.DAL/      # Data Access Layer (Repositories, Entities)
└── vite-project/                # Frontend (React + TypeScript)
```

---

## ⚙️ Змінні середовища

| Змінна | Опис |
|---|---|
| `ConnectionStrings:DefaultConnection` | Рядок підключення до БД |
| `EmailSettings:Email` | Gmail акаунт для відправки листів |
| `EmailSettings:Password` | Пароль додатку Google |
| `JwtSettings:Secret` | Секретний ключ для JWT |
