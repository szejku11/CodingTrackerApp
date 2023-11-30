using Microsoft.Data.Sqlite;
using System.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingTracker
{
    internal static class DbManager
    {
        private static string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        private static SqliteConnection connection = new SqliteConnection(connectionString);

        internal static void InitializeConnection()
        {
            using (connection)
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS coding_tracker (
	                  id	            INTEGER NOT NULL UNIQUE,
	                  start_time	    TEXT NOT NULL,
	                  end_time	        TEXT NOT NULL,
                      duration          TEXT NOT NULL,
	                  PRIMARY   KEY(id AUTOINCREMENT)
                      );";
                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }
        internal static void InsertRow()
        {

            (string startTime, string endTime) = UserInterface.GetInput();

            if (!string.IsNullOrEmpty(startTime))
            {
                string duration = Validation.CodingSessionDuration(startTime, endTime);

                using (connection)
                {
                    connection.Open();
                    var tableCmd = connection.CreateCommand();

                    tableCmd.CommandText =
                        @$"INSERT INTO [coding_tracker]
                       ([start_time],[end_time],[duration])   
                       VALUES
                       ('{startTime}','{endTime}','{duration}');";

                    tableCmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
