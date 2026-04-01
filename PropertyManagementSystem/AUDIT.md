# Project Skeleton Audit

**Date:** 2026-04-01  
**Author:** Цветомир

## 1. Current structure
- **Solution name:** PropertyManagementSystem
- **Projects present:** PropertyManagementSystem.Web (ASP.NET Core MVC)
- **Key files / folders visible:** Program.cs; appsettings.json; appsettings.Development.json; wwwroot (css, js, lib); Controllers (HomeController); Views (Home, Shared); AUDIT.md

## 2. Present entities and DB context
- **ApplicationDbContext:** не е намерен / не е конфигуриран
- **Entities present:** няма дефинирани домейн ентити в отделен проект (в Web виждам само ErrorViewModel)

## 3. Identity and Authentication
- **Identity configured:** не (Authentication = None при създаване)
- **Roles seeded:** не
