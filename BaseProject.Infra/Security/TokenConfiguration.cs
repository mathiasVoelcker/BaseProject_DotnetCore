namespace BaseProject.Infra.Security
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }

        public string IsUser { get; set; }

        public int Seconds { get; set; }
    }
}