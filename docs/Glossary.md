# Глоссарий ТФОМС РХ

## Предисловие

Данный документ является единым словарём предметной области информационных систем **ТФОМС РХ**.

Его основная задача — установить соответствие между терминологией **ФФОМС**, использующей исторически сложившуюся транслитерацию, и доменной моделью программных продуктов **ТФОМС РХ**.

## Базовые понятия

| Доменное название | Идентификатор в коде | Перевод |
| --- | --- | --- |
| `Medical Organization` | `MedicalOrganization` | Медицинская организация |
| `Insurance Organization` | `InsuranceOrganization` | Страховая организация |
| `Insurance Organization Code` | `InsuranceOrganizationCode` | Код страховой организации |
| `Medical Organization Code` | `MedicalOrganizationCode` | Код медицинской организации |
| `Patient` | `Patient` | Пациент |
| `Billing Period` | `BillingPeriod` | Расчетный период | 

## Формат ФФОМС 
### Таблица `SCHET`

| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| --- | --- | --- | --- | --- |
| `SCHET` | `dbo.schet` | `Invoice` | `Invoice` | Счет |
| `CODE` | `code` | `Invoice Code` | `InvoiceCode` | Уникальный код счета |
| `CODE_MO` | `code_mo` | `Medical Organization Code` | `MedicalOrganizationCode` | Код медицинской организации |
| `YEAR` | `year` | `Billing Year` | `BillingYear` | Отчетный год |
| `MONTH` | `month` | `Billing Month` | `BillingMonth` | Отчетный месяц |
| `NSCHET` | `nschet` | `Invoice Number` | `InvoiceNumber` | Номер счета |
| `DSCHET` | `dschet` | `Invoice Billing Date` | `InvoiceBillingDate` | Дата выставления счёта |
| `PLAT` | `plat` | `Payer Code` | `PayerCode` | Код плательщика |
| `SUMMAV` | `summav` | `Invoice Amount` | `InvoiceAmount` | Сумма счета, выставленная МО на оплату |


### Таблица `SL`
### Таблица `Z_SL`