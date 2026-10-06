# Глоссарий ТФОМС РХ

## Предисловие

Данный документ является единым словарём предметной области информационных систем **ТФОМС РХ**.

Его основная задача — установить соответствие между терминологией **ФФОМС**, использующей исторически сложившуюся транслитерацию, и доменной моделью программных продуктов **ТФОМС РХ**.

## Базовые понятия

| Доменное название             | Идентификатор в коде        | Перевод                     |
| ----------------------------- | --------------------------- | --------------------------- |
| `Medical Organization`        | `MedicalOrganization`       | Медицинская организация     |
| `Insurance Organization`      | `InsuranceOrganization`     | Страховая организация       |
| `Insurance Organization Code` | `InsuranceOrganizationCode` | Код страховой организации   |
| `Medical Organization Code`   | `MedicalOrganizationCode`   | Код медицинской организации |
| `Patient`                     | `Patient`                   | Пациент                     |
| `Billing Period`              | `BillingPeriod`             | Расчетный период            |

## Формат ФФОМС

### Таблица `SCHET`

| Транслитерация  | БД ТФОМС РХ     | Доменное название                                             | Идентификатор в коде                                 | Наименование                                                |
| --------------- | --------------- | ------------------------------------------------------------- | ---------------------------------------------------- | ----------------------------------------------------------- |
| `CODE`          | `code`          | `Invoice Code`                                                | `InvoiceCode`                                        | Уникальный код счета                                        |
| `CODE_MO`       | `code_mo`       | `Medical Organization Code`                                   | `MedicalOrganizationCode`                            | Код медицинской организации                                 |
| `YEAR`          | `year`          | `Billing Year`                                                | `BillingYear`                                        | Отчетный год                                                |
| `MONTH`         | `month`         | `Billing Month`                                               | `BillingMonth`                                       | Отчетный месяц                                              |
| `NSCHET`        | `nschet`        | `Invoice Number`                                              | `InvoiceNumber`                                      | Номер счета                                                 |
| `DSCHET`        | `dschet`        | `Invoice Billing Date`                                        | `InvoiceBillingDate`                                 | Дата выставления счёта                                      |
| `PLAT`          | `plat`          | `Payer Code`                                                  | `PayerCode`                                          | Код плательщика                                             |
| `SUMMAV`        | `summav`        | `Invoice Amount`                                              | `InvoiceAmount`                                      | Сумма счета, выставленная МО на оплату                      |
| `COMENTS`       | `coments`       | `Internal Comment`                                            | `InternalComment`                                    | Служебное поле                                              |
| `SUMMAP`        | `summap`        | `Approved Amount`                                             | `ApprovedAmount`                                     | Сумма, принятая к оплате ТФОМС                              |
| `SANK_MEK`      | `sank_mek`      | `Medical-Economic Control Penalty`                            | `MedicalEconomicControlPenalty`                      | Финансовые санкции по результатам МЭК                       |
| `SANK_MEE`      | `sank_mee`      | `Medical-Economic Expertise Penalty`                          | `MedicalEconomicExpertisePenalty`                    | Финансовые санкции по результатам МЭЭ                       |
| `SANK_EKMP`     | `sank_ekmp`     | `Quality of Medical Care Expertise Penalty`                   | `MedicalCareQualityExpertisePenalty`                 | Финансовые санкции по результатам ЭКМП                      |
| `SMO_SUMMAP`    | `smo_summap`    | `Insurance Company Approved Amount`                           | `InsuranceCompanyApprovedAmount`                     | Сумма, принятая к оплате страховой медицинской организацией |
| `SMO_SANK_MEK`  | `smo_sank_mek`  | `Insurance Company Medical-Economic Control Penalty`          | `InsuranceCompanyMedicalEconomicControlPenalty`      | Финансовые санкции по результатам МЭК СМО                   |
| `SMO_SANK_MEE`  | `smo_sank_mee`  | `Insurance Company Medical-Economic Expertise Penalty`        | `InsuranceCompanyMedicalEconomicExpertisePenalty`    | Финансовые санкции по результатам МЭЭ СМО                   |
| `SMO_SANK_EKMP` | `smo_sank_ekmp` | `Insurance Company Quality of Medical Care Expertise Penalty` | `InsuranceCompanyMedicalCareQualityExpertisePenalty` | Финансовые санкции по результатам ЭКМП СМО                  |
| `DISP`          | `dist`          | `Preventive Examination Type`                                 | `PreventiveExaminationType`                          | Тип диспансеризации                                         |

### Таблица `Z_SL`

