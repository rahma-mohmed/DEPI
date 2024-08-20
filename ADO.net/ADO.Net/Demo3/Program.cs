using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Demo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();

            var conn = new SqlConnection(configuration.GetSection("constr").Value);

            //var sql = "SELECT * from Countries";
            // string concation => sql injection

            //var sql = "Insert into Countries Values "+ $"(@Id,@Name)" ;

            var sql = "Select * from Countries";

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            conn.Close();

            //Disconnected mode
            foreach (DataRow row in dt.Rows) {
                Console.WriteLine($"{row["CountryID"].ToString()} == {row[1].ToString()}");
            }
        }
    }
}
