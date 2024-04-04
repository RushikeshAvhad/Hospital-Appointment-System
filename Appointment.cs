using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointment
{
    public class Appointment
    {
        public string HospitalName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Appointment(string hospitalName, string doctorName, DateTime appointmentDate)
        {
            HospitalName = hospitalName;
            DoctorName = doctorName;
            AppointmentDate = appointmentDate;
        }
    }
}
