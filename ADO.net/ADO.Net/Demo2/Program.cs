using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Demo
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();

            // read from user
            var coun = new Country
            {
                Id = 6,
                Name = "Oman"
            };
            var conn = new SqlConnection(configuration.GetSection("constr").Value);

            //var sql = "SELECT * from Countries";
            // string concation => sql injection

            //var sql = "Insert into Countries Values "+ $"(@Id,@Name)" ;

            var sql = "Update Countries set CountryName = @Name where CountryID = 6";

            SqlParameter nameparameter = new SqlParameter
            {
                ParameterName = "@Name",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = "Palastine"
            };

            SqlCommand sqlCommand = new SqlCommand(sql, conn);

            sqlCommand.Parameters.Add(nameparameter);

            sqlCommand.CommandType = System.Data.CommandType.Text;

            conn.Open();

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Country table Updated successfully");
            }
            else
            {
                Console.WriteLine("Not added");
            }
            conn.Close();
        }
    }
}
