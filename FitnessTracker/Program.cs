using System;
using System.Data.SqlClient;

namespace FitnessTracker
{
    class DatabaseManager
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=FitnessTrackerDB;Trusted_Connection=True;";

        public void AddWorkout(string focus, int duration)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Workouts (WorkoutDate, FocusArea, DurationMinutes) VALUES (@Date, @Focus, @Duration)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Focus", focus);
                cmd.Parameters.AddWithValue("@Duration", duration);

                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\nWorkout saved to SQL successfully!\n");
            }
        }

        // NEW METHOD: This reads the data from SQL and prints it to the console
        public void ViewWorkouts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT WorkoutDate, FocusArea, DurationMinutes FROM Workouts";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n--- Your Workout History ---");

                    // The reader loops through every row in your SQL table
                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(0);
                        string focus = reader.GetString(1);
                        int duration = reader.GetInt32(2);

                        Console.WriteLine($"{date.ToShortDateString()} | Focus: {focus} | Time: {duration} mins");
                    }
                    Console.WriteLine("----------------------------\n");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager db = new DatabaseManager();

            // The while loop keeps the app running until you press 3 to exit
            while (true)
            {
                Console.WriteLine("--- Turgut's Fitness Tracker ---");
                Console.WriteLine("1. Log a new workout");
                Console.WriteLine("2. View past workouts");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("What did you train today? (e.g. Push, Legs): ");
                    string area = Console.ReadLine();

                    Console.Write("How many minutes did it take?: ");
                    int mins = int.Parse(Console.ReadLine());

                    db.AddWorkout(area, mins);
                }
                else if (choice == "2")
                {
                    db.ViewWorkouts(); // Calls your new reading method
                }
                else if (choice == "3")
                {
                    break; // Exits the loop and closes the app
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Try again.\n");
                }
            }
        }
    }
}