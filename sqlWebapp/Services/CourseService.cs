using sqlWebapp.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace sqlWebapp.Services
{
    public class CourseService
    {
        // Ensure to change the below variables to reflect the connection details for your database
        /*private static string db_source = "anushkadbserver.database.windows.net";
        private static string db_user = "demouser";
        private static string db_password = "AnushkaPrakash6";
        private static string db_database = "AnushkaDB";*/

        private SqlConnection GetConnection(string connectionString)
        {
            // Here we are creating the SQL connection
            /*var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
           _builder.InitialCatalog = db_database;*/
            //return new SqlConnection(_builder.ConnectionString);
            return new SqlConnection(connectionString);
        }

        public IEnumerable<Person> GetCourses(string connectionString)
        {
            List<Person> _lst = new List<Person>();
            string _statement = "SELECT PersonID,LastName,city from Persons";
            SqlConnection _connection = GetConnection(connectionString);
            // Let's open the connection
            _connection.Open();
            // We then construct the statement of getting the data from the Course table
            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);
            // Using the SqlDataReader class , we will read all the data from the Course table
            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Person _course = new Person()
                    {
                        PersonID = _reader.GetInt32(0),
                        LastName = _reader.GetString(1),
                        City = _reader.GetString(2)
                    };

                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }

    }
}
