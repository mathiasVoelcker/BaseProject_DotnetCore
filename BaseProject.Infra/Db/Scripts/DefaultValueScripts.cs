namespace BaseProject.Infra.Db.Scripts
{
    public static class DefaultValueScripts
    {
        public readonly static string Get = "SELECT * FROM DefaultValues";

        public readonly static string Create = @"
        INSERT INTO DefaultValues 
            (DefaultText, DefaultNumber)
            VALUES (@DefaultText, @DefaultNumber)";
    }
}