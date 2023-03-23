using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HalfSemsterDiver
{
    public class Diving
    {
        private int id;
        private Club club;
        private DateTime date;
        private DateTime startTime;
        private DateTime endTime;
        private double waterTemp;
        private string waterStatus;
        private DivingSite site;
        private Instructor instructor;
        private Diver[] divers;
        private Gear[] gears;



        public Diving(int id,Club club,Instructor instructor, Diver[] divers)
        {

            this.id = id;
            this.club = club;
            this.instructor = instructor;
            this.divers = divers;
            this.gears = new Gear[0];

            SetSite(club);
            SetWaterStatus();
            SetWaterTemp();
            
        }


        public void SetGears()
        {
            string[] toolsGear = { "KNIFE", "COMPASS" , "MILKSHAKE", "HOOK", "FLAIR", "GAS_MASK", "OXYIGEN_BOTTLE", "DIVE_SUIT", "CAMERA" };
            Console.WriteLine(@"Select index from the following list: ");
            for(int j = 0;j< toolsGear.Length;j++)
            {
                Console.WriteLine($"{j}){toolsGear[j]}");
            }

            int choice = int.Parse(Console.ReadLine());
            string nameGear = toolsGear[choice];
            Console.WriteLine("Enter amount(1-20)");
            int amount = int.Parse(Console.ReadLine());
            Console.WriteLine("Write some note");
            string note = Console.ReadLine();

            Console.WriteLine($"Type: {nameGear} Amount: {amount}  Comment: {note}");

            Gear g1 = new Gear(nameGear,amount,note);

            Gear[] newGears = new Gear[this.gears.Length+1];
            int i = 0;
            if (this.gears.Length > 0)
            {
                for (; i < newGears.Length - 1; i++)
                {
                    newGears[i] = this.gears[i];
                }
            }
            

            newGears[i] = g1;
            
            this.gears = newGears;
        }


        public void PrintGears()
        {
            Console.WriteLine("Gear You Own:");
            for(int i=0;i<gears.Length;i++)
            {
                Console.WriteLine(gears[i].ToString());
            }
        }



        public void SetWaterTemp()
        {
            Console.WriteLine("Enter Temperture:");
            int temp = int.Parse(Console.ReadLine());

            this.waterTemp = temp;
        }

        public void SetWaterStatus()
        {
            Console.WriteLine("Enter Tide : 0 = low, 1=high");
            int choice = int.Parse(Console.ReadLine());
            while(choice<0 || choice > 1)
            {
                Console.WriteLine("You entered invalied num. enter again");
                choice = int.Parse(Console.ReadLine());
            }


            if(choice == 0)
            {
                this.waterStatus = "low";
            }
            else
            {
                this.waterStatus = "high";
            }

            
        }



        public void SetSite(Club club)
        {
            int choice;
            switch(club.NameClub)
            {
                case "EilatDiving":
                    Console.WriteLine("Enter dive site INDEX :");
                    Console.WriteLine(@"
0)Dolphin Reef
1)Coral Reserve Beach");
                    choice = int.Parse(Console.ReadLine());
                    if(choice == 0)
                    {
                        site = new DivingSite("Dolphin Reef",club.CityClub ,club.CountryClub, "There are Dolphins", 74.25, "roaring");
                    }
                    else
                    {
                        site = new DivingSite("Coral Reserve Beach", club.CityClub, club.CountryClub, "There are corals", 56.3, "roaring");
                    }
                    break;
                case "AcreDiveClub":
                    Console.WriteLine("Enter dive site INDEX :");
                    Console.WriteLine(@"0)Nitzan Ship Wreck
1) ido the ship of the world");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 0)
                    {
                        site = new DivingSite("Nitzan Ship Wreck", club.CityClub, club.CountryClub, "There are Nitzns", 106.8, "silent");
                    }
                    else
                    {
                        site = new DivingSite("ido the ship of the world", club.CityClub, club.CountryClub, "There are ido at the sea", 56.3, "very noisy");
                    }
                    break;
                case "cozumelDiving":
                    Console.WriteLine("Enter dive site INDEX :");
                    Console.WriteLine(@"0)Coscos on Mex
1)BlaBlue todo boom");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 0)
                    {
                        site = new DivingSite("Coscos on Mex", club.CityClub, club.CountryClub, "There are coscos", 258, "deeping");
                    }
                    else
                    {
                        site = new DivingSite("BlaBlue todo boom", club.CityClub, club.CountryClub, "There blue water", 56.3, "silent");
                    }
                    break;
                case "sharmDiving":
                    Console.WriteLine("Enter dive site INDEX :");
                    Console.WriteLine("0)Yala balgan");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 0)
                    {
                        site = new DivingSite("Yala balgan", club.CityClub, club.CountryClub, "There are balgan", 251.6, "deeping");
                    }
                    break;
                case "padiDiving":
                    Console.WriteLine("Enter dive site INDEX :");
                    Console.WriteLine("0)olfson and kochman");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 0)
                    {
                        site = new DivingSite("olfson and kochman", club.CityClub, club.CountryClub, "There are kochman", 79.4, "deeping");
                    }
                    break;


            }
        }


        public void SetDateAndStartTimeAndFinishTime()
        {
            Console.WriteLine("Enter Dive Date:");
            Console.WriteLine("YYYY: ");
            string yyyy = Console.ReadLine();
            Regex checkYear = new Regex(@"^(19[2-9]\d|20[0-2]\d)$"); // נכון לכרגע עד 2029
            bool isOkay = checkYear.IsMatch(yyyy);
            while (!isOkay)
            {
                Console.WriteLine("Entered invalied year. enter again");
                yyyy = Console.ReadLine();
                isOkay = checkYear.IsMatch(yyyy);
            }

            Console.WriteLine("MM: ");
            string mm = Console.ReadLine();
            Regex checkMonth = new Regex(@"^(0[1-9]|1[0-2])$");
            isOkay = checkMonth.IsMatch(mm);
            while (!isOkay)
            {
                Console.WriteLine("Entered invalied month.enter again");
                mm = Console.ReadLine();
                isOkay = checkMonth.IsMatch(mm);
            }

            Console.WriteLine("DD: ");
            string dd = Console.ReadLine();
            Regex checkDay = new Regex(@"^(0[1-9]|[12][0-9]|3[01])$");
            isOkay = checkDay.IsMatch(dd);
            while (!isOkay)
            {
                Console.WriteLine("Entered invalied day. enter again");
                dd = Console.ReadLine();
                isOkay = checkDay.IsMatch(dd);
            }



            Console.WriteLine("Enter start time:");
            Console.WriteLine("Enter hour:");
            string startTimeHour = Console.ReadLine();
            Regex checkStartTimeHour = new Regex(@"^(2[0-3]|[01]?[0-9])$");
            isOkay= checkStartTimeHour.IsMatch(startTimeHour);
            while (!isOkay)
            {
                Console.WriteLine("You enterd invalied hour.enter again");
                startTimeHour = Console.ReadLine();
                isOkay= checkStartTimeHour.IsMatch(startTimeHour);
            }



            Console.WriteLine("Enter Minutes:");
            string startTimeMinutes = Console.ReadLine();
            Regex checkStartTimeMinutes = new Regex(@"^([0-5]?[0-9])$");
            isOkay = checkStartTimeMinutes.IsMatch(startTimeMinutes);
            while (!isOkay)
            {
                Console.WriteLine("You enterd invalied minutes.enter again");
                startTimeMinutes= Console.ReadLine();
                isOkay = checkStartTimeMinutes.IsMatch(startTimeMinutes);
            }

            this.date = new DateTime(int.Parse(yyyy), int.Parse(mm), int.Parse(dd));
            this.startTime = new DateTime(int.Parse(yyyy), int.Parse(mm), int.Parse(dd), int.Parse(startTimeHour), int.Parse(startTimeMinutes), 0);
            Console.WriteLine(this.startTime.ToString());


            Console.WriteLine("Enter End Time:");
            Console.WriteLine("Enter Hours:");
            startTimeHour = Console.ReadLine();
            checkStartTimeHour = new Regex(@"^(2[0-3]|[01]?[0-9])$");
            isOkay = checkStartTimeHour.IsMatch(startTimeHour);
            while (!isOkay)
            {
                Console.WriteLine("You enterd invalied hour.enter again");
                startTimeHour = Console.ReadLine();
                isOkay = checkStartTimeHour.IsMatch(startTimeHour);
            }
            Console.WriteLine("Enter Minutes:");
            startTimeMinutes = Console.ReadLine();
            checkStartTimeMinutes = new Regex(@"^([0-5]?[0-9])$");
            isOkay = checkStartTimeMinutes.IsMatch(startTimeMinutes);
            while (!isOkay)
            {
                Console.WriteLine("You enterd invalied minutes.enter again");
                startTimeMinutes = Console.ReadLine();
                isOkay = checkStartTimeMinutes.IsMatch(startTimeMinutes);
            }



            this.endTime = new DateTime(int.Parse(yyyy), int.Parse(mm), int.Parse(dd), int.Parse(startTimeHour), int.Parse(startTimeMinutes), 0);
            Console.WriteLine(this.endTime.ToString());



        }


        public override string ToString()
        {
            string printDive = "Dive Details:\n ";
            printDive += $"Dived Throgh: {club.NameClub} at the '{site.NameDivingSite}'\n";
            printDive += $"Date from {startTime.ToString()} to {endTime.ToString()}\n";
            printDive += $"The Tide was: {waterStatus}.\n";
            printDive += $"Water Temperature: {waterTemp} \n";
            printDive += $"The Dive was Confirmed By: {instructor.FirstName} ID: {instructor.Id}";
            return printDive;
        }
    }
}
