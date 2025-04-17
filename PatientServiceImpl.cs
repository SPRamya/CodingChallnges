using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenges
{
   
        public class PatientServiceImpl : IPatientService
        {
            public bool AddPatient(Patient patient)
            {
                using (SqlConnection conn = DBPropertyUtil.GetConnection())
                {
                    string query = "INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, ContactNumber, Address) " +
                                   "VALUES (@firstName, @lastName, @dob, @gender, @contact, @address)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@firstName", patient.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", patient.LastName);
                    cmd.Parameters.AddWithValue("@dob", patient.DateOfBirth);
                    cmd.Parameters.AddWithValue("@gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@contact", patient.ContactNumber);
                    cmd.Parameters.AddWithValue("@address", patient.Address);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }

