﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenges
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }

        public Doctor() { }

        public Doctor(int doctorId, string firstName, string lastName,
                     string specialization, string contactNumber)
        {
            DoctorId = doctorId;
            FirstName = firstName;
            LastName = lastName;
            Specialization = specialization;
            ContactNumber = contactNumber;
        }

        public override string ToString()
        {
            return $"Doctor ID: {DoctorId}, Name: Dr. {FirstName} {LastName}, " +
                   $"Specialization: {Specialization}, Contact: {ContactNumber}";
        }
    }
}