| Транслитерация | БД ТФОМС РХ    | Доменное название                      | Идентификатор в коде               | Наименование                                                             |
| -------------- | -------------- | -------------------------------------- | ---------------------------------- | ------------------------------------------------------------------------ |
| `IDCASE`       | `idcase`       | `Case Record Number`                   | `CaseRecordNumber`                 | Номер записи в реестре законченных случаев                               |
| `USL_OK`       | `usl_ok`       | `Care Conditions`                      | `CareConditions`                   | Условия оказания медицинской помощи                                      |
| `VIDPOM`       | `vidpom`       | `Medical Care Type`                    | `MedicalCareType`                  | Вид медицинской помощи                                                   |
| `FOR_POM`      | `for_pom`      | `Care Form`                            | `CareForm`                         | Форма оказания медицинской помощи                                        |
| `NPR_MO`       | `npr_mo`       | `Referring Medical Organization Code ` | `ReferringMedicalOrganizationCode` | Код медицинской организации, направившей на лечение                      |
| `NPR_DATE`     | `npr_date`     | `Referral Date`                        | `ReferralDate`                     | Дата направления                                                         |
| `LPU`          | `lpu`          | `Medical Organization Code`            | `MedicalOrganizationCode`          | Код медицинской организации                                              |
| `VBR`          | `vbr`          | `Is Mobile Team`                       | `IsMobileTeam`                     | Признак мобильной бригады                                                |
| `DATE_Z_1`     | `date_z_1`     | `Treatment Start Date`                 | `TreatmentStartDate`               | Дата начала лечения                                                      |
| `DATE_Z_2`     | `date_z_2`     | `Treatment End Date`                   | `TreatmentEndDate`                 | Дата окончания лечения                                                   |
| `P_OTK`        | `p_otk`        | `Is Refusal`                           | `IsRefusal`                        | Признак отказа                                                           |
| `RSLT_D`       | `rslt_d`       | `Screening Result`                     | `ScreeningResult`                  | Результат диспансеризации                                                |
| `KD_Z`         | `kd_z`         | `Hospitalization Duration`             | `HospitalizationDuration`          | Продолжительность госпитализации (койко-дни / пациенто-дни)              |
| `VNOV_M`       | `vnov_m`       | `Birth Weight`                         | `BirthWeight`                      | Вес при рождении                                                         |
| `RSLT`         | `rslt`         | `Hospitalization Outcome`              | `HospitalizationOutcome`           | Результат обращения/ госпитализации                                      |
| `ISHOD`        | `ishod`        | `Disease Outcome`                      | `DiseaseOutcome`                   | Исход заболевания                                                        |
| `OS_SLUCH`     | `os_sluch`     | `Is Special Case`                      | `IsSpecialCase`                    | Признак "Особый случай" при регистрации обращения за медицинской помощью |
| `VB_P`         | `vb_p`         | `Is Intrahospital Transfer`            | `IsIntrahospitalTransfer`          | Признак внутрибольничного перевода                                       |
| `IDSP`         | `idsp`         | `Payment Method Code `                 | `PaymentMethodCode`                | Код способа оплаты медицинской помощи                                    |
| `SUMV`         | `sumv`         | `Billed Amount`                        | `BilledAmount`                     | Сумма, выставленная к оплате                                             |
| `OPLATA`       | `oplata`       | `Payment Type`                         | `PaymentType`                      | Тип оплаты                                                               |
| `SUMP`         | `sump`         | `Approved Amount`                      | `ApprovedAmount`                   | Сумма, принятая к оплате (ТФОМС)                                         |
| `SMO_SUMP`     | `smo_sump`     | `Insurance Company Approved Amount`    | `InsuranceCompanyApprovedAmount`   | Сумма, принятая к оплате СМО                                             |
| `SANK_IT`      | `sank_it`      | `Penalty Amount`                       | `PenaltyAmount`                    | Сумма санкций по законченному случаю ТФОМС                               |
| `SMO_SANK_IT`  | `smo_sank_it`  | `Insurance Company Penalty Amount`     | `InsuranceCompanyPenaltyAmount`    | Сумма санкций по законченному случаю СМО                                 |
| `EVENING_TIME` | `evening_time` | `Is Evening Visit`                     | `IsEveningVisit`                   | Признак «Вечернее время»                                                 |
| `NPR_NUM`      | `npr_num`      | `Referral Number`                      | `ReferralNumber`                   | Номер направления на лечение (диагностику, консультацию, госпитализацию) |

### Таблица `SL`

