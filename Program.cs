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

                Console.WriteLine("Enter your choice: ");

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

        private static void ShowAllAppointment()
        {
            throw new NotImplementedException();
        }

        private static void BookAppointment()
        {
            throw new NotImplementedException();
        }
    }
}
