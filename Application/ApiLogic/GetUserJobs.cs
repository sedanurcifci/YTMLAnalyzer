using Application.Models;
using Application.SQLCommands;

namespace Application.ApiLogic
{
	public class GetUserJobs
	{
		private IDBCommandFactory _dBCommandFactory;

		public GetUserJobs(IDBCommandFactory dBCommandFactory)
		{
			_dBCommandFactory = dBCommandFactory;
		}
		public List<JobModel> Execute(int uid)
		{
			var model = new List<JobModel>();
			var command = _dBCommandFactory.GetCommand();
			command.CommandText = "GetUserJobs";

			var parameter = command.CreateParameter();
			parameter.ParameterName = "@uid";
			parameter.Value = uid;
			parameter.DbType = System.Data.DbType.Int32;
			parameter.Direction = System.Data.ParameterDirection.Input;
			command.Parameters.Add(parameter);

			var data = _dBCommandFactory.ExecuteCommand(ref command);
			while (data.Read())
			{
				model.Add(new JobModel
				{
					uid = uid,
					Job = data.GetString(0),
					Status = data.GetInt32(1),
					Time = data.GetDateTime(2)
				});
			}
			command.Connection.Close();
			command.Connection.Dispose();
			command.Dispose();
			return model;
		}
	}
}
