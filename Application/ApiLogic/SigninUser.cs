using Application.Models.API;
using Application.SQLCommands;
using System.Data.SqlClient;

namespace Application.ApiLogic
{
	public class SigninUser
	{
		private IDBCommandFactory _dBCommandFactory;

		public SigninUser(IDBCommandFactory dBCommandFactory)
		{
			_dBCommandFactory = dBCommandFactory;
		}

		public int Execute(SigninUserAPIModel model)
		{
			var resultCode = -255;
			var command = _dBCommandFactory.GetCommand();
			command.CommandText = "SignInUser";

			var parameter = command.CreateParameter();
			parameter.ParameterName = "@username";
			parameter.Value = model.Username;
			parameter.DbType = System.Data.DbType.String;
			parameter.Direction = System.Data.ParameterDirection.Input;
			command.Parameters.Add(parameter);

			parameter = command.CreateParameter();
			parameter.ParameterName = "@password";
			parameter.Value = model.Password;
			parameter.DbType = System.Data.DbType.String;
			parameter.Direction = System.Data.ParameterDirection.Input;
			command.Parameters.Add(parameter);

			parameter = command.CreateParameter();
			parameter.ParameterName = "@uid";
			parameter.DbType = System.Data.DbType.Int32;
			parameter.Direction = System.Data.ParameterDirection.Output;
			command.Parameters.Add(parameter);

			_dBCommandFactory.ExecuteCommand(ref command);
			resultCode = (int)((SqlCommand)command).Parameters["@uid"].Value;
			command.Connection.Close();
			command.Connection.Dispose();
			command.Dispose();
			return resultCode;
		}
	}
}
