namespace Database.Models.Securities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int SecurityId { get; set; }
        public Security Authorization { get; set; }
    }
}
