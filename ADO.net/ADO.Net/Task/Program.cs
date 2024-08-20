using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics.Metrics;

namespace Task
{
    public class Program
    {

        //ADO.Net
        static void InsertUser(User user)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();

            var connection = new SqlConnection(configuration.GetSection("constr").Value);

            var sql = "INSERT INTO Users (UserID, Username, Email, PasswordHash, Status, AddressLine1, AddressLine2, City, State, PostalCode, CountryID, CreatedAt) " +
                          "VALUES (@UserID, @Username, @Email, @PasswordHash, @Status, @AddressLine1, @AddressLine2, @City, @State, @PostalCode, @CountryID, @CreatedAt)";

            SqlCommand sqlCommand = new SqlCommand(sql, connection);

            sqlCommand.Parameters.AddWithValue("@UserID" , user.UserID);
            sqlCommand.Parameters.AddWithValue("@Username", user.UserName);
            sqlCommand.Parameters.AddWithValue("@Email", user.Email);
            sqlCommand.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            sqlCommand.Parameters.AddWithValue("@AddressLine1", user.AddressLine1);
            sqlCommand.Parameters.AddWithValue("@AddressLine2", user.AddressLine2);
            sqlCommand.Parameters.AddWithValue("@City", user.City);
            sqlCommand.Parameters.AddWithValue("@Status", user.Status);
            sqlCommand.Parameters.AddWithValue("@PostalCode", user.PasswordHash);
            sqlCommand.Parameters.AddWithValue("@CountryID", user.CountryID);
            sqlCommand.Parameters.AddWithValue("@State", user.State);
            sqlCommand.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);


            sqlCommand.CommandType = System.Data.CommandType.Text;

            connection.Open();

            try
            {
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"User {user.UserName} inserted successfully.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            connection.Close();

        }

        static void Main(string[] args)
        {
            //FileStream

            var configuration = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();

            var connection = new SqlConnection(configuration.GetSection("constr").Value);

            string path = "D:\\DEPI\\ADO.net\\users.csv";

            using (StreamReader reader = new StreamReader(path))
            {
                string headerLine = reader.ReadLine();

                string line;

                User user = new User();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] val = line.Split(',');

                    user.UserID = int.Parse(val[0]);
                    user.UserName = val[1];
                    user.Email = val[2];
                    user.PasswordHash = val[3];
                    user.Status = val[4];
                    user.AddressLine1 = val[5];
                    user.AddressLine2 = val[6];
                    user.City = val[7];
                    user.State = val[8];
                    user.PostalCode = val[9];
                    user.CountryID = int.Parse(val[10]);
                    user.CreatedAt = DateTime.Parse(val[11]);

                    InsertUser(user);
                }
            }
        }
    }
}

