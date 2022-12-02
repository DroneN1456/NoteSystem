namespace NoteSystemApi.Models
{
    public class Note
    {
        public string Name { get; set; }
        public double mNote { get; set; }
        public double Value { get; set; }

        public Note() { }
        public Note(string name, double mNote, double value)
        {
            Name = name;
            this.mNote = mNote;
            Value = value;
        }
    }
}
