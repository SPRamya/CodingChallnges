using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenges
{

    public static class DBPropertyUtil
    { 
            static readonly string connectionString = @"Server=LAPTOP-T9L5C12T; Database = HospitalDB ; Integrated Security=True ; MultipleActiveResultSets=true;";

        //Method opens connection
        public static SqlConnection GetConnection()
        {

            SqlConnection connectionObject = new SqlConnection(connectionString);

            try
            {
                connectionObject.Open();
                return connectionObject;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Opening the Connection : {e.Message}");
                return null;
            }

        }


        }
    }
