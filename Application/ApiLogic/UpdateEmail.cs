using Application.Models.API;
using Application.SQLCommands;
using System.Data.SqlClient;
using System.Reflection;

namespace Application.ApiLogic
{
    public class UpdateEmail
    {
        private IDBCommandFactory _dBCommandFactory;

        public UpdateEmail(IDBCommandFactory dBCommandFactory)
        {
            _dBCommandFactory = dBCommandFactory;
        }
        public int Execute(int uid, string value)
        {
            var resultCode = -255;
            var command = _dBCommandFactory.GetCommand();
            command.CommandText = "UpdateUserEMail";

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@uid";
            parameter.Value = uid;
            parameter.DbType = System.Data.DbType.Int32;
            parameter.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@email";
            parameter.Value = value;
            parameter.DbType = System.Data.DbType.String;
            parameter.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@status";
            parameter.DbType = System.Data.DbType.Int32;
            parameter.Direction = System.Data.ParameterDirection.Output;
            command.Parameters.Add(parameter);

            _dBCommandFactory.ExecuteCommand(ref command);
            resultCode = (int)((SqlCommand)command).Parameters["@status"].Value;
            command.Connection.Close();
            command.Connection.Dispose();
            command.Dispose();
            return resultCode;
        }
    }
}
