using System.Data.SqlClient;
using sqlapp.Models; // Add this

namespace sqlapp.Services
{
    public class ActivityService
    {
        private static string db_source = "appdb20002025.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "Welcome@1234";
        private static string db_database = "appdb";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Activity> GetActivities()
        {
            List<Activity> activities = new List<Activity>();
            string query = "SELECT Id, OperationName, Status, EventCategory, ResourceType, Resource FROM logdata";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        activities.Add(new Activity()
                        {
                            Id = reader.GetInt32(0),
                            OperationName = reader.GetString(1),
                            Status = reader.GetString(2),
                            EventCategory = reader.GetString(3),
                            ResourceType = reader.GetString(4),
                            Resource = reader.GetString(5),
                        });
                    }
                }
            }

            return activities;
        }
    }
}
