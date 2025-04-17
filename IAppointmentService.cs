using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenges
{
    public interface IAppointmentService
    {
        bool AddAppointment(Appointment appointment);
    }
}