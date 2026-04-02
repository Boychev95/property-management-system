Project Skeleton Audit
Date: 2026-04-01
Author: Цветомир

## 1. Current structure
- Solution name: PropertyManagementSystem
- Projects present:
- PropertyManagementSystem (Web UI – ASP.NET Core MVC)
- PropertyManagementSystem.Core (Domain layer)
- PropertyManagementSystem.Infrastructure (Data layer)
- Key files / folders:
- Web: Program.cs, appsettings.json, Controllers, Views, wwwroot
- Core: Entities (Building, Apartment, Tenant, Payment, ApplicationUser)
- Infrastructure: ApplicationDbContext, DbInitializer
#### ✔ Status
Архитектурата е напълно изградена и разделена по слоеве (Web / Core / Infrastructure).
Структурата е логична, чиста и следва реални практики.

## 2. Present entities and DB context
### Entities present (в Core):
- Building
- Apartment
- Tenant
- Payment
- ApplicationUser
### ApplicationDbContext:
- Създаден в Infrastructure
- Наследява IdentityDbContext<ApplicationUser>
- Регистрира всички домейн ентитита
- Конфигуриран в Program.cs с SQL Server
- MigrationsAssembly е зададен правилно
#### ✔ Status
Domain моделът е напълно изграден.
DbContext е конфигуриран и готов за миграции.

## 3. Identity and Authentication
### Identity configured:
- Добавен в Program.cs
- Конфигурирани Password правила
- Изискване за уникален email
- Добавени Token Providers
- Настроени Cookies (LoginPath, AccessDeniedPath, ExpireTimeSpan)
### Roles seeded:
- Role: Admin
- User: admin@admin.com
- Password: Admin123!
- Добавен към ролята Admin
### DbInitializer:
- Създава база при нужда
- Създава роли
- Създава администратор
- Работи автоматично в Development
#### ✔ Status
Identity е напълно интегриран и работещ.
Authentication + Authorization са активни.

## 4. Controllers (current progress)
### Implemented controllers:
- BuildingsController
- ApartmentsController
- TenantsController
- PaymentsController
- HomeController
### Features:
- Пълен CRUD за всички домейн ентитита
- EF Core Includes за навигационни връзки
- Dropdown списъци за свързани обекти
- Чист, човешки и логичен код
#### ✔ Status
Контролерите са напълно готови и функционални.
