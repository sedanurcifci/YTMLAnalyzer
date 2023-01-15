using Application.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Application.ClientLogic
{
    public class APIClient
    {
        string hostaddr = "";
        public APIClient(IConfiguration configuration)
        {
            hostaddr = configuration["HostAddr"];
        }
        public async Task<string> CreateUser(object model)
        {
            var addr = $"{hostaddr}/api/Signup";
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(addr, content);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
		public async Task<string> SigninUser(object model)
		{
			var addr = $"{hostaddr}/api/Signin";
			using (var client = new HttpClient())
			{
				var json = JsonConvert.SerializeObject(model);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(addr, content);
				var result = await response.Content.ReadAsStringAsync();
				return result;
			}
		}
		public async Task<UserModel> GetUser(int uid)
		{
			var addr = $"{hostaddr}/api/GetUser";
			using (var client = new HttpClient())
			{
				var json = JsonConvert.SerializeObject(uid);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(addr, content);
				var str = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<UserModel>(str);
				return result;
			}
		}
        public async Task<string> UpdateUsername(int uid, string value)
        {
            var model = new UpdateModel { uid= uid, value = value };
            var addr = $"{hostaddr}/api/UpdateUsername";
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(addr, content);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
        public async Task<string> UpdateEMail(int uid, string value)
        {
            var model = new UpdateModel { uid = uid, value = value };
            var addr = $"{hostaddr}/api/UpdateEmail";
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(addr, content);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
        public async Task UpdatePassword(int uid, string value)
        {
            var model = new UpdateModel { uid = uid, value = value };
            var addr = $"{hostaddr}/api/UpdatePassword";
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(addr, content);
            }
        }
        public async Task AnalyzIt(int uid, string text)
        {
            var model = new HomeModel { uid = uid, Job = text };
            var addr = $"{hostaddr}/api/AddJob";
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(addr, content);
            }
        }
		public async Task<List<JobModel>>GetUserJobs(int uid)
        {
			var addr = $"{hostaddr}/api/GetUserJobs";
			using (var client = new HttpClient())
			{
				var json = JsonConvert.SerializeObject(uid);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(addr, content);
				var str = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<List<JobModel>>(str);
				return result;
			}
		}
	}
    public class UpdateModel
    {
        public int uid;
        public string value;
    }
}
