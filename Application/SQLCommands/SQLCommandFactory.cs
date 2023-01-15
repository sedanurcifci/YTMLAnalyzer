using System.Data;
using System.Data.SqlClient;

namespace Application.SQLCommands
{
    public class SQLCommandFactory : IDBCommandFactory
    {
        private string ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;

        public SQLCommandFactory(IConfiguration configuration)
        {
            ConnectionString = configuration["Connstr"];
        }

        public IDbCommand GetCommand()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            command= connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        public IDataReader ExecuteCommand(ref IDbCommand command)
        {
            var data = command.ExecuteReader();
            return data;
        }
    }
}
