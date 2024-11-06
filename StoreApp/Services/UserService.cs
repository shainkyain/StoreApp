using StoreApp.Models;
using System.IO;
using Newtonsoft.Json;

namespace StoreApp.Services
{
    public class UserService
    {
        private readonly string _filepath = "C:\\Users\\Devil\\Desktop\\C#\\StoreApp\\StoreApp\\wwwroot\\js\\users.json";

        public List<User> GetAllUsers()
        {
            if (!File.Exists(_filepath))
            {
                return new List<User>();
            }

            var jsonData = File.ReadAllText(_filepath);
            
            return JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();
        }
        public void AddUser(User newUser)
        {
            var users = GetAllUsers();
            newUser.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
            users.Add(newUser);
            SaveUsers(users);
        }

        private void SaveUsers(List<User> users)
        {
            var jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(_filepath, jsonData);
        }
    }
}