| Транслитерация | БД ТФОМС РХ | Доменное название                           | Идентификатор в коде                 | Наименование                                                                                     |
| -------------- | ----------- | ------------------------------------------- | ------------------------------------ | ------------------------------------------------------------------------------------------------ |
| `SL_ID`        | `sl_id`     | `Medical Case Identificator`                | `MedicalCaseIdentificator`           | Идентификатор                                                                                    |
| `VID_HMP`      | `vid_hmp`   | `High Tech Care Type`                       | `HighTechCareType`                   | Вид высокотехнологичной медицинской помощи                                                       |
| `METOD_HMP`    | `metod_hmp` | `High Tech Care Method`                     | `HighTechCareMethod`                 | Метод высокотехнологичной медицинской помощи                                                     |
| `LPU_1`        | `lpu_1`     | `Division`                                  | `Division`                           | Подразделение медицинской организации                                                            |
| `PODR`         | `podr`      | `DepartmentCode`                            | `DepartmentCode`                     | Код отделения                                                                                    |
| `PROFIL`       | `profil`    | `Medical Profile`                           | `MedicalProfile`                     | Профиль медицинской помощи                                                                       |
| `PROFIL_K`     | `profil_k`  | `Bed Profile`                               | `BedProfile`                         | Профиль койки                                                                                    |
| `DET`          | `det`       | `Is Pediatric`                              | `IsPediatric`                        | Признак детского профиля                                                                         |
| `TAL_D`        | `tal_d`     | `Voucher Issue Date`                        | `VoucherIssueDate`                   | Дата выдачи талона на ВМП                                                                        |
| `TAL_NUM`      | `tal_num`   | `Voucher Number`                            | `VoucherNumber`                      | Номер талона на ВМП                                                                              |
| `TAL_P`        | `tal_p`     | `Planned Admission Date`                    | `PlannedAdmissionDate`               | Дата планируемой госпитализации                                                                  |
| `P_CEL`        | `p_cel`     | `Visit Purpose`                             | `VisitPurpose`                       | Цель посещения                                                                                   |
| `NHISTORY`     | `history`   | `Medical Record Number`                     | `MedicalRecordNumber`                | Номер истории болезни/талона амбулаторного пациента/карты/карты вызова скорой медицинской помощи |
| `P_PER`        | `p_per`     | `Is Admission Transfer`                     | `IsAdmissionTransfer`                | Признак поступления/перевода                                                                     |
| `DATE_1`       | `date_1`    | `Treatment Start Date`                      | `TreatmentStartDate`                 | Дата начала лечения                                                                              |
| `DATE_2`       | `date_2`    | `Treatment End Date`                        | `TreatmentEndDate`                   | Дата окончания лечения                                                                           |
| `KD`           | `kd`        | `HospitalizationDuration`                   | `HospitalizationDuration`            | Продолжительность госпитализации (койко-дни/пациенто-дни)                                        |
| `DS0`          | `ds0`       | `Initial Diagnosis`                         | `InitialDiagnosis`                   | Диагноз первичный                                                                                |
| `DS1`          | `ds1`       | `Primary Diagnosis`                         | `PrimaryDiagnosis`                   | Дата окончания лечения                                                                           |
| `DS1_PR`       | `ds1_pr`    | `Is Primary Diagnosis`                      | `IsPrimaryDiagnosis`                 | Установлен впервые (основной)                                                                    |
| `PR_D_N`       | `pr_d_n`    | `Dispensary Observation`                    | `DispensaryObservation`              | Диспансерное наблюдение                                                                          |
| `DS2`          | `ds2`       | `Concomitant Diagnosis`                     | `ConcomitantDiagnosis`               | Сопутствующие заболевания                                                                        |
| `DS3`          | `ds3`       | `Complication Diagnosis`                    | `ComplicationDiagnosis`              | Диагноз осложнения заболевания                                                                   |
| `DN`           | `dn`        | `Additional Dispensary Observation`         | `AdditionalDispensaryObservation`    | Диспансерное наблюдение (дополнительное для другого формата)                                     |
| `CODE_MES1`    | `code_mes1` | `Medical Economic Standard Code`            | `MedicalEconomicStandardCode`        | Код МЭС                                                                                          |
| `CODE_MES2`    | `code_mes2` | `Concomitant Mes Code`                      | `ConcomitantMesCode`                 | Код МЭС сопутствующего заболевания                                                               |
| `REAB`         | `reab`      | `Is Rehabilitation`                         | `IsRehabilitation`                   | Признак реабилитации                                                                             |
| `PRVS`         | `prvs`      | `Physician Specialty`                       | `PhysicianSpecialty`                 | Специальность врача                                                                              |
| `VERS_SPEC`    | `vers_spec` | `Medical Specialty Code`                    | `MedicalSpecialtyCode`               | Код классификатора медицинских специальностей                                                    |
| `IDDOKT`       | `iddokt`    | `Physician Code`                            | `PhysicianCode`                      | Код лечащего врача/врача, закрывшего талон (историю болезни)                                     |
| `ED_COL`       | `ed_col`    | `Paid Units`                                | `PaidUnits`                          | Количество единиц оплаты медицинской помощи                                                      |
| `TARIF`        | `tarif`     | `Unit Rate`                                 | `UnitRate`                           | Тариф                                                                                            |
| `SUM_M`        | `sum_m`     | `Claimed Amount`                            | `ClaimedAmount`                      | Стоимость случая, выставленная к оплате                                                          |
| ``             | `sump`      | `Approved Amount`                           | `ApprovedAmount`                     | Стоимость случая, принятая к оплате ТФОМС                                                        |
| `SMO_SUMP`     | `smo_sump`  | `Insurance Company Approved Amount`         | `InsuranceCompanyApprovedAmount`     | Стоимость случая, принятая к оплате СМО                                                          |
| `COMENTSL`     | `comentsl`  | `Internal Comment`                          | `InternalComment`                    | Служебное поле                                                                                   |
| ``             | `sank_mek`  | `Medical-Economic Control Penalty`          | `MedicalEconomicControlPenalty`      | Финансовые санкции по результатам МЭК                                                            |
| ``             | `sank_mee`  | `Medical-Economic Expertise Penalty`        | `MedicalEconomicExpertisePenalty`    | Финансовые санкции по результатам МЭЭ                                                            |
| ``             | `sank_ekmp` | `Quality of Medical Care Expertise Penalty` | `QualityMedicalCareExpertisePenalty` | Финансовые санкции по результатам ЭКМП                                                           |
| `LPU_LEVEL`    | `lpu_level` | `Facility Level`                            | `FacilityLevel`                      | Уровень (крутости) медицинской организации                                                       |
| `DS_ONK `      | `ds_onk`    | `Is Oncology Suspicion`                     | `IsOncologySuspicion`                | Признак подозрения на злокачественное новообразование                                            |
| `C_ZAB`        | `c_zab`     | `Disease Character`                         | `DiseaseCharacter`                   | Характер основного заболевания                                                                   |
| `WEI`          | `wei`       | `Weight`                                    | `Weight`                             | Масса тела (кг)                                                                                  |
| `PROF_M`       | `prof_m`    | `Preventive Care Mo Code`                   | `PreventiveCareMoCode`               | Место проведения профилактического мероприятия и диспансерного наблюдения                        |
| `MOP`          | `mop`       | `Encounter Mo Code`                         | `EncounterMoCode`                    | Место обращения (посещения)                                                                      |

