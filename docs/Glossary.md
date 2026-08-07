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
| `LPU` | `lpu` | `Medical Organization Code` | `MedicalOrganizationCode` | Код медицинской организации |
| `NPR_MO` | `npr_mo` | `Referring Medical Organization Code ` | `ReferringMedicalOrganizationCode` | Код медицинской организации, направившей на лечение |
| `NPR_DATE` | `npr_date` | `Referral Date` | `ReferralDate` |  Дата направления |
| `USL_OK` | `usl_ok` | `Care Conditions` | `CareConditions` | Условия оказания медицинской помощи |
| `VIDPOM` | `vidpom` | `Medical Care Type` | `MedicalCareType` | Вид медицинской помощи |
| `IDSP` | `idsp` | `Payment Method Code ` | `PaymentMethodCode` | Код способа оплаты медицинской помощи |
| `FOR_POM` | `for_pom` | `Medical Care Form` | `MedicalCareForm` | Форма оказания медицинской помощи |
| `DATE_Z_1` | `date_z_1` | `Treatment Start Date` | `TreatmentStartDate` | Дата начала лечения |
| `DATE_Z_2` | `date_z_2` | `Treatment End Date` | `TreatmentEndDate` | Дата окончания лечения |
| `KD_Z` | `kd_z` | `Hospitalization Duration` | `HospitalizationDuration` | Продолжительность госпитализации (койко-дни / пациенто-дни) |
| `RSLT` | `rslt` | `Hospitalization Outcome` | `HospitalizationOutcome` | Результат обращения/ госпитализации |
| `VB_P` | `vb_p` | `Is Intrahospital Transfer` | `IsIntrahospitalTransfer` | Признак внутрибольничного перевода |
| `RSLT_D` | `rslt_d` | `Screening Result` | `ScreeningResult` | Результат диспансеризации |
| `P_OTK` | `p_otk` | `Is Refusal` | `IsRefusal` | Признак отказа |
| `VBR` | `vbr` | `Is Mobile Team` | `IsMobileTeam` | Признак мобильной бригады |
| `ISHOD` | `ishod` | `Disease Outcome` | `DiseaseOutcome` | Исход заболевания |


### Таблица `SL`
| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| --- | --- | --- | --- | --- |
| `SL` | `dbo.sluch` | `Medical Case` | `MedicalCase` | Случай |
| `PROFIL` | `profil` | `Medical Profile` | `MedicalProfile` | Профиль медицинской помощи |
| `PRVS` | `prvs` | `Physician Specialty` | `PhysicianSpecialty` | Специальность врача |
| `DATE_1` | `date_1` | `Treatment Start Date` | `TreatmentStartDate` | Дата начала лечения |
| `DATE_2` | `date_2` | `Treatment End Date` | `TreatmentEndDate` | Дата окончания лечения |
| `DS1` | `ds1` | `Primary Diagnosis ` | `PrimaryDiagnosis` | Дата окончания лечения |
| `ED_COL` | `ed_col` | `Paid Units` | `PaidUnits` | Количество единиц оплаты медицинской помощи |
| `TARIF` | `tarif` | `Unit Rate` | `UnitRate` | Тариф |
| `LPU_1` | `lpu_1` | `Department` | `Department` | Подразделение медицинской организации |
| `PODR` | `podr` | `DepartmentCode` | `DepartmentCode` | Код отделения |
| `DET` | `det` | `Is Pediatric` | `IsPediatric` | Признак детского профиля |
| `P_CEL` | `p_cel` | `Visit Purpose` | `VisitPurpose` | Цель посещения |
| `PROFIL_K` | `profil_k` | `Bed Profile` | `BedProfile` | Профиль койки |
| `NHISTORY` | `history` | `Medical Record Number` | `MedicalRecordNumber` | Номер истории болезни/талона амбулаторного пациента/карты/карты вызова скорой медицинской помощи |
| `P_PER` | `p_per` | `Is Admission Transfer` | `IsAdmissionTransfer` | Признак поступления/перевода |
| `REAB` | `reab` | `Is Rehabilitation` | `IsRehabilitation` | Признак реабилитации |
| `KD` | `kd` | `HospitalizationDuration` | `HospitalizationDuration` | Продолжительность госпитализации (койко-дни/пациенто-дни) |
| `LPU_LEVEL` | `lpu_level` | `Facility Level` | `FacilityLevel` | Уровень (крутости) медицинской организации |
| `DS0` | `ds0` | `Initial Diagnosis` | `InitialDiagnosis` | Диагноз первичный |
| `DS_ONK ` | `ds_onk` | `Is Oncology Suspicion` | `IsOncologySuspicion` | Признак подозрения на злокачественное новообразование |
| `IDDOKT` | `iddokt` | `Physician Code` | `PhysicianCode` | Код лечащего врача/врача, закрывшего талон (историю болезни) |
| `WEI` | `wei` | `Weight` | `Weight` | Масса тела (кг) |
| `C_ZAB` | `c_zab` | `Disease Character` | `DiseaseCharacter` | Характер основного заболевания |
| `COMENTSL` | `comentsl` | `Internal Comment` | `InternalComment` | Служебное поле |


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
| `VPOLIS` | `vpolis` | `Insurance Policy Type` | `InsurancePolicyType` | Тип полиса |
| `SMO` | `smo` | `Insurance Company Code` | `InsuranceCompanyCode` | Реестровый номер СМО |
| `SMO_NAM` | `smo_nam` | `Insurance Company Name` | `InsuranceCompanyName` | Наименование СМО |
| `ENP` | `enp` | `Insurance Policy Unified Number` | `InsurancePolicyUnifiedNumber` | Номер полиса |
| `ID_PAC` | `id_pac` | `Patient Record Code` | `PatientRecordCode` | Код записи о пациенте |


