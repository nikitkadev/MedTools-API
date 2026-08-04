# MedTools Web — Refactoring Plan & Naming Dictionary

> Версия документа: 1.0  
> База: MedTools Web `v0.2.0`  
> Цель: превратить завершённый вертикальный срез RControl в устойчивую, последовательно именованную и готовую к развитию внутреннюю платформу.

---

# 1. Теги важности

| Тег | Значение | Правило |
|---|---|---|
| `P0 — Blocker` | Критический дефект | Ломает данные, безопасность или основной сценарий. Исправляется немедленно. |
| `P1 — Must Fix` | Обязательно до production | Может привести к неправильным данным, падениям, stale state или некорректной авторизации. |
| `P2 — Should Fix` | Ближайший технический спринт | Не ломает сценарий сейчас, но заметно ухудшает сопровождение и развитие. |
| `P3 — Improve` | Улучшение | Полезно, но не блокирует эксплуатацию и следующие функции. |
| `ADR` | Архитектурное решение | Требует отдельной фиксации причины, альтернатив и последствий. |
| `Naming` | Именование | Изменение терминов, пространств имён, классов, DTO и API. |
| `Contract` | API-контракт | Backend ↔ frontend, nullable, даты, property names, OpenAPI. |
| `Security` | Безопасность | Authentication, authorization, permissions, data scope, audit. |
| `Reliability` | Надёжность | Ошибки, cancellation, retry, race conditions, health checks. |
| `Frontend` | Frontend | React, Zustand, hooks, UI state, components. |
| `Backend` | Backend | Application, Core, Infrastructure, Web. |
| `Tests` | Тестирование | Unit, integration, contract, UI scenario tests. |
| `Observability` | Наблюдаемость | Logging, metrics, tracing, diagnostics. |

---

# 2. Главный принцип рефакторинга

```text
Correctness
→ Contracts
→ Reliability
→ Security
→ Structure
→ Reuse
→ Production readiness
```

Не создавать generic-абстракцию до появления минимум трёх устойчивых одинаковых сценариев.

---

# 3. План рефакторинга

## Phase 1 — Correctness & Contracts

### `P0 — Blocker`

- [ ] `[P0][Contract][Frontend]` Исправить все несовпадения URL между API и frontend.
- [ ] `[P0][Contract]` Проверить property names всех response-моделей backend ↔ TypeScript.
- [ ] `[P0][Contract]` Привести nullable на frontend в соответствие с backend.
- [ ] `[P0][Frontend]` Исправить сдвинутые колонки и неправильные mappings полей.
- [ ] `[P0][Frontend]` Добавить `key` во все `.map()` таблиц и списков.
- [ ] `[P0][Frontend]` Исправить эффекты с пустыми или неполными dependency arrays.

### `P1 — Must Fix`

- [ ] `[P1][Frontend][Reliability]` Реализовать каскадную очистку дочернего state.
- [ ] `[P1][Frontend][Reliability]` Защититься от race conditions через `AbortController` или TanStack Query.
- [ ] `[P1][Contract]` Типизировать даты API как ISO strings, а не JavaScript `Date`.
- [ ] `[P1][Contract]` Добавить полный ручной contract audit перед генерацией клиента.
- [ ] `[P1][Contract][ADR]` Выбрать генерацию TypeScript client/types из OpenAPI.

### Definition of Done

- Смена любого родителя не показывает данные предыдущего выбора.
- Отсутствующая сущность не вызывает runtime exception.
- Все API-маршруты проверены интеграционными тестами.
- Все поля response имеют одинаковую семантику и nullability на обеих сторонах.

---

## Phase 2 — Backend Reliability

### `P1 — Must Fix`

- [ ] `[P1][Backend][Reliability]` Протянуть `CancellationToken` до EF Core.
- [ ] `[P1][Backend][Reliability]` Заменить синхронные `AsEnumerable().FirstOrDefault()` на async-вызовы.
- [ ] `[P1][Backend]` Убрать неконтролируемый `Enum.Parse` из endpoint-ов.
- [ ] `[P1][Backend][Reliability]` Добавить global exception handler.
- [ ] `[P1][Backend][Reliability]` Создать типизированную модель `Error`.
- [ ] `[P1][Backend]` Сделать единый `Result → HTTP` mapper.
- [ ] `[P1][Backend]` Перестать возвращать любой failure как `400 Bad Request`.

