using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONet
{
    class Program
    {
        private object sqlDbType;

        static void Main(string[] args)
        {
            new Program().InsertUserDetail();
            new Program().InsertTrain();
            new Program().getFirstUserdtail();
            new Program().UpdateUSerDetail();


        }

        public void InsertUserDetail()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string Query = "Insert into UserDetail values('Karan','Male',1000)";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlConnection.Open();
            int rowaffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void InsertTrain()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string Query = "InsertTrain";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@TrainNo", SqlDbType.Int).Value = 1007;
            sqlCommand.Parameters.Add("@TrainName", SqlDbType.VarChar).Value = "Ahmedabad";
            sqlCommand.Parameters.Add("@SourceId", SqlDbType.Int).Value = 507;
            sqlCommand.Parameters.Add("@DestinationId", SqlDbType.Int).Value = 508;
            sqlCommand.Parameters.Add("@NoOfSeat", SqlDbType.Int).Value = 800;

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void getFirstUserdtail()
        {
            SqlConnection sqlConnetion = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string RetriveQuery = "select top 1 UserName from UserDetail";
            SqlCommand sqlCommand = new SqlCommand(RetriveQuery, sqlConnetion);
            sqlCommand = new SqlCommand(RetriveQuery, sqlConnetion);
            sqlConnetion.Open();
            string UserName = Convert.ToString(sqlCommand.ExecuteScalar());
            sqlConnetion.Close();
            Console.WriteLine(UserName);
            Console.ReadKey();

        }
        public void UpdateUSerDetail()
        {
            SqlConnection sqlConnetion = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string Query = "update UserDetail set UserName='shree' where UserId=7";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnetion);
            sqlConnetion.Open();
            Convert.ToString(sqlCommand.ExecuteNonQuery());
            sqlConnetion.Close();
        }
    }
}
