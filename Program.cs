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

            if (IsHospitalNamePresent(hospitalName, "D:\\AvhadRushikesh\\Hospital.csv"))
            {
                Console.WriteLine("Hospital Found!");
            }
            else
            {
                Console.WriteLine("Hospital Not Found.");
            }

            Console.WriteLine("Enter Doctor Name: ");
            string doctorName = Console.ReadLine().ToLower().Replace(" ", "");

            if (IsDoctorNamePresent(doctorName, "D:\\AvhadRushikesh\\Doctor.csv"))
            {
                Console.WriteLine("Doctor Found!");
            }
            else
            {
                Console.WriteLine("Doctor Not Found.");
            }
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
            throw new NotImplementedException();
        }
    }
}
