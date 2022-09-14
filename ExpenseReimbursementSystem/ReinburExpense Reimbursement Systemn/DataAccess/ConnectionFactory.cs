namespace ConnectionFactory;
using System.Data.SqlClient;
using sensitive;

public class ConnectionFactoryClass
{
    //Hidding the password in another file for now, can change later
    private readonly string _connectionString;

    private static ConnectionFactoryClass? _instance;

    private ConnectionFactoryClass(string connectionString)
    {
        _connectionString = connectionString;
    }
    public static ConnectionFactoryClass GetInstance(string ConnectionString) //make sure that there exist only one Connections Factory Object
    {
        if(_instance == null)
        {
            _instance = new ConnectionFactoryClass(ConnectionString);
        }
            return _instance;
    }

    public SqlConnection GetConnection() //returns just the connection to the server
    {
        SqlConnection connection = new SqlConnection(_connectionString); //I think you can do this is a cute one liner, but I forgot how to
        return connection;
    }
}