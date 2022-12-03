using NoteSystemApi.Models;
using System.Text.Json;
using NoteSystemApi.Services;

namespace NoteSystemApi.Repositories
{
    public class UserRepository
    {

        public static int votted = 0;
        public static List<User> userList = new List<User>();

        public static User Get(string username, string code)
        {
            initUsers();
            return userList.Where(x => x.Code == code).FirstOrDefault();
        }

        public static string AddUser(User aux){
           var path = @"./data/users.json"; 
           var json = File.ReadAllText(path);
           if(json.Length > 8){
            userList = JsonSerializer.Deserialize<List<User>>(json);
           }else{
            initUsers();
           }
           userList.Add(aux);
           json = JsonSerializer.Serialize(userList);
           File.WriteAllText(path, json);
           return json;
        }

        public static void initUsers(){
            var path = @"./data/users.json";
            var json = File.ReadAllText(path);
            if(json.Length > 8)
            {
                userList = JsonSerializer.Deserialize<List<User>>(json);
                return;
            }
            userList.Add(new User("Ana Carolina", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Felipe", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Guilherme", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Pedro Poglitsch", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Ana Julia", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Anna Clara Vian", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("David Nicolas", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Douglas", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Felipe", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Francisco", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("João Lucas", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("José Neto", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Laura", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Lyvia Trimer", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Maria Luisa", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Nicolas", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Rhuan", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Ana Clara Raimundo", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("João Gabriel", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Julia Toledo", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Julia Vasconcelos", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Manuela", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Maria Eduarda", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Renan", 0, CodeService.GenerateCode(), 0));
            userList.Add(new User("Walter", 0, CodeService.GenerateCode(), 0));
            json = JsonSerializer.Serialize(userList);
            File.WriteAllText(path, json);
        }
    }
}
