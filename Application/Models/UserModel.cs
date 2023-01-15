namespace Application.Models
{
	public class UserModel
	{
		public string Username { get; set; }
		public string EMail { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
		public int UpdateType { get; set; }
		public List<JobModel> Jobs { get; set; }
	}
}