### Таблица `PERS`

| Транслитерация | БД ТФОМС РХ | Доменное название                         | Идентификатор в коде                    | Наименование                                                               |
| -------------- | ----------- | ----------------------------------------- | --------------------------------------- | -------------------------------------------------------------------------- |
| `ID_PAC`       | `id_pac`    | `Patient Record Code`                     | `PatientRecordCode`                     | Код записи о пациенте                                                      |
| `FAM`          | `fam`       | `Patient Last Name`                       | `PatientLastName`                       | Фамилия пациента                                                           |
| `IM`           | `im`        | `Patient First Name`                      | `PatientFirstName`                      | Имя пациента                                                               |
| `OT`           | `ot`        | `Patient Middle Name`                     | `PatientMiddleName`                     | Отчество пациента                                                          |
| `W`            | `w`         | `Patient Sex`                             | `PatientSex`                            | Пол пациента                                                               |
| `DR`           | `dr`        | `Patient Birth Date`                      | `PatientBirthDate`                      | Дата рождения пациента                                                     |
| `DOST`         | `dost`      | `Patient Identity Confidence Code`        | `PatientIdentityConfidenceCode`         | Код надёжности идентификации пациента                                      |
| `TEL`          | `tel`       | `Phone Number`                            | `PhoneNumber`                           | Номер телефона                                                             |
| `FAM_P`        | `fam_p`     | `Patient Representative Last Name`        | `PatientRepresentativeLastName`         | Фамилия представителя пациента                                             |
| `IM_P`         | `im_p`      | `Patient Representative First Name`       | `PatientRepresentativeFirstName`        | Имя представителя пациента                                                 |
| `OT_P`         | `ot_p`      | `Patient Representative Middle Name`      | `PatientRepresentativeMiddleName`       | Отчество представителя пациента                                            |
| `W_P`          | `w_p`       | `Patient Representative Sex`              | `PatientRepresentativeSex`              | Пол представителя пациента                                                 |
| `DR_P`         | `dr_p`      | `Patient Representative Birthday`         | `PatientRepresentativeBirthday`         | Дата рождения представителя пациента                                       |
| `DOST_P`       | `dost_p`    | `Representative Identity Confidence Code` | `RepresentativeIdentityConfidenceCode ` | Код надёжности идентификации представителя                                 |
| `MR`           | `mr`        | `Birth Place`                             | `BirthPlace`                            | Место рождения пациента или представителя                                  |
| `DOCTYPE`      | `doctype`   | `Document Type Code`                      | `DocumentTypeCode`                      | Тип документа, удостоверяющего личность пациента или представителя         |
| `DOCSER`       | `docser`    | `Document Series`                         | `DocumentSeries`                        | Серия документа, удостоверяющего личность                                  |
| `DOCNUM`       | `docnum`    | `Document Number`                         | `DocumentNumber`                        | Номер документа, удостоверяющего личность пациента или представителя       |
| `SNILS`        | `snils`     | `Snils`                                   | `Snils`                                 | СНИЛС                                                                      |
| `OKATOG`       | `okatog`    | `Residence Okato Code`                    | `ResidenceOkatoCode`                    | Код места жительства по ОКАТО                                              |
| `OKATOP`       | `okatop`    | `Temporary Residence Okato Code`          | `TemporaryResidenceOkatoCode`           | Код места пребывания по ОКАТО                                              |
| `COMENTP`      | `comentp`   | `Internal Comment`                        | `InternalComment`                       | Служебное поле                                                             |
| `DOCDATE`      | `docdate`   | `Document Issue Date`                     | `DocumentIssueDate`                     | Дата выдачи документа, удостоверяющего личность пациента или представителя |
| `DOCORG`       | `docorg`    | `Issued By`                               | `IssuedBy`                              | Наименование органа, выдавшего документ, удостоверяющий личность           |

### Таблица `PACIENT`

