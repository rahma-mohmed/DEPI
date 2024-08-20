using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Demo4_Transaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();

            var conn = new SqlConnection(configuration.GetSection("constr").Value);

            SqlCommand sqlCommand = conn.CreateCommand();

            sqlCommand.CommandType = System.Data.CommandType.Text;

            conn.Open();

            SqlTransaction sqlTransaction = conn.BeginTransaction();

            sqlCommand.Transaction = sqlTransaction;

            SqlParameter NameParameter = new SqlParameter
            {
                ParameterName = "@Name",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = "Chine"
            };

            sqlCommand.Parameters.Add(NameParameter);

            try
            {
                sqlCommand.CommandText = "delete from Countries where CountryID in (4 , 6)";
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "select * from Countries";
                sqlCommand.ExecuteNonQuery();

                sqlTransaction.Commit();

                Console.WriteLine("Transaction complited successfully");
            }
            catch
            {
                try
                {
                    sqlTransaction.Rollback();
                }
                catch
                {
                    Console.WriteLine("There are an error");
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
