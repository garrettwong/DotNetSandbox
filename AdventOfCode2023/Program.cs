using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

internal class Program
{
    public static void Main(string[] args)
    {
        // Day1Part1.Run(args);
        Day1Part2.Run(args);

        var q = HasNumberEmbedded(args[0]);
        Console.WriteLine(q);
        var sqlDataReader = NotSoSecureQuery(args[0]);
        Console.WriteLine(sqlDataReader);
    }

    public static IDataReader NotSoSecureQuery(string sql)
    {
        var connection = new SqlConnection();
        string query = $"SELECT * FROM Users WHERE Name = {sql}";
        var command = new SqlCommand(query, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public static Match HasNumberEmbedded(string inputToTest)
    {
        const string REGEX = @"^(\d+)+$";
        return System.Text.RegularExpressions.Regex.Match(inputToTest, REGEX);
    }
}

