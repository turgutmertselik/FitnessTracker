-- Run this script in SQL Server Management Studio to set up the database

CREATE DATABASE FitnessTrackerDB;
GO

USE FitnessTrackerDB;
GO

CREATE TABLE Workouts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    WorkoutDate DATETIME NOT NULL,
    FocusArea NVARCHAR(100) NOT NULL,
    DurationMinutes INT NOT NULL
);
GO

CREATE TABLE DietLog (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    LogDate DATETIME NOT NULL,
    FoodItem NVARCHAR(100) NOT NULL,
    Calories INT NOT NULL,
    ProteinGrams INT NOT NULL
);
GO
