# Health & Fitness Hub

An expanded console-based application designed to log and track both daily fitness routines and dietary intake. Built with a focus on scalable back-end architecture and multi-table database integration.

## Tech Stack
* **Language:** C#
* **Concepts:** Object-Oriented Programming (OOP)
* **Database:** SQL Server (Multi-table Relational Database)
* **Data Access:** ADO.NET (SqlConnection, SqlCommand, SqlDataReader)

## Features
* **Dual Tracking System:** Users can log both specific workout focus areas and individual meals/snacks through a unified console interface.
* **Macro & Metric Storage:** Tracks exercise duration (minutes) alongside nutritional values (calories and protein grams).
* **Multi-Table Relational Database:** Connects to a local SQL Server database utilizing separate tables (`Workouts` and `DietLog`) to organize user data efficiently.
* **Secure Data Handling:** Executes real-time, parameterized SQL queries via C# to prevent SQL injection and perform full CRUD operations.
