namespace BaseProject.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public byte[] Password { get; set; }

        public byte[] Salt { get; set; }
    }
}