| Транслитерация | БД ТФОМС РХ | Доменное название                         | Идентификатор в коде                  | Наименование                                                                            |
| -------------- | ----------- | ----------------------------------------- | ------------------------------------- | --------------------------------------------------------------------------------------- |
| `ID_PAC`       | `id_pac`    | `Patient Record Code`                     | `PatientRecordCode`                   | Код записи о пациенте                                                                   |
| `VPOLIS`       | `vpolis`    | `Insurance Policy Type`                   | `InsurancePolicyType`                 | Тип полиса                                                                              |
| `SPOLIS`       | `spolis`    | `Insurance Policy Series`                 | `InsurancePolicySeries`               | Серия полиса                                                                            |
| `NPOLIS`       | `npolis`    | `Insurance Policy Number`                 | `InsurancePolicyNumber`               | Номер полиса                                                                            |
| `ENP`          | `enp`       | `Insurance Policy Unified Number`         | `InsurancePolicyUnifiedNumber`        | Номер полиса                                                                            |
| `ST_OKATO`     | `st_okato`  | `Insurance Region Code`                   | `InsuranceRegionCode`                 | ОКАТО региона страхования                                                               |
| `SMO`          | `smo`       | `Insurance Company Code`                  | `InsuranceCompanyCode`                | Реестровый номер СМО                                                                    |
| `SMO_OGRN`     | `smo_ogrn`  | `Insurance Organization Ogrn`             | `InsuranceOrganizationOgrn `          | ОГРН СМО                                                                                |
| `SMO_OK`       | `smo_ok`    | `Insurance Territory Okato `              | `InsuranceTerritoryOkato `            | ОКАТО территории страхования                                                            |
| `SMO_NAM`      | `smo_nam`   | `Insurance Company Name`                  | `InsuranceCompanyName`                | Наименование СМО                                                                        |
| `INV`          | `inv`       | `Disability Group`                        | `DisabilityGroup `                    | Группа инвалидности                                                                     |
| `MSE`          | `mse`       | `Medico Social Examination Referral`      | `MedicoSocialExaminationReferral `    | Направление на МСЭ                                                                      |
| `NOVOR`        | `novor`     | `Newborn Identifier `                     | `NewbornIdentifier `                  | Признак новорождённого                                                                  |
| `VNOV_D`       | `vnov_d`    | `Birth Weight`                            | `BirthWeight`                         | Вес при рождении                                                                        |
| `SOC`          | `soc`       | `Social Category`                         | `SocialCategory`                      | Социальная категория                                                                    |
| `NEXT_D`       | `next_d`    | `Next Scheduled Examination Month`        | `NextScheduledExaminationMonth `      | Период (месяц) проведения следующего планового осмотра                                  |
| `MO_PR`        | `mo_pr`     | `Primary Care Medical Organization Code ` | `PrimaryCareMedicalOrganizationCode ` | Код МО, выбранной застрахованным лицом для получения первичной медико-санитарной помощи |
| `VZ`           | `vz`        | `Employment Type`                         | `EmploymentType`                      | Вид занятости                                                                           |
| ``             | `pstatus`   | `Patient Status`                          | `PatientStatus`                       | Статус пациента                                                                         |

### Таблица `ONK_USL`

| Транслитерация | БД ТФОМС РХ | Доменное название              | Идентификатор в коде        | Наименование                                                |
| -------------- | ----------- | ------------------------------ | --------------------------- | ----------------------------------------------------------- |
| `USL_TIP`      | `usl_tip`   | `Service Type Code`            | `ServiceTypeCode`           | Код типа услуги                                             |
| `HIR_TIP`      | `hir_tip`   | `Surgical Treatment Type Code` | `SurgicalTreatmentTypeCode` | Код типа хирургического лечения                             |
| `LEK_TIP_L`    | `lek_tip_l` | `Drug Therapy Line Code`       | `DrugTherapyLineCode`       | Код линии лекарственной терапии                             |
| `LEK_TIP_V`    | `lek_tip_v` | `Drug Therapy Cycle Code`      | `DrugTherapyCycleCode`      | Код цикла лекарственной терапии                             |
| `PPTR`         | `pptr`      | `Is Antiemetic Prophylaxis`    | `IsAntiemeticProphylaxis`   | Признак проведения профилактики тошноты и рвотного рефлекса |
| `LUCH_TIP`     | `luch_tip`  | `Radio Therapy Type Code`      | `RadioTherapyTypeCode`      | Тип лучевой терапии                                         |

### Таблица `B_DIAG`

| Транслитерация | БД ТФОМС РХ | Доменное название          | Идентификатор в коде     | Наименование                             |
| -------------- | ----------- | -------------------------- | ------------------------ | ---------------------------------------- |
| `DIAG_TIP`     | `diag_tip`  | `Diagnostic Type`          | `DiagnosticType`         | Тип диагностического показателя          |
| `DIAG_CODE`    | `diag_code` | `Diagnostic Code`          | `DiagnosticCode`         | Код диагностического показателя          |
| `DIAG_RSLT`    | `diag_rslt` | `Diagnostic Result Code`   | `DiagnosticResultCode`   | Код результата диагностики               |
| `DIAG_DATE`    | `diag_date` | `Specimen Collection Date` | `SpecimenCollectionDate` | Дата взятия материала                    |
| `REC_RSLT`     | `rec_rslt`  | `Is Result Received`       | `IsResultReceived`       | Признак получения результата диагностики |

### Таблица `B_PROT`

| Транслитерация | БД ТФОМС РХ | Доменное название       | Идентификатор в коде   | Наименование                                 |
| -------------- | ----------- | ----------------------- | ---------------------- | -------------------------------------------- |
| `PROT`         | ``          | `Contraindication Code` | `ContraindicationCode` | Код противопоказания или отказа              |
| `D_PROT`       | ``          | `Contraindication Date` | `ContraindicationDate` | Дата регистрации противопоказания или отказа |

### Таблица `CONS`

| Транслитерация | БД ТФОМС РХ | Доменное название      | Идентификатор в коде      | Наименование               |
| -------------- | ----------- | ---------------------- | ------------------------- | -------------------------- |
| `PR_CONS`      | ``          | `Consultation Purpose` | `ConsultationPurposeCode` | Цель проведения консилиума |
| `DT_CONS`      | ``          | `Consultation Date`    | `ConsultationDate`        | Цель проведения консилиума |

### Таблица `ONK_SL`

