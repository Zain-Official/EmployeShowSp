using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace EmployeShowSp
{
    class Search_Method
    {
        //First Create prcEmpSearch in Sql Server
/*
        Create Proc prcEmpSearch
                     @empno int
       As
       Begin

       Select* from employe where emp_ID =@empno;
       END
       Go
*/

        static void Main(string[] args)
        {
            string sqlCon = ConfigurationManager.ConnectionStrings["SqpPracticeConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(sqlCon);
            conn.Open();
            Console.WriteLine("Enter Employe ID");
            int empno = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("prcEmpSearch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empno", empno);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
             
                Console.WriteLine("**********************");
                Console.WriteLine("Employe ID : " + dr["emp_ID"]);
                Console.WriteLine("Employe Name : " + dr["emp_Name"]);
                Console.WriteLine("Employe Age : " + dr["emp_Age"]);
                Console.WriteLine("Employe Country : " + dr["emp_Nationality"]);
                Console.WriteLine("Employe Gender : " + dr["emp_Gender"]);
                Console.WriteLine("Employe Salary : " + dr["emp_Salary"]);

                Console.WriteLine("*************************");
            }
            else
                Console.WriteLine("Record Not Found.....");


        }
    }
}