using Application.SQLCommands;

namespace Application.ApiLogic
{
    public class AddJob
    {
        private IDBCommandFactory _dBCommandFactory;

        public AddJob(IDBCommandFactory dBCommandFactory)
        {
            _dBCommandFactory = dBCommandFactory;
        }
        public void Execute(int uid, string job)
        {
            var command = _dBCommandFactory.GetCommand();
            command.CommandText = "AddJob";

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@uid";
            parameter.Value = uid;
            parameter.DbType = System.Data.DbType.Int32;
            parameter.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@job";
            parameter.Value = job;
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