| Транслитерация | БД ТФОМС РХ | Доменное название           | Идентификатор в коде      | Наименование                                  |
| -------------- | ----------- | --------------------------- | ------------------------- | --------------------------------------------- |
| `DS1_T`        | `ds1_t`     | `Referral Reason`           | `ReferralReasonCode`      | Повод обращения                               |
| `STAD`         | `stad`      | `Stage`                     | `Stage`                   | Стадия заболевания                            |
| `ONK_T`        | `onk_t`     | `Tumor Value`               | `TumorValue`              | Значение Tumor                                |
| `ONK_N`        | `onk_n`     | `Nodus Value`               | `NodusValue`              | Значение Nodus                                |
| `ONK_M`        | `onk_m`     | `Metastasis Value`          | `MetastasisValue`         | Значение Metastasis                           |
| `MTSTZ`        | `mtstz`     | `Is Metastasis Detected`    | `IsMetastasisDetected`    | Признак выявления отдалённых метастазов       |
| `SOD`          | `sod`       | `Total Focus Dose`          | `TotalFocusDose`          | Суммарная очаговая доза                       |
| `K_FR`         | `k_fr`      | `Radiation Fractions Count` | `RadiationFractionsCount` | Количество фракций проведения лучевой терапии |
| `WEI`          | `wei`       | `Weight`                    | `Weight`                  | Масса тела (кг)                               |
| `HEI`          | `hei`       | `Height`                    | `Height`                  | Рост (см)                                     |
| `BSA`          | `bsa`       | `BodySurfaceArea`           | `BodySurfaceArea`         | Площадь поверхности тела (м2)                 |

### Таблица `LEK_PR`

| Транслитерация | БД ТФОМС РХ | Доменное название          | Идентификатор в коде     | Наименование                                                                                                                                                                                                                                        |
| -------------- | ----------- | -------------------------- | ------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `REGNUM`       | ``          | `Drug Identifier`          | `DrugIdentifier`         | Идентификатор лекарственного препарата, применяемого при проведении лекарственной противоопухолевой терапии                                                                                                                                         |
| `REGNUM_DOP`   | ``          | `Drug Extended Identifier` | `DrugExtendedIdentifier` | Код расширенного идентификатора МНН лекарственного препарата с указанием пути введения (в том числе с уточнением действующего вещества или формы выпуска), типа лекарственной формы по агрегатному состоянию и виду высвобождения, единиц измерения |
| `CODE_SH`      | ``          | `Therapy Regimen Code`     | `TherapyRegimenCode`     | Код схемы лекарственной терапии                                                                                                                                                                                                                     |

### Таблица `INJ`

| Транслитерация | БД ТФОМС РХ | Доменное название       | Идентификатор в коде   | Наименование                                                                                                 |
| -------------- | ----------- | ----------------------- | ---------------------- | ------------------------------------------------------------------------------------------------------------ |
| `DATE_INJ`     | `date_inj`  | `Administration Date`   | `AdministrationDate`   | Дата введения лекарственного препарата                                                                       |
| `KV_INJ`       | `kv_inj`    | `Administered Quantity` | `AdministeredQuantity` | Количество введенного лекарственного препарата (действующего вещества)                                       |
| `KIZ_INJ`      | `kiz_inj`   | `Consumed Quantity`     | `ConsumedQuantity`     | Количество израсходованного (введенного + утилизированного) лекарственного препарата (действующего вещества) |
| `S_INJ`        | `s_inj`     | `Unit Cost`             | `UnitCost`             | Фактическая стоимость лекарственного препарата за единицу измерения действующего вещества                    |
| `SV_INJ`       | `sv_inj`    | `Administered Cost`     | `AdministeredCost`     | Стоимость введенного лекарственного препарата                                                                |
| `SIZ_INJ`      | `siz_inj`   | `Consumed Cost`         | `ConsumedCost`         | Стоимость израсходованного лекарственного препарата                                                          |
| `RED_INJ`      | `red_inj`   | `Is Reduction Applied`  | `IsReductionApplied`   | Признак применения редукции для лекарственного препарата                                                     |

### Таблица `USL`

| Транслитерация | БД ТФОМС РХ | Доменное название           | Идентификатор в коде      | Наименование                                               |
| -------------- | ----------- | --------------------------- | ------------------------- | ---------------------------------------------------------- |
| `IDSERV`       | `idserv`    | `Service Record Id`         | `ServiceRecordId`         | Номер записи в реестре услуг                               |
| `LPU`          | `lpu`       | `Medical Organization Code` | `MedicalOrganizationCode` | Код медицинской организации                                |
| `LPU_1`        | `lpu_1`     | `Division`                  | `Division`                | Подразделение медицинской организации                      |
| `PODR`         | `podr`      | `DepartmentCode`            | `DepartmentCode`          | Код отделения                                              |
| `PROFIL`       | `profil`    | `Medical Profile`           | `MedicalProfile`          | Профиль медицинской помощи                                 |
| `VID_VME`      | `vid_vme`   | `Medical Intervention Type` | `MedicalInterventionType` | Вид медицинского вмешательства                             |
| `DET`          | `det`       | `Is Pediatric`              | `IsPediatric`             | Признак детского профиля                                   |
| `DATE_IN`      | `date_in`   | `Service Start Date`        | `ServiceStartDate`        | Дата начала оказания услуги                                |
| `DATE_OUT`     | `date_out`  | `Service End Date`          | `ServiceEndDate`          | Дата окончания оказания услуги                             |
| `P_OTK`        | `p_otk`     | `Is Refusal`                | `IsRefusal`               | Признак отказа от услуги                                   |
| `DS`           | `ds`        | `Diagnosis`                 | `Diagnosis`               | Диагноз                                                    |
| `CODE_USL`     | `code_usl`  | `Service Code`              | `ServiceCode`             | Код услуги                                                 |
| `KOL_USL`      | `kol_usl`   | `Service Quantity`          | `ServiceQuantity`         | Количество услуг (кратность услуги)                        |
| `TARIF`        | `tarif`     | `Unit Rate`                 | `UnitRate`                | Тариф                                                      |
| `SUMV_USL`     | `sumv_usl`  | `Amount Billed`             | `AmountBilled`            | Стоимость медицинской услуги, выставленная к оплате (руб.) |
| `PRVS`         | `prvs`      | `Physician Specialty`       | `PhysicianSpecialty`      | Специальность медработника, выполнившего услугу            |
| `CODE_MD`      | `code_md`   | `Physician Code`            | `PhysicianCode`           | Код медицинского работника, оказавшего медицинскую услугу  |
| `NPL`          | `npl`       | `Incomplete Volume`         | `IncompleteVolume`        | Неполный объем                                             |
| `COMENTU`      | `comentu`   | `Internal Comment`          | `InternalComment`         | Служебное поле                                             |

