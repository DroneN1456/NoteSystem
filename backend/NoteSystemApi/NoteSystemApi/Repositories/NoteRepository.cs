using System.Text.Json;

namespace NoteSystemApi.Repositories
{
    public static class NoteRepository
    {
        public static Dictionary<string, double> notes= new Dictionary<string, double>();
        private static void InitNotes()
        {
            var path = @"./Data/notes.json";
            var json = File.ReadAllText(path);
            if (json.Length < 8)
            {
                UserRepository.initUsers();
                foreach (var x in UserRepository.userList)
                {
                    if (notes.ContainsKey(x.Name))
                    {
                        notes[x.Name] = x.Note;
                    }
                    else
                    {
                        notes.Add(x.Name, x.Note);
                    }
                }
                json = JsonSerializer.Serialize(notes);
                File.WriteAllText(path, json);
            }
            else
            {
                notes = JsonSerializer.Deserialize<Dictionary<string, double>>(json);
            }
        }
        public static string SetNote(string name, double note)
        {
            InitNotes();
            notes[name] = notes[name] + note;
            var json = JsonSerializer.Serialize(notes);
            var path = @"./Data/notes.json";
            File.WriteAllText(path, json);
            return json;
        }

       
    }
}
