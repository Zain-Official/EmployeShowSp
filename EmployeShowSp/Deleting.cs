using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace EmployeShowSp
{
    /*
     
Create Proc prcEmpDelete
             @empno int
As 
Begin

Delete from employe where emp_ID =@empno;
END
Go
     */
    class Deleting
    {
        static void Main(string[] args)
        {
            string sqlCon = ConfigurationManager.ConnectionStrings["SqpPracticeConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(sqlCon);
            conn.Open();
            Console.WriteLine("Enter Employe ID");
            int empno = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("prcEmpDelete", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empno", empno);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record Deleted Successfully......");
        }
    }
}
