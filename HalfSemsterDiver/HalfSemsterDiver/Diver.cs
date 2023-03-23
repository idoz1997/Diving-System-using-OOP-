using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Text.RegularExpressions;

namespace HalfSemsterDiver
{
    public class Diver
    {
        protected int id;
        protected string firstName;
        protected string lastName;
        DateTime date;
        protected string email;
        protected string password;
        protected int[] rank;
        protected Club[] clubsToEnter;
        protected Club clubHeGo;
        Diving diveHeDid;
        Country[] countryRegs;
        
            
        public Diver(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.diveHeDid = null;

            SetArrayClubsToEnter();

            SetRegulationForCountry();         

        }

        public Diver(string firstName,string lastName,string password,int id)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.diveHeDid = null;
            this.id = id;
            SetArrayClubsToEnter();

            SetRegulationForCountry();
        }

        public Diver()
        {
            this.firstName=null;
            this.lastName=null;
            this.diveHeDid=null;
            SetArrayClubsToEnter();

            SetRegulationForCountry();
        }


        public Club GetClubHeGo()
        {
            if (clubHeGo == null)
            {
                return null;
            }
            return this.clubHeGo;
        }


        public void SetClubHeGo()
        {
            this.clubHeGo = null;
        }





        public void SetArrayClubsToEnter()
        {
            clubsToEnter = new Club[5];
            clubsToEnter[0] = new Club(1, "EilatDiving", "loki", "Eilat", "hashmonem 40", "0549954321", "loki@gmail.com", "www.eilatDiving.co.il", "Israel");
            clubsToEnter[1] = new Club(2, "AcreDiveClub", "loki", "Hadera", "dolphin3", "0549954321", "loki@gmail.com", "www.eilatDiving.co.il", "Israel");
            clubsToEnter[2] = new Club(3, "cozumelDiving", "joly", "mexicoCity", "cozumel 25", "0549954254", "joly@gmail.com", "www.cozumelDiving.co.il", "Mexico");
            clubsToEnter[3] = new Club(4, "sharmDiving", "buffon", "Rome", "sharm 14", "0549954867", "buffon@gmail.com", "www.sharmDiving.co.il", "Italy");
            clubsToEnter[4] = new Club(5, "padiDiving", "shmoel", "athens", "padi 19", "0549954852", "shmoel@gmail.com", "www.padiDiving.co.il", "Greece");
        }



        public void SetRegulationForCountry()
        {
            string regIsrael = @"
In order to dive as a certified diver you must:
1.be 12 years old and above
2.Own Personal diving certification
3.have a Diving insurance
4.dived in the last six months";
            string regMexico = @"
In order to dive as a certified diver you must:
1.be 8 years old and above
2.Own Personal diving certification
3.have a Diving insurance with 1 year experience
4.dived in the last seven months";
            string regItaly = @"
In order to dive as a certified diver you must:
1.be 16 years old and above
2.Own Personal diving certification
3.have a Diving insurance
4.dived in the last four months";
            string regGreece = @"
In order to dive as a certified diver you must:
1.be 10 years old and above
2.Own Personal diving certification
3.have a Diving insurance
4.dived in the last three months";

            clubsToEnter[0].SetRegulationToCountry(regIsrael);
            clubsToEnter[1].SetRegulationToCountry(regIsrael);
            clubsToEnter[2].SetRegulationToCountry(regMexico);
            clubsToEnter[3].SetRegulationToCountry(regItaly);
            clubsToEnter[4].SetRegulationToCountry(regGreece);
        }


        public void PrintRegulationByCountry(string country)
        {
            bool countryExsits = false;
            for(int i=0;i<clubsToEnter.Length;i++)
            {
                if (clubsToEnter[i].GetCountryName() == country.ToLower())
                {
                    Console.WriteLine(clubsToEnter[i].GetRegulationByCountry(country));
                    countryExsits = true;
                    break;
                }
            }

            if(countryExsits == false)
            {
                Console.WriteLine("Country not exsits");
            }
        }



        public void SetDivingToAnotherUser(Diving dive)
        {
            this.diveHeDid= dive;
        }



        public void SetDiving(Instructor shayManger)
        {
            Diving newDiving = new Diving(this.id, this.clubHeGo, shayManger, shayManger.GetDivers());
            this.diveHeDid = newDiving;
        }

        public Diving GetDiving()
        {
            return this.diveHeDid;
        }




