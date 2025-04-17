using Coding_Challenges.Coding_Challenges;

namespace Coding_Challenges
{

    class Program
    {
        static void Main(string[] args)
        {
            IHospitalService hospitalService = new HospitalServiceImpl();
          
            IDoctorService doctorService = new DoctorServiceImpl();
            IPatientService patientService = new PatientServiceImpl();


            while (true)
            {
                Console.WriteLine("\nHospital Management System");
                Console.WriteLine("1. Get Appointment by ID");
                Console.WriteLine("2. Get Appointments for Patient");
                Console.WriteLine("3. Get Appointments for Doctor");
                Console.WriteLine("4. Schedule Appointment");
                Console.WriteLine("5. Update Appointment");
                Console.WriteLine("6. Cancel Appointment");
                Console.WriteLine("7. Add Doctor");
                Console.WriteLine("8. Add Patient");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Appointment ID: ");
                            if (int.TryParse(Console.ReadLine(), out int appointmentId))
                            {
                                var appointment = hospitalService.GetAppointmentById(appointmentId);
                                Console.WriteLine(appointment != null
                                    ? $"Appointment Details: {appointment}"
                                    : "Appointment not found.");
                            }
                            break;

                        case 2:
                            Console.Write("Enter Patient ID: ");
                            if (int.TryParse(Console.ReadLine(), out int patientId))
                            {
                                try
                                {
                                    var appointments = hospitalService.GetAppointmentsForPatient(patientId);
                                    Console.WriteLine("Patient's Appointments:");
                                    foreach (var apt in appointments)
                                    {
                                        Console.WriteLine(apt);
                                    }
                                }
                                catch (PatientNumberNotFoundException ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }
                            }
                            break;

                        case 3:
                            Console.Write("Enter Doctor ID: ");
                            if (int.TryParse(Console.ReadLine(), out int doctorId))
                            {
                                var appointments = hospitalService.GetAppointmentsForDoctor(doctorId);
                                Console.WriteLine("Doctor's Appointments:");
                                foreach (var apt in appointments)
                                {
                                    Console.WriteLine(apt);
                                }
                            }
                            break;

                        case 4:
                            Console.WriteLine("Enter Appointment Details:");
                            Console.Write("Patient ID: ");
                            int newPatientId = int.Parse(Console.ReadLine());
                            Console.Write("Doctor ID: ");
                            int newDoctorId = int.Parse(Console.ReadLine());
                            Console.Write("Description: ");
                            string description = Console.ReadLine();

                            var newAppointment = new Appointment(0, newPatientId, newDoctorId,
                                                               DateTime.Now, description);
                            bool scheduled = hospitalService.ScheduleAppointment(newAppointment);
                            Console.WriteLine(scheduled
                                ? "Appointment scheduled successfully!"
                                : "Failed to schedule appointment.");
                            break;

                        case 5:
                            Console.WriteLine("Enter Appointment Details to Update:");
                            Console.Write("Appointment ID: ");
                            int updateAppointmentId = int.Parse(Console.ReadLine());
                            Console.Write("Patient ID: ");
                            int updatePatientId = int.Parse(Console.ReadLine());
                            Console.Write("Doctor ID: ");
                            int updateDoctorId = int.Parse(Console.ReadLine());
                            Console.Write("Description: ");
                            string updateDescription = Console.ReadLine();

                            var updateAppointment = new Appointment(updateAppointmentId,
                                                                  updatePatientId, updateDoctorId,
                                                                  DateTime.Now, updateDescription);
                            bool updated = hospitalService.UpdateAppointment(updateAppointment);
                            Console.WriteLine(updated
                                ? "Appointment updated successfully!"
                                : "Failed to update appointment.");
                            break;

                        case 6:
                            Console.Write("Enter Appointment ID to cancel: ");
                            int cancelAppointmentId = int.Parse(Console.ReadLine());
                            bool canceled = hospitalService.CancelAppointment(cancelAppointmentId);
                            Console.WriteLine(canceled
                                ? "Appointment canceled successfully!"
                                : "Failed to cancel appointment.");
                            break;

                        case 7:
                            Console.WriteLine("Enter Doctor Details:");

                            Console.Write("Doctor First Name: ");
                            string doctorFirstName = Console.ReadLine();

                            Console.Write("Doctor Last Name: ");
                            string doctorLastName = Console.ReadLine();

                            Console.Write("Specialization: ");
                            string specialization = Console.ReadLine();

                            Console.Write("Contact Number: ");
                            string contactNumber = Console.ReadLine();

                            Doctor newDoctor = new Doctor(0, doctorFirstName, doctorLastName, specialization, contactNumber);
                            bool doctorAdded = doctorService.AddDoctor(newDoctor);
                            Console.WriteLine(doctorAdded
                                ? "Doctor added successfully!"
                                : "Failed to add doctor.");
                            break;

                        case 8:
                            Console.WriteLine("Enter Patient Details:");

                            Console.Write("Patient First Name: ");
                            string patientFirstName = Console.ReadLine();

                            Console.Write("Patient Last Name: ");
                            string patientLastName = Console.ReadLine();

                            Console.Write("Date of Birth (yyyy-mm-dd): ");
                            DateTime dateOfBirth;
                            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                            {
                                Console.WriteLine("Invalid date format. Please enter again.");
                            }

                            Console.Write("Gender (M/F): ");
                            string gender = Console.ReadLine();

                            Console.Write("Contact Number: ");
                            string contactNumber1 = Console.ReadLine();

                            Console.Write("Address: ");
                            string address = Console.ReadLine();

                            Patient newPatient = new Patient(0, patientFirstName, patientLastName, dateOfBirth, gender, contactNumber1, address);

                           
                            bool patientAdded = patientService.AddPatient(newPatient);
                            Console.WriteLine(patientAdded
                                ? "Patient added successfully!"
                                : "Failed to add patient.");
                            break ;
                    /*   case 9:
                            Console.WriteLine("Enter Appointment Details:");

                            Console.Write("Patient ID: ");
                            int patientId1 = int.Parse(Console.ReadLine());

                            Console.Write("Doctor ID: ");
                            int doctorId1 = int.Parse(Console.ReadLine());

                            Console.Write("Appointment Date (yyyy-mm-dd): ");
                            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Description: ");
                            string description1 = Console.ReadLine();
                            Appointment newAppointment1 = new Appointment(0, patientId1, doctorId1, appointmentDate, description1);
                            bool appointmentAdded = IAppointmentService.AddAppointment(newAppointment1);
                            Console.WriteLine(appointmentAdded ? "Appointment added successfully!" : "Failed to add appointment.");
                            break;*/

                        case 9:
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}