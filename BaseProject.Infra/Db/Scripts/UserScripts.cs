namespace BaseProject.Infra.Db.Scripts
{
    public static class UserScripts
    {
        public readonly static string Get = "SELECT * FROM USERS WHERE username = @username";

        public readonly static string Insert = @"INSERT INTO USERS 
                            (Username, Password, Salt)
                            VALUES (@username, @password, @salt)";
    }
}