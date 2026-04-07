

📌 1. Описание на проекта
Property Management System е уеб приложение, разработено като част от курса ASP.NET Advanced (SoftUni).
Целта е да предостави цялостна система за управление на недвижими имоти, включваща:
- Buildings
- Apartments
- Tenants
- Payments
- Потребителска автентикация и роли
Проектът използва ASP.NET Core MVC, Entity Framework Core, SQL Server, Identity и Bootstrap 5.

📌 2. Основни функционалности
🔐 Автентикация и авторизация
- Регистрация на потребители
- Вход и изход
- Роля Admin (създава се автоматично)
- Защитени контролери чрез [Authorize]
- Публичен достъп само до Home страниците
🏢 Buildings
- Преглед на всички сгради
- Създаване
- Редактиране
- Детайли
- Изтриване
🏬 Apartments
- CRUD операции
- Връзка към Building
- Dropdown избор на сграда
👤 Tenants
- CRUD операции
- Връзка към Apartment → Building
- Пълна информация за наемател
💳 Payments
- CRUD операции
- Връзка към Tenant → Apartment → Building
- Финансова точност: decimal(18,2)

📌 3. Технологии
|		Технология		 |		Описание		  | 
| ASP.NET Core MVC		 | Основна архитектура	  | 
| Entity Framework Core  | ORM и достъп до база   | 
| SQL Server			 | База данни			  | 
| ASP.NET Core Identity  | Login, Register, Roles | 
| Bootstrap 5			 | UI и оформление		  | 
|C# 10/11				 | Backend логика		  | 

📌 4. Архитектура на проекта
Проектът е разделен на три слоя:
1. Core
- Домейн модели
- ApplicationUser
- Entities: Building, Apartment, Tenant, Payment
2. Infrastructure
- AppDbContext
- Identity наследяване
- Миграции
- Конфигурации
3. Web
- Controllers
- Views
- ViewModels
- Program.cs
- Layout и UI

📌 5. Инсталация и стартиране
5.1 Клониране на репото
git clone <repository-url>


5.2 Настройка на базата данни
В appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=PropertyManagement;Trusted_Connection=True;MultipleActiveResultSets=true"
}


5.3 Миграции
update-database


5.4 Стартиране
dotnet run


5.5 Администраторски акаунт
Създава се автоматично:
- Email: admin@site.com
- Password: Admin123!

📌 6. Структура на базата данни
- Building → Apartments (1:N)
- Apartment → Tenants (1:N)
- Tenant → Payments (1:N)
- Identity таблици: AspNetUsers, AspNetRoles, AspNetUserRoles и др.

📌 7. Screenshots (по желание)
Добавете снимки от приложението.

📌 8. Автор
Цветомир Бойчев
ASP.NET Advanced — SoftUni
2026
