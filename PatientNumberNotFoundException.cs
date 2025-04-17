using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenges
{
    public class PatientNumberNotFoundException : Exception
    {
        public PatientNumberNotFoundException() { }

        public PatientNumberNotFoundException(string message) : base(message) { }

        public PatientNumberNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
