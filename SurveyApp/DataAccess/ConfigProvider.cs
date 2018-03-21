namespace DataAccess
{
    public static class ConfigProvider
    {
        public static string DbConnectionString()
        {
            //SurveyApp
            string connectionString = "Integrated Security=SSPI;Initial Catalog=SurveyApp;Data Source=localhost;";

            return connectionString;
        }
    }
}
