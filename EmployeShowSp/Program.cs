using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EmployeShowSp
{
    class Program
    {
        //Same here First Create  prcemployShow object in SQL SERVER
        /*
        Create Proc prcemployShow
        AS
        Begin
       Select* from employe;
       END
        */

        static void Main(string[] args)
        {
            string strCon = ConfigurationManager.ConnectionStrings["SqpPracticeConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();

            //here we use prcemployShow object to get data from SQl Server
            SqlCommand cmd = new SqlCommand("prcemployShow",conn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                
                Console.WriteLine("Employe ID : "+dr["emp_ID"]);
                Console.WriteLine("Employe Name : " + dr["emp_Name"]);
                Console.WriteLine("Employe Age : " + dr["emp_Age"]);
                Console.WriteLine("Employe Country : " + dr["emp_Nationality"]);
                Console.WriteLine("Employe Gender : " + dr["emp_Gender"]);
                Console.WriteLine("Employe Salary : " + dr["emp_Salary"]);

                Console.WriteLine("\n**************************\n");
            }
        }
    }
}
