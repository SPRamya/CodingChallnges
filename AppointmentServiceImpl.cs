using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenges

    {
        public class AppointmentServiceImpl : IAppointmentService
        {
            public bool AddAppointment(Appointment appointment)
            {
                using (System.Data.SqlClient.SqlConnection conn = DBPropertyUtil.GetConnection())
                {
                    string query = "INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Description) " +
                                   "VALUES (@patientId, @doctorId, @appointmentDate, @description)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                    cmd.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@description", appointment.Description);

                    return cmd.ExecuteNonQuery()>0;
                }
            }
        }
    }
