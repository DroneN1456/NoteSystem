namespace NoteSystemApi.Models
{
    public class Result
    {
        public List<User> users { get; set; }
        public Result() { }
        public Result(List<User> users)
        {
            this.users = users;
        }
    }
}
