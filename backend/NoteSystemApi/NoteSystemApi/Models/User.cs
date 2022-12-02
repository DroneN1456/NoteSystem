namespace NoteSystemApi.Models
{
    public class User
    {
        public string Name { get; set; }
        public double Note { get; set; }
        public string? Code { get; set; }

        public User(string name, double note, string? code = "0000")
        {
            Name = name;
            Note = note;
            Code = code;
        }


        
    }
}
