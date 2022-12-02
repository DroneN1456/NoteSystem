using NoteSystemApi.Models;

namespace NoteSystemApi.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string code)
        {
            List<User> users = new List<User>();
            users.Add(new User("marcos", 10, "0000"));
            users.Add(new User("felipe", 3, "12857-9"));
            users.Add(new User("nicolas", 7, "ioajpj1-1"));
            users.Add(new User("luis", 5, "1024k04k0k1"));
            return users.Where(x => x.Code == code).FirstOrDefault();
        }
    }
}
