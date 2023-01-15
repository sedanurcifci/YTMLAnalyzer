using Application.SQLCommands;
using System.Data.SqlClient;

namespace Application.ApiLogic
{
    public class UpdatePassword
    {
        private IDBCommandFactory _dBCommandFactory;

        public UpdatePassword(IDBCommandFactory dBCommandFactory)
        {
            _dBCommandFactory = dBCommandFactory;
        }
        public void Execute(int uid, string value)
        {
            var command = _dBCommandFactory.GetCommand();
            command.CommandText = "UpdateUserPassword";

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@uid";
            parameter.Value = uid;
            parameter.DbType = System.Data.DbType.Int32;
            parameter.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@password";
            parameter.Value = value;
            parameter.DbType = System.Data.DbType.String;
            parameter.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(parameter);

            _dBCommandFactory.ExecuteCommand(ref command);
            command.Connection.Close();
            command.Connection.Dispose();
            command.Dispose();
        }
    }
}
