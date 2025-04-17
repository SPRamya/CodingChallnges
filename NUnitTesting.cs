using Coding_Challenges;
namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Doctor_Constructor_SetsPropertiesCorrectly()
        {

            int id = 1;
            string firstName = "John";
            string lastName = "Doe";
            string specialization = "Cardiologist";
            string contactNumber = "1234567890";

            Doctor doctor = new Doctor(id, firstName, lastName, specialization, contactNumber);


            Assert.AreEqual(id, doctor.DoctorId);
            Assert.AreEqual(firstName, doctor.FirstName);
            Assert.AreEqual(lastName, doctor.LastName);
            Assert.AreEqual(specialization, doctor.Specialization);
            Assert.AreEqual(contactNumber, doctor.ContactNumber);



        }
    }
   
    public class tests1
    {
    [Test]
        public void Patient_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            int id = 1;
            string firstName = "Alice";
            string lastName = "Smith";
            DateTime dob = new DateTime(1990, 5, 15);
            string gender = "Female";
            string contact = "9876543210";
            string address = "123 Main Street";

            // Act
            Patient patient = new Patient(id, firstName, lastName, dob, gender, contact, address);

            // Assert
            Assert.AreEqual(id, patient.PatientId);
            Assert.AreEqual(firstName, patient.FirstName);
            Assert.AreEqual(lastName, patient.LastName);

        }
    }
 
    public class tests2
    {
    [Test]
        public void Appointment_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            int appointmentId = 101;
            int patientId = 1;
            int doctorId = 5;
            DateTime date = new DateTime(2025, 4, 20, 14, 30, 0);
            string description = "Regular check-up";

            // Act
            Appointment appointment = new Appointment(appointmentId, patientId, doctorId, date, description);

            // Assert
            Assert.AreEqual(appointmentId, appointment.AppointmentId);
            Assert.AreEqual(patientId, appointment.PatientId);
            Assert.AreEqual(doctorId, appointment.DoctorId);
            Assert.AreEqual(date, appointment.AppointmentDate);
            Assert.AreEqual(description, appointment.Description);
        }

    }
}