using Application.Models;
using Application.SQLCommands;

namespace Application.ApiLogic
{
	public class GetAllJobs
	{
		private IDBCommandFactory _dBCommandFactory;

		public GetAllJobs(IDBCommandFactory dBCommandFactory)
		{
			_dBCommandFactory = dBCommandFactory;
		}
		public List<JobModel> Execute()
		{
			var model = new List<JobModel>();
			var command = _dBCommandFactory.GetCommand();
			command.CommandText = "GetAllJobs";

			var data = _dBCommandFactory.ExecuteCommand(ref command);
			while(data.Read())
			{
				model.Add(new JobModel { 
					uid = data.GetInt32(0),
					Job = data.GetString(1),
					Status = data.GetInt32(2),
					Time = data.GetDateTime(3)
				});
			}
			command.Connection.Close();
			command.Connection.Dispose();
			command.Dispose();
			return model;
		}
	}
}