### `P2 — Should Fix`

- [ ] `[P2][Backend]` Добавить validation pipeline behavior.
- [ ] `[P2][Backend][Observability]` Добавить logging pipeline behavior.
- [ ] `[P2][Backend][Observability]` Замерять длительность application request и SQL operation.
- [ ] `[P2][Backend]` Переименовать read-операции из `Command` в `Query`.
- [ ] `[P2][Backend]` Убрать `FromStoredProcedure` из repository contracts.

### Базовый Error Dictionary

| ErrorType | HTTP | Пример |
|---|---:|---|
| `Validation` | 400 | Некорректный UID, неизвестная база, неверный период |
| `Unauthorized` | 401 | Нет или истёк access token |
| `Forbidden` | 403 | Нет permission на модуль или организацию |
| `NotFound` | 404 | Конкретная запрошенная сущность отсутствует |
| `Conflict` | 409 | Статус не позволяет операцию, запись уже существует |
| `BusinessRule` | 422 | Запрос корректен, но нарушает бизнес-правило |
| `Database` | 500/503 | Ошибка выполнения операции в БД |
| `Timeout` | 504 | БД или внешний ресурс не ответил вовремя |
| `Unexpected` | 500 | Непредусмотренная ошибка приложения |

Пустой список не является `404`.

---

## Phase 3 — Security & Access Model

### `P1 — Must Fix`

- [ ] `[P1][Security]` Добавить обязательную authorization policy на `/rcontrol`.
- [ ] `[P1][Security]` Определить permissions вместо прямых проверок ролей.
- [ ] `[P1][Security]` Ограничить доступ по организации и целевой БД.
- [ ] `[P1][Security]` Не доверять `targetDb` только потому, что он пришёл от клиента.
- [ ] `[P1][Security]` Добавить audit для чувствительных операций и просмотра ограниченных данных.

### Permission Dictionary

```text
RControl.Access
RControl.ViewInvoices
RControl.ViewCases
RControl.ViewPatientInsurance
RControl.ViewMedicalCase
RControl.ViewOncology
RControl.ViewProvidedServices
RControl.ViewPaymentClassification
RControl.ViewReferrals
RControl.ViewDefects
RControl.ViewSanctions
RControl.Export
```

Роль — это набор permissions. Handler проверяет permission и data scope конкретного use case.

---

## Phase 4 — Structural Cleanup

### `P2 — Should Fix`

- [ ] `[P2][Backend]` Разбить `RControlData` на endpoint-группы.
- [ ] `[P2][Backend]` Разделить namespaces по features.
- [ ] `[P2][Frontend]` Разделить крупные category pages на секции.
- [ ] `[P2][Frontend]` Добавить actions в stores вместо набора независимых setters.
- [ ] `[P2][Naming]` Исправить `RContol`, `Onkology`, `KsgKmp` и другие опечатки.
- [ ] `[P2][Naming]` Провести переименование категорий по словарю ниже.

### Целевая backend-структура

```text
Application/
└── RControl/
    ├── Filters/
    ├── InvoiceOverview/
    ├── MedicalCases/
    └── Categories/
        ├── PatientInsurance/
        ├── MedicalCase/
        ├── Oncology/
        ├── ProvidedServices/
        ├── PaymentClassification/
        ├── Referrals/
        └── ReviewFindings/

Core/
└── RControl/
    ├── Contracts/
    ├── Errors/
    ├── Permissions/
    └── Models/

Infrastructure/
└── RControl/
    ├── Persistence/
    ├── Repositories/
    └── StoredProcedureResults/

Web/
└── Endpoints/
    └── RControl/
        ├── FiltersEndpoints.cs
        ├── InvoiceOverviewEndpoints.cs
        ├── MedicalCasesEndpoints.cs
        └── Categories/
```

---

## Phase 5 — Frontend State & UI Platform

### `P1 — Must Fix`

- [ ] `[P1][Frontend]` Отделить server state от UI state.
- [ ] `[P1][Frontend]` Выбрать TanStack Query или строгую state machine поверх Zustand.
- [ ] `[P1][Frontend]` Унифицировать loading/error/empty states.

### `P2 — Should Fix`