        public void enteringClub(string clubName)
        {
            string newClubName = clubName.ToLower();
            while(newClubName == "" || newClubName == null)
            {
                Console.WriteLine("Didnt enter Value or invalied value");
                newClubName = Console.ReadLine();
            }

            bool checkIfCountryExsits = false;
            while (true && (clubName!="list" || newClubName != "list"))
            {
                for(int i=0;i<clubsToEnter.Length;i++)
                {
                    if (clubsToEnter[i].GetCountryName() == newClubName)
                    {
                        checkIfCountryExsits = true;
                        break;
                    }
                }

                if(checkIfCountryExsits == true)
                {
                    break;
                }

                Console.WriteLine("You entered a country doesn't exsits , Enter Again");
                newClubName = Console.ReadLine().ToLower();            
            }

            if(clubName == "list")
            {
                for(int i=0;i<clubsToEnter.Length;i++)
                {
                    Console.WriteLine($"{i + 1}){clubsToEnter[i].NameClub}\t {clubsToEnter[i].GetCountryName()}");
                }

                Console.WriteLine("Enter your choice: ");
                int choose = int.Parse(Console.ReadLine());
                while(choose<1 || choose > 5)
                {
                    Console.WriteLine("Enter again you choice");
                    choose = int.Parse(Console.ReadLine()); 
                }


                Console.WriteLine($"You choose {clubsToEnter[choose-1].NameClub}");

                clubHeGo = clubsToEnter[choose-1];
            }

            int counter =0;

            for(int i=0; i < clubsToEnter.Length; i++)
            {
                // clubName - כאשר מדברים על מדינה 
                if (clubsToEnter[i].GetCountryName() == clubName || clubsToEnter[i].GetCountryName() == newClubName)
                {
                    counter++;
                    Console.WriteLine($"{i+1})  {clubsToEnter[i].NameClub}  country:{clubsToEnter[i].GetCountryName()}");
                }
            }

            if(counter != 0)
            {
                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                Console.WriteLine($"You choose {clubsToEnter[choice - 1].NameClub}");
                clubHeGo = clubsToEnter[choice - 1];
            }


            

        }



        public bool Login(int id,string password)
        {
            if(this.id == id && this.password == password)
            {
                return true;
            }

            return false;
        }



        public void Register(string firstName,string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;

            Console.WriteLine("Enter Id (6 digit or more)");
            int idUser = int.Parse(Console.ReadLine());
            Regex checkId = new Regex(@"^\d{6,}$");
            bool isOkay = checkId.IsMatch(idUser.ToString());
            while(!isOkay) 
            {
                Console.WriteLine("Entered invalied id. please enter again (6 digit or more)");
                idUser = int.Parse(Console.ReadLine());
                isOkay = checkId.IsMatch(firstName);
            }

            Console.WriteLine("Enter Birth Date:");
            Console.WriteLine("YYYY: ");
            string yyyy = Console.ReadLine();
            Regex checkYear = new Regex(@"^(19[2-9]\d|20[0-2]\d)$"); // נכון לכרגע עד 2029
            isOkay = checkYear.IsMatch(yyyy);
            while(!isOkay)
            {
                Console.WriteLine("Entered invalied year. enter again");
                yyyy = Console.ReadLine();
                isOkay= checkYear.IsMatch(yyyy);
            }

            Console.WriteLine("MM: ");
            string mm = Console.ReadLine();
            Regex checkMonth = new Regex(@"^(0[1-9]|1[0-2])$");
            isOkay= checkMonth.IsMatch(mm);
            while(!isOkay)
            {
                Console.WriteLine("Entered invalied month.enter again");
                mm= Console.ReadLine();
                isOkay= checkMonth.IsMatch(mm);
            }

            Console.WriteLine("DD: ");
            string dd = Console.ReadLine();
            Regex checkDay = new Regex(@"^(0[1-9]|[12][0-9]|3[01])$");
            isOkay= checkDay.IsMatch(dd);
            while (!isOkay)
            {
                Console.WriteLine("Entered invalied day. enter again");
                dd= Console.ReadLine();
                isOkay= checkDay.IsMatch(dd);
            }

            Console.WriteLine("Choose a password (8 digits or more)");
            string pass = Console.ReadLine();
            Regex checkPass = new Regex(@"^\d{8,}$");
            isOkay= checkPass.IsMatch(pass);
            while (!isOkay)
            {
                Console.WriteLine("Entered invalied password. enter again (8 digits or more)");
                pass= Console.ReadLine();
                isOkay= checkPass.IsMatch(pass);
            }

            Console.WriteLine("Enter email: ");
            string emailUser = Console.ReadLine();
            Regex checkEmail = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            isOkay= checkEmail.IsMatch(emailUser);
            while (!isOkay)
            {
                Console.WriteLine("Entered invalied email. enter again");
                emailUser= Console.ReadLine();
                isOkay= checkEmail.IsMatch(emailUser);
            }


            // הכנסת נתונים
            
            this.id = idUser;
            this.date = new DateTime(int.Parse(yyyy), int.Parse(mm), int.Parse(dd));
            this.password = pass;
            this.email = emailUser;
        }


        



        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }


        public string LastName
        {
            get { return lastName; }
            set { lastName = value;}
        }


        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }


        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }
    }
}
