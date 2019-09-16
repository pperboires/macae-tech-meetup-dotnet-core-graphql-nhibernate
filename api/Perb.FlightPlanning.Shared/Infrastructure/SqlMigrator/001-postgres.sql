create schema Core;

create table Core.AircraftType
(
    Id UUID NOT NULL,
    Name varchar(100) NOT NULL,
    Code varchar(50) NOT NULL,
    CONSTRAINT PK_AircraftType PRIMARY KEY (Id),
    CONSTRAINT UN_AircraftType_Name UNIQUE (Name)
);


create table Core.AircraftContract
(
    Id UUID NOT NULL,
    Name varchar(100) NOT NULL,
    DailyTime bigint NOT NULL,
    MaintenanceTime bigint NOT NULL,
    HasCrewRegulation boolean NOT NULL,
    AircraftTypeId UUID NOT NULL,
    CONSTRAINT PK_AircraftContract PRIMARY KEY (Id),
    CONSTRAINT FK_AircraftContract_AircraftTypeId FOREIGN KEY (AircraftTypeId) REFERENCES Core.AircraftType(Id),
    CONSTRAINT UN_AircraftContract_Name UNIQUE (Name)
);

create table Core.SeatsByFlightDuration
(
    Id UUID NOT NULL,
    Seats int NOT NULL,
    MinInMinutes int NOT NULL,
    MaxInMinutes int NOT NULL,
    AircraftTypeId UUID NOT NULL,
    CONSTRAINT PK_SeatsByFlightDuration PRIMARY KEY (Id),
    CONSTRAINT FK_SeatsByFlightDuration_AircraftTypeId FOREIGN KEY (AircraftTypeId) REFERENCES Core.AircraftType(Id)
);

create table Core.MarineUnit
(
  Id UUID NOT NULL,
  Name varchar(100) NOT NULL,
  Demand int NOT NULL,
  CONSTRAINT PK_MarineUnit PRIMARY KEY (Id)
);

create table Core.FlightDuration
(
  Id UUID NOT NULL,
  AirportId UUID NOT NULL,
  AircraftTypeId UUID NOT NULL,
  RoundTripDurationInMinutes int NOT NULL,
  MarineUnitId UUID NOT NULL,
  CONSTRAINT PK_FlightDuration PRIMARY KEY (Id),
  CONSTRAINT FK_FlightDuration_AircraftTypeId FOREIGN KEY (AircraftTypeId) REFERENCES Core.AircraftType(Id),
  CONSTRAINT FK_FlightDuration_MarineUnitId FOREIGN KEY (MarineUnitId) REFERENCES COre.MarineUnit(Id)
);

create table Core.FlightPreference
(
  Id UUID NOT NULL,
  MarineUnitId UUID NOT NULL,
  DayOfWeek varchar(50) NOT NULL,
  StartDate bigint NOT NULL,
  EndDate bigint NOT NULL,
  CONSTRAINT PK_FlightPreference PRIMARY KEY (Id),
  CONSTRAINT FK_FlightPreference_MarineUnitId FOREIGN KEY (MarineUnitId) REFERENCES Core.MarineUnit(Id)
);


create table Core.Airport
(
  Id UUID NOT NULL,
  Name varchar(100) NOT NULL,
  Iata varchar(5) NULL,
  Icao varchar(10) NULL,
  CONSTRAINT PK_Airport PRIMARY KEY (Id)
);


alter table Core.FlightDuration
add CONSTRAINT FK_FlightDuration_AirportId FOREIGN KEY (AirportId) REFERENCES Core.Airport(Id);

create table Core.Planning
(
  Id UUID NOT NULL,
  Name varchar(100) NOT NULL,
  Comments varchar(1000) NULL,
  FirstFlight bigint NOT NULL,
  LastFlight bigint NOT NULL,
  LastFlightType varchar(50) NOT NULL,
  AirportId UUID NOT NULL,
  CONSTRAINT PK_Planning PRIMARY KEY (Id)
);

alter table Core.Planning
add CONSTRAINT FK_Planning_AirportId FOREIGN KEY (AirportId) REFERENCES Core.Airport(Id);

create table Core.PlanningDayOfWeek
(
  PlanningId UUID NOT NULL,
  DayOfWeek varchar(15) NOT NULL
);

alter table Core.PlanningDayOfWeek
add CONSTRAINT FK_PlanningDayOfWeek_PlanningId FOREIGN KEY (PlanningId) REFERENCES Core.Planning(Id);

create table Core.PlanningMarineUnit
(
  PlanningId UUID NOT NULL,
  MarineUnitId UUID NOT NULL
);

alter table Core.PlanningMarineUnit
add CONSTRAINT FK_PlanningMarineUnit_PlanningId FOREIGN KEY (PlanningId) REFERENCES Core.Planning(Id);

alter table Core.PlanningMarineUnit
add CONSTRAINT FK_PlanningMarineUnit_MarineUnitId FOREIGN KEY (MarineUnitId) REFERENCES Core.MarineUnit(Id);

alter table Core.AircraftContract
add PlanningId UUID NOT NULL;

alter table Core.AircraftContract
add CONSTRAINT FK_AircraftContract_PlanningId FOREIGN KEY (PlanningId) REFERENCES Core.Planning(Id);

-- solution
create table Core.Solution
(
  Id UUID NOT NULL,
  Name varchar(100) NULL,
  Date timestamp NOT NULL,
  PlanningId UUID NOT NULL,
  ScoreSoft bigint NOT NULL,
  ScoreMedium bigint NOT NULL,
  ScoreHard bigint NOT NULL,
  CONSTRAINT PK_Solution PRIMARY KEY (Id)
);

alter table Core.Solution
add CONSTRAINT FK_Solution_PlanningId FOREIGN KEY (PlanningId) REFERENCES Core.Planning(Id);

create table Core.PlannedFlight
(
  Id UUID NOT NULL,
  DayOfWeek varchar(15) NOT NULL,
  StartDate bigint NOT NULL,
  EndDate bigint NOT NULL,
  Seats int NULL,
  AircraftContractId UUID NOT NULL,
  MarineUnitId UUID NOT NULL,
  SolutionId UUID NOT NULL,
  CONSTRAINT PK_PlannedFlight PRIMARY KEY (Id)
);

alter table Core.PlannedFlight
add CONSTRAINT FK_PlannedFlight_SolutionId FOREIGN KEY (SolutionId) REFERENCES Core.Solution(Id);

alter table Core.PlannedFlight
add CONSTRAINT FK_PlannedFlight_AircraftContractId FOREIGN KEY (AircraftContractId) REFERENCES Core.AircraftContract(Id);

alter table Core.PlannedFlight
add CONSTRAINT FK_PlannedFlight_MarineUnitId FOREIGN KEY (MarineUnitId) REFERENCES Core.MarineUnit(Id);
