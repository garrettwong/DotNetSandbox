using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.DirectoryServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using DirectoryEntry = System.DirectoryServices.DirectoryEntry;

internal class Program
{
    public static void Main(string[] args)
    {
        // Day1Part1.Run(args);
        Day1Part2.Run(args);

        Day2Part1.Run(args);

        var q = HasNumberEmbedded(args[0]);
        Console.WriteLine(q);
        var sqlDataReader = NotSoSecureQuery(args[0]);
        Console.WriteLine(sqlDataReader);
        LdapInjection(args[0]);
        CommandInjection(args[0]);
        PathTraversal("/Users/v01k23nladf/", ".ssh/id_rsa");
        PathTraversal("/Users/v01k23nladf/", args[0]);
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

    public static void LdapInjection(string searchString) {
        DirectoryEntry rootEntry = new DirectoryEntry("LDAP://some.ldap.server.com");
        rootEntry.AuthenticationType = AuthenticationTypes.None; //Or whatever it need be
        DirectorySearcher searcher = new DirectorySearcher(rootEntry);
        var queryFormat = "(&(objectClass=user)(objectCategory=person)(|(SAMAccountName=*{0}*)(cn=*{0}*)(gn=*{0}*)(sn=*{0}*)(email=*{0}*)))";
        searcher.Filter = string.Format(queryFormat, searchString);
        foreach(SearchResult result in searcher.FindAll()) 
        {
            Console.WriteLine("account name: {0}", result.Properties["samaccountname"].Count > 0 ? result.Properties["samaccountname"][0] : string.Empty);
            Console.WriteLine("common name: {0}", result.Properties["cn"].Count > 0 ? result.Properties["cn"][0] : string.Empty);
        }
    }

    public static void CommandInjection(string cmd) {
        string strCmdText= @"/C dir c:\files\" + cmd;
        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", strCmdText);
        Process.Start(info);
    }

    public static void PathTraversal(string dirName, string x) {
        string ROOT = @"/";

        var downloadDirectory = Path.Combine(ROOT, dirName);
        var dest = Path.Combine(dirName, x);
        Console.WriteLine(File.ReadAllText(dest));
    }
}
