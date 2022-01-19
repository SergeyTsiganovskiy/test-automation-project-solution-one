using framework.Base;
using System.Configuration;
using System.Data.SqlClient;

namespace framework.Settings
{
    public class Settings : ConfigurationSection
    {
        public string Url { get; set; }
        public BrowserType BrowserType { get; set; }
        public string LogPath { get; set; }
        public string ConnectionString { get; set; }
        public SqlConnection ApplicationDbConnection { get; set; }
    }
}
