using System;
using System.Data.SqlClient;

namespace FitnessTracker
{
    class DatabaseManager
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=FitnessTrackerDB;Trusted_Connection=True;";

        // --- WORKOUT METHODS ---
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
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetDateTime(0).ToShortDateString()} | Focus: {reader.GetString(1)} | Time: {reader.GetInt32(2)} mins");
                    }
                    Console.WriteLine("----------------------------\n");
                }
            }
        }

        // --- NEW DIET METHODS ---
        public void AddMeal(string food, int calories, int protein)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO DietLog (LogDate, FoodItem, Calories, ProteinGrams) VALUES (@Date, @Food, @Calories, @Protein)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Food", food);
                cmd.Parameters.AddWithValue("@Calories", calories);
                cmd.Parameters.AddWithValue("@Protein", protein);

                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\nMeal logged to SQL successfully!\n");
            }
        }

        public void ViewMeals()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT LogDate, FoodItem, Calories, ProteinGrams FROM DietLog";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n--- Your Diet History ---");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetDateTime(0).ToShortDateString()} | {reader.GetString(1)} | {reader.GetInt32(2)} kcal | {reader.GetInt32(3)}g Protein");
                    }
                    Console.WriteLine("-------------------------\n");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager db = new DatabaseManager();

            while (true)
            {
                Console.WriteLine("--- Turgut's Health & Fitness Hub ---");
                Console.WriteLine("1. Log a Workout");
                Console.WriteLine("2. View Workouts");
                Console.WriteLine("3. Log a Meal/Snack");
                Console.WriteLine("4. View Diet History");
                Console.WriteLine("5. Exit");
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
                    db.ViewWorkouts();
                }
                else if (choice == "3")
                {
                    Console.Write("What did you eat?: ");
                    string food = Console.ReadLine();
                    Console.Write("Estimated calories?: ");
                    int cals = int.Parse(Console.ReadLine());
                    Console.Write("Estimated protein (grams)?: ");
                    int protein = int.Parse(Console.ReadLine());
                    db.AddMeal(food, cals, protein);
                }
                else if (choice == "4")
                {
                    db.ViewMeals();
                }
                else if (choice == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Try again.\n");
                }
            }
        }
    }
}