### Таблица `MED_DEV`

| Транслитерация | БД ТФОМС РХ | Доменное название          | Идентификатор в коде    | Наименование                        |
| -------------- | ----------- | -------------------------- | ----------------------- | ----------------------------------- |
| `DATE_MED`     | ``          | `Implantation Date`        | `ImplantationDate`      | Дата установки медицинского изделия |
| `CODE_MEDDEV`  | ``          | `Medical Device Type Code` | `MedicalDeviceTypeCode` | Код вида медицинского изделия       |
| `NUMBER_SER`   | ``          | `Serial Number`            | `SerialNumber`          | Серийный номер                      |

### Таблица `KSG_KPG`

| Транслитерация | БД ТФОМС РХ | Доменное название                             | Идентификатор в коде                       | Наименование                                                       |
| -------------- | ----------- | --------------------------------------------- | ------------------------------------------ | ------------------------------------------------------------------ |
| `N_KSG`        | `n_ksg`     | `Clinical Statistic Group Number`             | `ClinicalStatisticGroupNumber`             | Номер КСГ                                                          |
| `VER_KSG`      | `ver_ksg`   | `Clinical Statistic Group Model Version`      | `ClinicalStatisticGroupModelVersion`       | Модель определения КСГ                                             |
| `KSG_PG`       | `ksg_pg`    | `Is Csg Subgroup Used`                        | `IsCsgSubgroupUsed`                        | Признак использования подгруппы КСГ                                |
| `N_KPG`        | `n_kpg`     | `Clinical Profile Group Number`               | `ClinicalProfileGroupNumber`               | Номер КПГ                                                          |
| `KOEF_Z`       | `koef_z`    | `Cost Coefficient`                            | `CostCoefficient`                          | Коэффициент затратоемкости                                         |
| `KOEF_UP`      | `koef_up`   | `Management Coefficient`                      | `ManagementCoefficient`                    | Управленческий коэффициент                                         |
| `BZTSZ`        | `bztsz`     | `Base Rate`                                   | `BaseRate`                                 | Базовая ставка                                                     |
| `KOEF_D`       | `koef_d`    | `Differentiation Coefficient`                 | `DifferentiationCoefficient`               | Коэффициент дифференциации                                         |
| `KOEF_U`       | `koef_u`    | `Level Coefficient`                           | `LevelCoefficient`                         | Коэффициент уровня/подуровня оказания медицинской помощи           |
| `—`            | `dkk1`      | `Additional Criterion First `                 | `AdditionalCriterionFirst`                 | Первый дополнительный классификационный критерий                   |
| `—`            | `dkk2`      | `Additional Criterion Second `                | `AdditionalCriterionSecond`                | Второй дополнительный классификационный критерий                   |
| `SL_K`         | `sl_k`      | `Is ClspUsed`                                 | `IsClspUsed`                               | Признак использования КСЛП                                         |
| `IT_SL`        | `it_sl`     | `Complexity Coefficient`                      | `ComplexityCoefficient`                    | Примененный коэффициент сложности лечения пациента                 |
| `—`            | `ksg`       | `Calculated Clinical Statistical GroupNumber` | `CalculatedClinicalStatisticalGroupNumber` | Расчитанный ТФОМС'ом номер КСГ                                     |
| `K_ZP`         | `k_zp`      | `Wage Target Coefficient `                    | `WageTargetCoefficient`                    | Коэффициент достижения целевых показателей уровня заработной платы |
| `PR_PR`        | `pr_pr`     | `Interrupted Case Payment Reason  `           | `InterruptedCasePaymentReason`             | Причина оплаты за прерванный случай лечения                        |
| `KOEF_PR`      | `koef_pr`   | `Interrupted Case Payment Share `             | `InterruptedCasePaymentShare `             | Доля оплаты прерванного случая лечения                             |

### Таблица `SL_KOEF`

| Транслитерация | БД ТФОМС РХ | Доменное название               | Идентификатор в коде          | Наименование                                     |
| -------------- | ----------- | ------------------------------- | ----------------------------- | ------------------------------------------------ |
| `IDSL`         | ``          | `Complexity Coefficient Number` | `ComplexityCoefficientNumber` | Номер коэффициента сложности лечения пациента    |
| `Z_SL`         | ``          | `Complexity Coefficient Value`  | `ComplexityCoefficientValue`  | Значение коэффициента сложности лечения пациента |

### Таблица `NAPR`

