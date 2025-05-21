namespace EFCoreJSONSupportDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // JSON stored object
        public List<Hobby>? Hobbies { get; set; }
    }
}
