using MySql.Data.MySqlClient;
using System.Threading.Tasks;

public class DatabaseConnectionChecker
{
    private readonly string _connectionString;

    public DatabaseConnectionChecker(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<bool> IsConnectionSuccessfulAsync()
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection.State == System.Data.ConnectionState.Open;
        }
        catch
        {
            return false;
        }
    }
}
