create schema Core
GO

create table Core.AircraftType
(
    Id uniqueidentifier NOT NULL,
    Name nvarchar(100) NOT NULL,
    Code nvarchar(50) NOT NULL,
    CONSTRAINT PK_AircraftType PRIMARY KEY (Id),
    CONSTRAINT UN_AircratType_Name UNIQUE (Name)
)
GO

create table Core.AircraftContract
(
    Id uniqueidentifier NOT NULL,
    Name nvarchar(100) NOT NULL,
    DailyTime bigint NOT NULL,
    MaintenanceTime bigint NOT NULL,
    HasCrewRegulation bit NOT NULL,
    AircraftTypeId uniqueidentifier NOT NULL,
    CONSTRAINT PK_AircraftContract PRIMARY KEY (Id),
    CONSTRAINT FK_AircraftContract_AircraftTypeId FOREIGN KEY (AircraftTypeId) REFERENCES Core.AircraftType(Id),
    CONSTRAINT UN_AircraftContract_Name UNIQUE (Name)
)
GO

create table Core.SeatsByFlightDuration
(
    Id uniqueidentifier NOT NULL,
    Seats int NOT NULL,
    MinInMinutes int NOT NULL,
    MaxInMinutes int NOT NULL,
    AircraftTypeId uniqueidentifier NOT NULL,
    CONSTRAINT PK_SeatsByFlightDuration PRIMARY KEY (Id),
    CONSTRAINT FK_SeatsByFlightDuration_AircraftTypeId FOREIGN KEY (AircraftTypeId) REFERENCES Core.AircraftType(Id),
)
GO