| Транслитерация | БД ТФОМС РХ | Доменное название                       | Идентификатор в коде  | Наименование                                     |
| -------------- | ----------- | --------------------------------------- | --------------------- | ------------------------------------------------ |
| `NAPR_DATE`    | `napr_date` | `Referral Date`                         | `ReferralDate`        | Дата направления                                 |
| `NAPR_V`       | `napr_v`    | `Referral Type`                         | `ReferralType`        | Вид направления                                  |
| `MET_ISSL`     | `met_issl`  | `Diagnostic Method`                     | `DiagnosticMethod`    | Метод диагностического исследования              |
| `NAPR_USL`     | `napr_usl`  | `Referred Service Code`                 | `ReferredServiceCode` | Медицинская услуга (код) указанная в направлении |
| `NAPR_MO`      | `napr_mo`   | `Referred To Medical Organization Code` | `ReferredToMoCode`    | Код МО, куда оформлено направление               |

### Таблица `NAZ`

| Транслитерация | БД ТФОМС РХ | Доменное название                       | Идентификатор в коде | Наименование                                      |
| -------------- | ----------- | --------------------------------------- | -------------------- | ------------------------------------------------- |
| `NAZ_N`        | `naz_n`     | `Sequence Number`                       | `SequenceNumber`     | Номер по порядку                                  |
| `NAZ_R`        | `naz_r`     | `Prescription Type`                     | `PrescriptionType`   | Вид назначения                                    |
| `NAZ_SP`       | `naz_sp`    | `Physician Specialty`                   | `PhysicianSpecialty` | Специальность врача                               |
| `NAZ_V`        | `naz_v`     | `Diagnostic Method`                     | `DiagnosticMethod`   | Метод диагностического исследования               |
| `NAZ_PMP`      | `naz_pmp`   | `Medical Care Profile`                  | `MedicalCareProfile` | Профиль медицинской помощи                        |
| `NAZ_PK`       | `naz_pk`    | `Bed Profile`                           | `BedProfile`         | Профиль койки                                     |
| `NAZ_USL`      | `naz_usl`   | `Service Code`                          | `ServiceCode`        | Медицинская услуга (код), указанная в направлении |
| `NAPR_DATE`    | `napr_date` | `Referral Date`                         | `ReferralDate`       | Дата направления                                  |
| `NAPR_MO`      | `napr_mo`   | `Referred To Medical Organization Code` | `ReferredToMoCode`   | Код МО, куда оформлено направление                |

### Таблица `SANK`

| Транслитерация | БД ТФОМС РХ | Доменное название                   | Идентификатор в коде             | Наименование                                                                   |
| -------------- | ----------- | ----------------------------------- | -------------------------------- | ------------------------------------------------------------------------------ |
| `S_CODE`       | `s_code`    | `Sanction Code`                     | `SanctionCode`                   | Идентификатор санкции                                                          |
| `S_SUM`        | `s_sum`     | `Sanction Amount`                   | `SanctionAmount`                 | Финансовая санкция                                                             |
| `S_TIP`        | `s_tip`     | `Control Type Code`                 | `ControlTypeCode`                | Код вида контроля                                                              |
| `S_OSN`        | `s_osn`     | `Refusal Reason Code`               | `RefusalReasonCode`              | Код причины отказа (частичной) оплаты                                          |
| `S_COM`        | `s_com`     | `Comment`                           | `Comment`                        | Комментарий                                                                    |
| `S_IST`        | `s_ist`     | `Source`                            | `Source`                         | Источник                                                                       |
| ``             | `sank_uid`  | `Sanction Details Identificator`    | `SanctionDetailsIdentificator`   |                                                                                |
| `S_ED_COL`     | `s_ed_col`  | `UnitsRemoved`                      | `Units Removed`                  | Количество единиц оплаты медицинской помощи подлежащей снятию актом экспертизы |
| `S_KSG`        | `s_ksg`     | `Clinical Statistical Group Number` | `ClinicalStatisticalGroupNumber` | Номер КСГ                                                                      |
| `S_NACT`       | `s_nact`    | `ExpertiseActNumber`                | `ExpertiseActNumber`             | Номер акта экспертизы                                                          |
| `S_DACT`       | `s_dact`    | `Expertise Act Date`                | `ExpertiseActDate`               | Дата акта проведения экспертизы                                                |
| `S_CODEX`      | `s_codex`   | `Expert Code`                       | `ExpertCode`                     | Код эксперта качества медицинской помощи                                       |

### Таблица `CRIT`

| Транслитерация | БД ТФОМС РХ | Доменное название          | Идентификатор в коде      | Наименование               |
| -------------- | ----------- | -------------------------- | ------------------------- | -------------------------- |
| `CRIT`         | `crit`      | `Classification Criterion` | `ClassificationCriterion` | Классификационный критерий |

### Таблица `DATE_INJ`

| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование  |
| -------------- | ----------- | ----------------- | -------------------- | ------------- |
| `DATE_INJ`     | `date_inj`  | `Injection Date`  | `InjectionDate`      | Дата инъекции |

### Таблица `ZAP`

| Транслитерация | БД ТФОМС РХ | Доменное название        | Идентификатор в коде   | Наименование                |
| -------------- | ----------- | ------------------------ | ---------------------- | --------------------------- |
| `N_ZAP`        | `n_zap`     | `Record Sequence Number` | `RecordSequenceNumber` | Номер позиции записи        |
| `PR_NOV`       | `pr_nov`    | `Is Revised Record`      | `IsRevisedRecord`      | Признак исправленной записи |

### Таблица ``

| Транслитерация | БД ТФОМС РХ | Доменное название | Идентификатор в коде | Наименование |
| -------------- | ----------- | ----------------- | -------------------- | ------------ |
| ``             | ``          | ``                | ``                   |              |
