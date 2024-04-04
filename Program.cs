using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace HospitalAppointment
{
    public class Program
    {
        static List<Appointment> appointments = new List<Appointment>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Appointment Booking System");

            while(true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Book an Appointment");
                Console.WriteLine("2. Show All Booked Appointment Details");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        BookAppointment();
                        break;
                    case 2:
                        ShowAllAppointment();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        private static void BookAppointment()
        {
            Console.WriteLine("\nBook an Appointment");

            //  Accept user input for Hospital Name
            Console.Write("Enter Hospital Name: ");
            string hospitalName = Console.ReadLine().ToLower().Replace(" ", "");

            if (IsHospitalNamePresent(hospitalName, "D:\\Avhad Rushikesh\\Hospital.csv"))
            {
                Console.WriteLine("Hospital Found!");
            }
            else
            {
                Console.WriteLine("Hospital Not Found.");
            }

            Console.Write("Enter Doctor Name: ");
            string doctorName = Console.ReadLine().ToLower().Replace(" ", "");

            if (IsDoctorNamePresent(doctorName, "D:\\Avhad Rushikesh\\Doctor.csv"))
            {
                Console.WriteLine("Doctor Found!");
            }
            else
            {
                Console.WriteLine("Doctor Not Found.");
            }

            Console.Write("Enter Appointment Date (YYYY-MM-DD): ");
            string appointmentDateStr = Console.ReadLine();

            DateTime appointmentDate;
            if (!DateTime.TryParse(appointmentDateStr, out appointmentDate))
            {
                Console.WriteLine("Invalid date format. Please enter in YYYY-MM-DD format.");
                return;
            }
            else
            {
                string dayName = appointmentDate.DayOfWeek.ToString();
                if (dayName.ToLower() == "saturday" || dayName.ToLower() == "sunday")
                {
                    Console.WriteLine("Appointment Cannot be book on Saturday or Sunday");
                    return;
                }
            }

            if (IsDoctorAlreadyBookedOnDate(doctorName, appointmentDate))
            {
                Console.WriteLine("Doctor already has an appointment. Cannot make another appointment.");
                return;
            }

            //  Create an appointment object and store it in the list
            Appointment newAppointment = new Appointment(hospitalName, doctorName, appointmentDate);
            appointments.Add(newAppointment);

            Console.WriteLine("Appointment booked Successfully!");

            Console.WriteLine("\nAppointment Details:");
            Console.WriteLine("Hospital Name: " + newAppointment.HospitalName);
            Console.WriteLine("Doctor Name: " + newAppointment.DoctorName);
            Console.WriteLine("Appointment Date: " +newAppointment.AppointmentDate.ToString("yyyy-MM-dd"));

        }

        private static bool IsDoctorAlreadyBookedOnDate(string doctorName, DateTime appointmentDate)
        {
            foreach (var appointment in appointments)
            {
                if (appointment.DoctorName == doctorName && appointment.AppointmentDate == appointmentDate)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsDoctorNamePresent(string doctorName, string csvFilePath)
        {
            if (File.Exists(csvFilePath))
            {
                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        string csvName = fields[1].ToLower().Replace(" ", "");

                        if(csvName == doctorName)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static bool IsHospitalNamePresent(string hospitalName, string csvFilePath)
        {
            if (File.Exists(csvFilePath))
            {
                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        string csvName = fields[1].ToLower().Replace(" ", "");

                        if (csvName == hospitalName)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static void ShowAllAppointment()
        {
            Console.WriteLine("\nAll Booked Appointments Details:");

            if (appointments.Count == 0)
            {
                Console.WriteLine("No Appointment Booked Yet.");
                return;
            }

            //  print table header
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Hospital Name", "Doctor Name", "Appointment Date");

            //  print table seperator
            Console.WriteLine(new string('-', 62));

            //  print appointment details
            foreach (Appointment appointment in appointments)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", appointment.HospitalName, appointment.DoctorName, appointment.AppointmentDate);
            }
        }
    }
}