### Таблица `SL`
### Таблица `B_DIAG`
| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| --- | --- | --- | --- | --- |
| `DIAG_DATE` | `` | `Specimen Collection Date` | `SpecimenCollectionDate` | Дата взятия материала |
| `DIAG_TIP` | `` | `Diagnostic Type` | `DiagnosticType` | Тип диагностического показателя |
| `DIAG_CODE` | `` | `Diagnostic Code` | `DiagnosticCode` | Код диагностического показателя |
| `DIAG_RSLT` | `` | `Diagnostic Result Code` | `DiagnosticResultCode` | Код результата диагностики |
| `REC_RSLT` | `` | `Is Result Received` | `IsResultReceived` | Признак получения результата диагностики |

### Таблица `B_PROT`
| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| --- | --- | --- | --- | --- |
| `PROT` | `` | `Contraindication Code` | `ContraindicationCode` | Код противопоказания или отказа |
| `D_PROT` | `` | `Contraindication Date` | `ContraindicationDate` | Дата регистрации противопоказания или отказа |

### Таблица `CONS`
| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| --- | --- | --- | --- | --- |
| `PR_CONS` | `` | `Consultation Purpose` | `ConsultationPurpose` | Цель проведения консилиума |
| `DT_CONS` | `` | `Consultation Date` | `ConsultationDate` | Цель проведения консилиума |


### Таблица `ONK_SL`
| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| --- | --- | --- | --- | --- |
| `DS1_T` | `` | `Referral Reason` | `ReferralReason` | Повод обращения |
| `STAD` | `` | `Stage` | `Stage` | Стадия заболевания |
| `ONK_T` | `` | `Tumor Value` | `TumorValue` | Значение Tumor |
| `ONK_N` | `` | `Nodus Value` | `NodusValue` | Значение Nodus |
| `ONK_M` | `` | `Metastasis Value` | `MetastasisValue` | Значение Metastasis |
| `MTSTZ` | `` | `Is Metastasis Detected` | `IsMetastasisDetected` | Признак выявления отдалённых метастазов |
| `SOD` | `` | `Total Focus Dose` | `TotalFocusDose` | Суммарная очаговая доза |
| `K_FR` | `` | `Radiation Fractions Count` | `RadiationFractionsCount` | Количество фракций проведения лучевой терапии |
| `WEI` | `` | `Weight` | `Weight` | Масса тела (кг) |
| `HEI` | `` | `Height` | `Height` | Рост (см) |
| `BSA` | `` | `BodySurfaceArea` | `BodySurfaceArea` | Площадь поверхности тела (м2) |

