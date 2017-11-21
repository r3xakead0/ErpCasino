﻿CREATE TABLE [dbo].[TbPlanillaBoleta] (
    [IdPlanillaBoleta]          INT             IDENTITY (1, 1) NOT NULL,
    [IdPlanilla]                INT             NOT NULL,
    [Anho]                      SMALLINT        NOT NULL,
    [Mes]                       TINYINT         NOT NULL,
    [MesNombre]                 VARCHAR (15)    NOT NULL,
    [MesDias]                   TINYINT         NOT NULL,
    [EmpresaNombre]             VARCHAR (100)   NOT NULL,
    [EmpresaRuc]                VARCHAR (15)    NOT NULL,
    [EmpresaDistrito]           VARCHAR (150)   NOT NULL,
    [EmpresaDireccion]          VARCHAR (255)   NOT NULL,
    [EmpleadoCodigo]            VARCHAR (10)    NOT NULL,
    [EmpleadoNombres]           VARCHAR (100)   NOT NULL,
    [EmpleadoApellidos]         VARCHAR (100)   NOT NULL,
    [EmpleadoCargo]             VARCHAR (50)    NOT NULL,
    [EmpleadoNroDocumento]      VARCHAR (20)    NOT NULL,
    [EmpleadoFechaIngreso]      DATE            NOT NULL,
    [EmpleadoFechaCese]         DATE            NULL,
    [EmpleadoVacacionSalida]    DATE            NULL,
    [EmpleadoVacacionRetorno]   DATE            NULL,
    [EmpleadoEsSaludCodigo]     VARCHAR (20)    NULL,
    [EmpleadoSppCodigo]         VARCHAR (20)    NULL,
    [EmpleadoSppEntidad]        VARCHAR (50)    NULL,
    [DiasLaborados]             TINYINT         NOT NULL,
    [DiasNoLaborados]           TINYINT         NOT NULL,
    [DiasSinGoceHaber]          TINYINT         NOT NULL,
    [DiasSubsidiado]            TINYINT         NOT NULL,
    [HorasNormales]             SMALLINT        NOT NULL,
    [Sueldo]                    DECIMAL (10, 2) NOT NULL,
    [AsignacionFamiliar]        DECIMAL (10, 2) NOT NULL,
    [BonificacionNocturna]      DECIMAL (10, 2) NOT NULL,
    [MovilidadTranslado]        DECIMAL (10, 2) NOT NULL,
    [SubsidioDescansoMedico]    DECIMAL (10, 2) NOT NULL,
    [BonificacionHorasExtras]   DECIMAL (10, 2) NOT NULL,
    [CantidadHorasExtras]       SMALLINT        NOT NULL,
    [Cts]                       DECIMAL (10, 2) NOT NULL,
    [Vacaciones]                DECIMAL (10, 2) NOT NULL,
    [FeriadoDominical]          DECIMAL (10, 2) NOT NULL,
    [Gratificacion]             DECIMAL (10, 2) NOT NULL,
    [BonificacionGratificacion] DECIMAL (10, 2) NOT NULL,
    [TotalBruto]                DECIMAL (10, 2) NOT NULL,
    [AfpFondoMonto]             DECIMAL (10, 2) NOT NULL,
    [AfpSeguroMonto]            DECIMAL (10, 2) NOT NULL,
    [AfpComisionMonto]          DECIMAL (10, 2) NOT NULL,
    [IpssVidaMonto]             DECIMAL (10, 2) NOT NULL,
    [OnpMonto]                  DECIMAL (10, 2) NOT NULL,
    [RentaQuintaMonto]          DECIMAL (10, 2) NOT NULL,
    [InasistenciasDias]         TINYINT         NOT NULL,
    [InasistenciasMonto]        DECIMAL (10, 2) NOT NULL,
    [AdelantoMonto]             DECIMAL (10, 2) NOT NULL,
    [TardanzaMinutos]           SMALLINT        NOT NULL,
    [TardanzaMonto]             DECIMAL (10, 2) NOT NULL,
    [GratificacionMonto]        DECIMAL (10, 2) NOT NULL,
    [RetencionJudicialMonto]    DECIMAL (10, 2) NOT NULL,
    [SeguroVidaTrabajadorMonto] DECIMAL (10, 2) NOT NULL,
    [IpssSaludTrabajadorMonto]  DECIMAL (10, 2) NOT NULL,
    [SeguroVidaEmpleadoMonto]   DECIMAL (10, 2) NOT NULL,
    [IpssSaludEmpleadoMonto]    DECIMAL (10, 2) NOT NULL,
    [TotalDescuentos]           DECIMAL (10, 2) NOT NULL,
    [TotalAportes]              DECIMAL (10, 2) NOT NULL,
    [TotalNeto]                 DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_TbPlanillaBoleta] PRIMARY KEY CLUSTERED ([IdPlanillaBoleta] ASC),
    CONSTRAINT [FK_TbPlanillaBoleta_TbPlanilla] FOREIGN KEY ([IdPlanilla]) REFERENCES [dbo].[TbPlanilla] ([IdPlanilla]) ON DELETE CASCADE
);