- [ ] `[P2][Frontend]` Создать `InfoField`.
- [ ] `[P2][Frontend]` Создать `InfoCard`.
- [ ] `[P2][Frontend]` Создать `DataTableCard`.
- [ ] `[P2][Frontend]` Создать `CategorySection`.
- [ ] `[P2][Frontend]` Разделить `Oncology` и другие крупные страницы.
- [ ] `[P2][Frontend]` Сделать responsive-поведение широких таблиц.

### Не делать

- универсальную таблицу со всеми возможными props;
- generic category store;
- один огромный `useRControlStore`;
- бизнес-логику внутри визуальных shared-компонентов.

---

## Phase 6 — Tests & Production Readiness

### `P1 — Must Fix`

- [ ] `[P1][Tests]` Integration tests для основных endpoint-ов.
- [ ] `[P1][Tests]` Tests каскадной очистки store.
- [ ] `[P1][Tests]` Tests отсутствующих nullable-сущностей.
- [ ] `[P1][Tests]` Tests быстрых переключений A → B.
- [ ] `[P1][Tests]` Tests permission/data scope.
- [ ] `[P1][Reliability]` Health checks для приложения и БД.

### `P2 — Should Fix`

- [ ] `[P2][Observability]` Structured logging.
- [ ] `[P2][Observability]` OpenTelemetry tracing.
- [ ] `[P2][Observability]` Метрики длительности и ошибок.
- [ ] `[P2][Tests]` Contract tests OpenAPI client.
- [ ] `[P2]` CI: build, lint, test, typecheck.

---

# 4. Правила именования

## 4.1. Язык кода

- Имена классов, методов, namespaces, API resources и frontend types — только на английском.
- Русские названия допустимы только в UI labels и официальных документах.
- Транслитерация (`NazNapr`, `Napravlenie`, `Sluch`, `Sank`) запрещена в domain/application-коде.
- Имена SQL column/procedure могут оставаться legacy, но изолируются в Infrastructure mapping.

```text
Legacy DB term
→ Infrastructure mapping
→ Normal English domain/application term
```

```csharp
builder.Property(x => x.ReferralDate)
    .HasColumnName("napr_date");
```

---

## 4.2. Category vs Feature vs Entity

### Category

UI-группа данных внутри RControl.

```text
Oncology
Provided Services
Referrals
Review Findings
```

### Feature

Пользовательский сценарий или самостоятельная область приложения.

```text
Invoice Overview
Medical Case Explorer
User Administration
```

### Entity

Сущность с идентичностью и жизненным циклом.

```text
Invoice
MedicalCase
OncologyCase
ProvidedService
Referral
Sanction
```

Не называть любой response-класс `Model`.

---

## 4.3. DTO, Model, Entity, Result

### Entity

Объект предметной области с идентичностью и поведением.

```csharp
public sealed class User
public sealed class Invoice
```

### DTO

Контракт передачи данных между слоями или наружу.

```csharp
PatientInsuranceDto
ProvidedServiceDto
```

DTO не должен одновременно быть HTTP response, domain entity, EF stored procedure mapping и frontend contract.

### Stored Procedure Row / Projection

Результат конкретной SQL-процедуры.

```csharp
OncologyCaseRow
ProvidedServiceRow
ReferralRow
SanctionRow
```

Расположение:

```text
Infrastructure/RControl/StoredProcedureResults/
```

Конфигурация:

```csharp
OncologyCaseRowConfiguration
ProvidedServiceRowConfiguration
```

### Application Result

Результат use case.

```csharp
GetOncologyCaseResult
GetPaymentClassificationResult
GetReviewFindingsResult
```

### API Response

Если HTTP-форма отличается от application result:

```csharp
OncologyCaseResponse
ReviewFindingsResponse
```

Если не отличается — отдельный класс не нужен.

### Frontend Type

Повторяет API-контракт:

```ts
GetOncologyCaseResponse
ReviewFindingsResponse
```

Лучше генерировать из OpenAPI.

### View Model

Использовать только для формы, подготовленной специально для UI:

```ts
OncologySummaryViewModel
```

---

## 4.4. Request naming

### Read

```csharp
GetOncologyCaseQuery
GetOncologyCaseQueryHandler
```

### Write

```csharp
CreateUserCommand
CreateUserCommandHandler
UpdateInvoiceStatusCommand
```

### Validator

```csharp
GetOncologyCaseQueryValidator
```

