using Application.Models.API;
using Application.SQLCommands;
using System.Data.SqlClient;
using System.Reflection;

namespace Application.ApiLogic
{
	public class GetUser
	{
		private IDBCommandFactory _dBCommandFactory;

		public GetUser(IDBCommandFactory dBCommandFactory)
		{
			_dBCommandFactory = dBCommandFactory;
		}

		public UserAPIModel Execute(int uid)
		{
			var model = new UserAPIModel();
			var command = _dBCommandFactory.GetCommand();
			command.CommandText = "GetUser";

			var parameter = command.CreateParameter();
			parameter.ParameterName = "@uid";
			parameter.Value = uid.ToString();
			parameter.DbType = System.Data.DbType.String;
			parameter.Direction = System.Data.ParameterDirection.Input;
			command.Parameters.Add(parameter);

			var data = _dBCommandFactory.ExecuteCommand(ref command);

			while (data.Read())
			{
				model.Username = data.GetString(0);
				model.EMail= data.GetString(1);
				var role = data.GetInt32(2);
				if (role == 2)
				{
					model.IsAdmin = true;
				}
				else
					model.IsAdmin = false;
			}

			command.Connection.Close();
			command.Connection.Dispose();
			command.Dispose();
			return model;
		}
	}
}
