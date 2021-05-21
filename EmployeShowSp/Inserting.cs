using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace EmployeShowSp
{
    class Inserting
    {
        /*
         
Create Proc prcEmpInsertings
             @name Varchar,
			 @age int,
			 @country Varchar,
			 @gender Varchar,
			 @salary int
			 AS
			 Begin
Insert into employe(emp_Name,emp_Age,emp_Nationality,emp_Gender,emp_Salary)Values(@name,@age,@country,@gender,@salary)
END
GO
         */
        static void Main(string[] args)
        {
            string sqlCon = ConfigurationManager.ConnectionStrings["SqpPracticeConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(sqlCon);
            conn.Open();
            //Here id is autoincremented
          //  Console.WriteLine("Enter Employe ID");
        //    int empno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employe Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Employe Age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employe Country Name");
            string country = Console.ReadLine();

            Console.WriteLine("Enter Employe Gender");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter Employe Salary");
            int salary =Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("prcEmpInsertings", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Record Save Successfully......");

        }
    }
}