### Result

```csharp
GetOncologyCaseResult
```

---

## 4.5. Repository naming

```csharp
IOncologyRepository
IProvidedServicesRepository
IReviewFindingsRepository
```

```csharp
GetOncologyCaseAsync
GetProvidedServicesAsync
GetSanctionsAsync
```

Не использовать:

```csharp
GetDataFromStoredProcedureAsync
GetNazNaprAsync
GetSanksAsync
```

---

## 4.6. EF Core configuration naming

Для entity:

```csharp
UserConfiguration : IEntityTypeConfiguration<User>
```

Для stored procedure projection:

```csharp
ReferralRowConfiguration : IEntityTypeConfiguration<ReferralRow>
```

Не использовать:

```text
ReferralDtoModelConfiguration
SomeDtoConfigurationModel
```

---

## 4.7. Endpoint naming

Файл:

```text
OncologyEndpoints.cs
ReviewFindingsEndpoints.cs
```

Метод регистрации:

```csharp
MapOncologyEndpoints
MapReviewFindingsEndpoints
```

HTTP routes:

```text
/rcontrol/categories/patient-insurance
/rcontrol/categories/medical-case
/rcontrol/categories/oncology
/rcontrol/categories/provided-services
/rcontrol/categories/payment-classification
/rcontrol/categories/referrals
/rcontrol/categories/review-findings
```

---

# 5. Словарь категорий RControl

| Текущее имя | Новое backend/domain имя | UI на русском | Комментарий |
|---|---|---|---|
| `PatientSmo` | `PatientInsurance` | Пациент и страхование | СМО — деталь модели ОМС, категория содержит данные страхования пациента. |
| `Cases` | `MedicalCase` | Медицинский случай | `Cases` слишком общее и конфликтует с C# terminology. |
| `Oncology` | `Oncology` | Онкология | Хорошее устойчивое имя. |
| `ProvidedServices` | `ProvidedServices` | Оказанные услуги | Корректное имя. |
| `KsgVmp` | `PaymentClassification` | КСГ / ВМП | КСГ и ВМП — способы классификации и оплаты случая. |
| `NazNapr` | `Referrals` | Назначения и направления | Без транслитерации. При необходимости разделить на `MedicalOrders` и `Referrals`. |
| `DefectsSanks` | `ReviewFindings` | Дефекты и санкции | Общая категория результатов контроля. Внутри: `Defects`, `Sanctions`. |

---

# 6. Словарь сущностей

| Legacy/текущее | Рекомендуемое имя | Значение |
|---|---|---|
| `Schet` | `Invoice` | Счёт медицинской организации |
| `ZSl` / `ZSluch` | `CompletedCaseGroup` или `CareEpisode` | Законченный случай / эпизод помощи |
| `Sluch` | `MedicalCase` | Отдельный медицинский случай |
| `OncSluch` | `OncologyCase` | Онкологический случай |
| `OncService` | `OncologyService` | Онкологическая услуга |
| `Medicament` | `OncologyMedication` | Противоопухолевый препарат |
| `Injection` | `MedicationAdministration` | Факт введения препарата |
| `Usl` | `ProvidedService` | Оказанная услуга |
| `MedDev` | `MedicalDevice` | Медицинское изделие |
| `KsgKpg` | `CasePaymentGroup` | КСГ / КПГ классификация |
| `Crit` | `ClassificationCriterion` | Классификационный критерий |
| `SlKoef` | `SpecialConditionCoefficient` | КСЛП / коэффициент сложности |
| `Naz` | `MedicalOrder` | Назначение |
| `Napr` | `Referral` | Направление |
| `Defect` | `ReviewDefect` | Дефект, найденный контролем |
| `Sank` | `Sanction` | Финансовая или иная санкция |
| `Smo` | `InsuranceOrganization` | Страховая медицинская организация |
| `Mo` | `MedicalOrganization` | Медицинская организация |

---

# 7. Спорные термины, которые нужно подтвердить с предметником

