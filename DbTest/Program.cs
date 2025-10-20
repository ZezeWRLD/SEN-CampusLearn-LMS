using System;
using Npgsql;

class Program
{
    static void Main()
    {
        // ✅ Replace these values with your Supabase credentials
        var connectionString = "Host=aws-1-ap-southeast-2.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.tspbuvfvayujbjxtxngb;Password=3JAyVUlQf3h3O28f;Pooling=true;SSL Mode=Require;Trust Server Certificate=true;";

        using var connection = new NpgsqlConnection(connectionString);

        try
        {
            Console.WriteLine("Connecting to Supabase...");
            connection.Open();
            Console.WriteLine("✅ Connection successful!");

            // Optional: Run a test query
            using var cmd = new NpgsqlCommand("SELECT NOW()", connection);
            var result = cmd.ExecuteScalar();
            Console.WriteLine($"Server time: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Connection failed: {ex.Message}");
        }
    }
}
