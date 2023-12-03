using System.Data;
using System.Data.SqlClient;

internal class Program
{
    public static void Main(string[] args)
    {
        // Day1Part1.Run(args);
        Day1Part2.Run(args);
        
        var x = NotSoSecureCode(args[0]);

    }

    public static IDataReader NotSoSecureCode(string sql) {
        var connection = new SqlConnection();
        string query = $"SELECT * FROM Users WHERE Name = {sql}";
        var command = new SqlCommand(query, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }
}

