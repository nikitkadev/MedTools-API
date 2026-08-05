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
| `SANK_MEK` | `sank_mek` | `Medical-Economic Control Penalty` | `MedicalEconomicControlPenalty` | Финансовые санкции по результатам МЭК
| `SANK_MEE` | `sank_mee` | `Medical-Economic Expertise Penalty` | `MedicalEconomicExpertisePenalty` | Финансовые санкции по результатам МЭЭ
| `SANK_EKMP` | `sank_ekmp` | `Quality of Medical Care Expertise Penalty` | `MedicalCareQualityExpertisePenalty` | Финансовые санкции по результатам ЭКМП
| `SMO_SUMMAP` | `smo_summap` | `Insurance Company Approved Amount` | `InsuranceCompanyApprovedAmount` | Сумма, принятая к оплате страховой медицинской организацией
| `SMO_SANK_MEK` | `smo_sank_mek` | `Insurance Company Medical-Economic Control Penalty` | `InsuranceCompanyMedicalEconomicControlPenalty` | Финансовые санкции по результатам МЭК СМО
| `SMO_SANK_MEE` | `smo_sank_mee` | `Insurance Company Medical-Economic Expertise Penalty` | `InsuranceCompanyMedicalEconomicExpertisePenalty` | Финансовые санкции по результатам МЭЭ СМО
| `SMO_SANK_EKMP` | `smo_sank_ekmp` | `Insurance Company Quality of Medical Care Expertise Penalty` | `InsuranceCompanyMedicalCareQualityExpertisePenalty` | Финансовые санкции по результатам ЭКМП СМО

 
### Таблица `Z_SL`
| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| --- | --- | --- | --- | --- |
| `Z_SL` | `dbo.z_sl` | `Completed Case` | `CompletedCase` | Законченный случай |

### Таблица `SL`
| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| --- | --- | --- | --- | --- |
| `SL` | `dbo.sluch` | `Medical Case` | `MedicalCase` | Случай |
| `PROFIL` | `profil` | `Medical Profile` | `MedicalProfile` | Профиль медицинской помощи |
| `PRVS` | `prvs` | `Physician Specialty` | `PhysicianSpecialty` | Специальность врача |
| `DATE_1` | `date_1` | `Treatment Start Date` | `TreatmentStartDate` | Дата начала лечения |
| `DATE_2` | `date_2` | `Treatment End Date` | `TreatmentEndDate` | Дата окончания лечения |
| `DS1` | `ds1` | `Primary Diagnosis ` | `PrimaryDiagnosis ` | Дата окончания лечения |
| `ED_COL` | `ed_col` | `Paid Units` | `PaidUnits ` | Количество единиц оплаты медицинской помощи |
| `TARIF` | `tarif` | `Unit Rate` | `UnitRate ` | Тариф |


### Таблица `PERS`
| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| --- | --- | --- | --- | --- |
| `FAM` | `fam` | `Patient Last Name` | `PatientLastName` | Фамилия пациента |
| `IM` | `im` | `Patient First Name` | `PatientFirstName` | Имя пациента |
| `OT` | `ot` | `Patient Middle Name` | `PatientMiddleName` | Отчество пациента |

### Таблица `PACIENT`
| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| --- | --- | --- | --- | --- |
| `SPOLIS` | `spolis` | `Insurance Policy Series` | `InsurancePolicySeries` | Серия полиса |
| `NPOLIS` | `npolis` | `Insurance Policy Number` | `InsurancePolicyNumber` | Номер полиса |

### Таблица `SL`