| Legacy term | Кандидаты | Что уточнить |
|---|---|---|
| `ZSl` | `CareEpisode`, `CompletedCaseGroup`, `CompletedCareCase` | Это эпизод лечения, группа случаев или законченный случай целиком? |
| `Naz` | `MedicalOrder`, `Prescription`, `Assignment` | Это назначение врача, диагностическое назначение или план услуги? |
| `KSLP` | `SpecialConditionCoefficient`, `TreatmentComplexityCoefficient` | Официальный смысл коэффициента в текущей версии НСИ. |
| `Defect` | `ReviewDefect`, `AuditFinding`, `ValidationIssue` | Дефект формата, МЭК, МЭЭ или общий результат контроля? |
| `Sanction` | `Sanction`, `PaymentAdjustment`, `FinancialPenalty` | Это только штраф или любое уменьшение оплаты? |
| `KSG/KPG` | `CasePaymentGroup`, `ClinicalStatisticalGroup` | Нужна ли официальная английская аббревиатура или внутренний нейтральный термин? |

До подтверждения использовать нейтральные имена и добавить glossary-комментарии.

---

# 8. Стратегия миграции имён

## Шаг 1 — Dictionary ADR

- Зафиксировать утверждённые термины.
- Согласовать значения спорных сущностей.
- Не менять код до утверждения словаря.

## Шаг 2 — Namespaces and folders

```text
NazNapr → Referrals
DefectsSanks → ReviewFindings
KsgVmp → PaymentClassification
```

## Шаг 3 — Application classes

```text
GetNazNaprDataCommand
→ GetReferralsQuery
```

## Шаг 4 — Repository contracts

```text
INazNaprCategoryRepository
→ IReferralsRepository
```

## Шаг 5 — Infrastructure projections

```csharp
public string? ReferralOrganizationCode { get; init; }

builder.Property(x => x.ReferralOrganizationCode)
    .HasColumnName("napr_mo");
```

## Шаг 6 — API routes

Сначала добавить новые routes, старые временно оставить deprecated:

```text
/new: /rcontrol/categories/referrals
/old: /rcontrol/categories/naz-napr
```

## Шаг 7 — Frontend

```text
NazNapr → Referrals
useNazNaprCategory → useReferrals
DefectsSanks → ReviewFindings
KsgVmp → PaymentClassification
```

## Шаг 8 — Remove compatibility layer

Удалить deprecated routes и aliases после одного релизного цикла.

---

# 9. ADR, которые нужно создать

- [ ] `ADR-001 — RControl domain terminology`
- [ ] `ADR-002 — Server state: TanStack Query vs Zustand`
- [ ] `ADR-003 — Generated OpenAPI client`
- [ ] `ADR-004 — Error model and HTTP mapping`
- [ ] `ADR-005 — Permission-based authorization`
- [ ] `ADR-006 — Stored procedure projections vs transport DTO`
- [ ] `ADR-007 — Category endpoint structure`

---

# 10. Первый рекомендуемый спринт

## Sprint Goal

Устранить correctness-риски и утвердить язык проекта.

- [ ] Исправить URL, nullable, dates и mappings.
- [ ] Провести audit всех `useEffect`.
- [ ] Реализовать cascade reset.
- [ ] Протянуть `CancellationToken`.
- [ ] Создать `Error` и global exception handler.
- [ ] Создать `ADR-001` со словарём.
- [ ] Переименовать одну пилотную категорию: `NazNapr → Referrals`.
- [ ] Проверить стратегию миграции на backend, route и frontend.
- [ ] После пилота переименовать остальные категории отдельными PR.

---

# 11. Pull Request правила для рефакторинга

Каждый PR должен иметь:

```text
Problem
Scope
Non-goals
Naming changes
Contract changes
Migration notes
Tests
Screenshots / API examples
Risks
```

Не смешивать в одном PR:

- rename всей системы;
- изменение бизнес-логики;
- новую архитектурную абстракцию;
- обновление зависимостей;
- косметические изменения UI.

---

# 12. Итоговая цель

После завершения плана код должен читаться без знания федеральной транслитерации:

```csharp
var referrals = await referralsRepository.GetReferralsAsync(
    medicalCaseId,
    targetDatabase,
    cancellationToken);
```

Legacy-термины должны встречаться только в Infrastructure:

```csharp
builder.Property(x => x.ReferralDate)
    .HasColumnName("napr_date");
```

Это позволит:

- говорить на собеседовании нормальным инженерным языком;
- не тащить плохие имена БД в application/domain;
- проще подключать новых разработчиков;
- безболезненно менять источник данных;
- сохранить связь с официальной документацией через mapping и glossary.
