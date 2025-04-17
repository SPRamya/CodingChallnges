using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coding_Challenges.Coding_Challenges;

namespace Coding_Challenges
{
    public class DoctorServiceImpl : IDoctorService
    {
        public bool AddDoctor(Doctor doctor)
        {
            using (SqlConnection conn = DBPropertyUtil.GetConnection())
            {
                string query = "INSERT INTO Doctors (FirstName, LastName, Specialization, ContactNumber) " +
                               "VALUES (@firstName, @lastName, @specialization, @contact)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@firstName", doctor.FirstName);
                cmd.Parameters.AddWithValue("@lastName", doctor.LastName);
                cmd.Parameters.AddWithValue("@specialization", doctor.Specialization);
                cmd.Parameters.AddWithValue("@contact", doctor.ContactNumber);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}