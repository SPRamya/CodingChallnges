using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Coding_Challenges.DBPropertyUtil;

namespace Coding_Challenges
{

    public class HospitalServiceImpl : IHospitalService
    {
        private readonly string connectionString;

        

        public Appointment GetAppointmentById(int appointmentId)
        {
            using (SqlConnection connection = DBPropertyUtil.GetConnection())
            {
                string query = "SELECT * FROM Appointments WHERE AppointmentId = @AppointmentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Appointment(
                                (int)reader["AppointmentId"],
                                (int)reader["PatientId"],
                                (int)reader["DoctorId"],
                                (DateTime)reader["AppointmentDate"],
                                reader["Description"].ToString()
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return null;
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection connection = DBPropertyUtil.GetConnection())
            {
                string query = "SELECT * FROM Appointments WHERE PatientId = @PatientId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PatientId", patientId);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            throw new PatientNumberNotFoundException($"Patient with ID {patientId} not found.");
                        }

                        while (reader.Read())
                        {
                            appointments.Add(new Appointment(
                                (int)reader["AppointmentId"],
                                (int)reader["PatientId"],
                                (int)reader["DoctorId"],
                                (DateTime)reader["AppointmentDate"],
                                reader["Description"].ToString()
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return appointments;
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection connection = DBPropertyUtil.GetConnection())
            {
                string query = "SELECT * FROM Appointments WHERE DoctorId = @DoctorId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DoctorId", doctorId);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment(
                                (int)reader["AppointmentId"],
                                (int)reader["PatientId"],
                                (int)reader["DoctorId"],
                                (DateTime)reader["AppointmentDate"],
                                reader["Description"].ToString()
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return appointments;
        }

        public bool ScheduleAppointment(Appointment appointment)
        {
            using (SqlConnection connection = DBPropertyUtil.GetConnection())
            {
                string query = @"INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Description) 
                               VALUES (@PatientId, @DoctorId, @AppointmentDate, @Description)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                command.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                command.Parameters.AddWithValue("@Description", appointment.Description);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            using (SqlConnection connection = DBPropertyUtil.GetConnection())
            {
                string query = @"UPDATE Appointments 
                               SET PatientId = @PatientId, DoctorId = @DoctorId, 
                                   AppointmentDate = @AppointmentDate, Description = @Description 
                               WHERE AppointmentId = @AppointmentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                command.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                command.Parameters.AddWithValue("@Description", appointment.Description);
                command.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }

        public bool CancelAppointment(int appointmentId)
        {
            using (SqlConnection connection = DBPropertyUtil.GetConnection())
            {
                string query = "DELETE FROM Appointments WHERE AppointmentId = @AppointmentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }
    }
}