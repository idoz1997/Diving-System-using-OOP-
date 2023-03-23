using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HalfSemsterDiver
{
    public class Program
    {
        static void Main(string[] args)
        {
            Diver[] diversUser = new Diver[2];
            diversUser[0] = new Diver("elad", "grossman","12345678",111111);
            diversUser[1] = new Diver("ido", "zalam","12345678",222222);
            int choice = -1; // משתנה לבחירה מתוך התפריט
            
            Diver loginDiver = new Diver();
            Instructor shayManger = new Instructor("shay", "Avrham","147258369",123456);


            
            







            while (choice != 0)
            {
                if (loginDiver.FirstName == null && loginDiver.GetClubHeGo() == null)
                {
                    Console.WriteLine(@"User: Null                         " + "\t Dive club: Null                         " + "\t Dive-Partners: " + 0);
                    Console.WriteLine("Welcome To proDiver 2.0");
                    Console.WriteLine("========================");
                    Console.WriteLine("Select:");
                    Console.WriteLine("1.Login");
                    Console.WriteLine("2.Register");
                    Console.WriteLine("0.Exit");

                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Password: ");
                            string password = Console.ReadLine();

                            for(int i = 0; i < diversUser.Length; i++)
                            {
                                if (diversUser[i].Login(id,password) == true)
                                {
                                    loginDiver = diversUser[i];
                                    Console.Clear();
                                    break;
                                }
                            }

                            if(loginDiver.FirstName == null)
                            {
                                Console.WriteLine("Inncorecct ID or Password. Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            
                            break;
                        case 2: // מוסיפים משתמש חדשים למערכת
                            Console.WriteLine("welcome,please fill the following:");
                            Console.Write("First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Last Name: ");
                            string lastName = Console.ReadLine();
                            Diver newDiverUser = new Diver(firstName, lastName);
                            newDiverUser.Register(firstName,lastName);
                            diversUser = UpdateDiversUsersArray(diversUser, newDiverUser); // פונקציה שנועדה לגרום למערך דינאמי של הכמות היוזרים
                            Console.WriteLine($"{newDiverUser.FirstName} was added Successfuly");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                    }


                }// כניסה למסך הבית כאשר עדיין לא התחברו עם יוזר/וניתן ליצור משתמש
                else if (loginDiver.FirstName != null && loginDiver.GetClubHeGo() == null && loginDiver.GetDiving() == null)
                {
                    int choiceLog = -1;
                    while(choiceLog!=5 && loginDiver.GetClubHeGo() == null)
                    {
                        Console.WriteLine(@"User: " + loginDiver.FirstName + "                         " + "\t Dive club: Null                          " + "\t Dive-Partners: " + shayManger.GetDivers().Length);
                        Console.WriteLine("========================");
                        Console.WriteLine("Welcome ,");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Choose: ");
                        Console.WriteLine("1)Add Dive");
                        Console.WriteLine("2)Enter DiveClub");
                        Console.WriteLine("3)Add Diving Partner/s");
                        Console.WriteLine("4)Display Diving regualtions By Country");
                        Console.WriteLine("5)Login menu");
                        choiceLog = int.Parse(Console.ReadLine());

                        switch (choiceLog)
                        {
                            case 1:
                                Console.WriteLine("Choose a dive club OR add more partners");
                                Console.WriteLine("Press Enter");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 2:
                                Console.WriteLine("Enter Dive club name OR enter country name(type 'list' to show all dive clubs)");
                                string clubName = Console.ReadLine();
                                loginDiver.enteringClub(clubName);
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 3:
                                Console.WriteLine("Enter partner ID OR Add new partner by typing 1");
                                int id = int.Parse(Console.ReadLine());
                                bool sameId = false;
                                if(id == loginDiver.Id)
                                {
                                    Console.WriteLine("you cant add yourself");
                                    Console.WriteLine("Press Enter");
                                    sameId = true;
                                    Console.ReadKey();
                                    Console.Clear();
                                }


                                if(sameId == false)
                                {
                                    shayManger.AddDivers(ref diversUser, id); // יש פה -התייחסות- משום שאם המשתמש רוצה להוסיף משתמש חדש אנחנו רוצים לעדכן את זה גם המערך של המשתמשים הקיים
                                    Console.WriteLine("Press Enter To continue");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                
                                break;
                            case 4:
                                Console.WriteLine("Enter country name");
                                string countryName = Console.ReadLine();
                                loginDiver.PrintRegulationByCountry(countryName);
                                Console.WriteLine();
                                Console.WriteLine("Press Enter");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 5:
                                shayManger.SetDivers();
                                loginDiver = new Diver();
                                Console.Clear();
                                break;

                        }
                    }
                    
                    
                }// כאשר עדיין לא צירף מועדון
                else if (loginDiver.FirstName != null && loginDiver.GetClubHeGo() != null && loginDiver.GetDiving()==null)
                {
                    int choiceLog = -1;
                    

                    while (choiceLog != 5 && loginDiver.GetDiving()==null && loginDiver.GetClubHeGo()!=null)
                    {
                        Console.WriteLine(@"User: " + loginDiver.FirstName + "                         " + "\t Dive club: " + loginDiver.GetClubHeGo().NameClub + "                         " + "\t Dive-Partners: " + shayManger.GetDivers().Length);
                        Console.WriteLine("========================");
                        Console.WriteLine("Welcome To proDiver 2.0");
                        Console.WriteLine("Welcome ,");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Choose: ");
                        Console.WriteLine("1)Add Dive");
                        Console.WriteLine("2)Enter DiveClub");
                        Console.WriteLine("3)Add Diving Partner/s");
                        Console.WriteLine("4)Display Diving regualtions By Country");
                        Console.WriteLine("5)Login menu");
                        choiceLog = int.Parse(Console.ReadLine());



                        switch (choiceLog)
                        {
                            case 1:
                                if(shayManger.GetDivers().Length == 0)
                                {
                                    Console.WriteLine("Choose a dive club OR add more partners");
                                    Console.WriteLine("Press Enter");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                                else if(shayManger.GetDivers().Length > 0)
                                {
                                    loginDiver.SetDiving(shayManger);
                                    Console.Clear();

                                    loginDiver.GetDiving().SetDateAndStartTimeAndFinishTime();
                                    Console.WriteLine("Press Enter to continue");
                                    Console.ReadKey();
                                    Console.Clear();
                                    
                                    Console.WriteLine("Press 1 To add  Gear or 0 to countine");
                                    int choiceGear = int.Parse(Console.ReadLine());
                                    while(choiceGear == 1)
                                    {
                                        loginDiver.GetDiving().SetGears();
                                        Console.ReadKey() ;
                                        Console.Clear();
                                        Console.WriteLine("Press 1 To add  Gear or 0 to countine");
                                        choiceGear = int.Parse(Console.ReadLine());
                                    }

                                    Console.Clear();

                                    Console.WriteLine(@"User: " + loginDiver.FirstName + "                         " + "\t Dive club: " + loginDiver.GetClubHeGo().NameClub + "                         " + "\t Dive-Partners: " + shayManger.GetDivers().Length);

                                    Console.WriteLine();

                                    Console.WriteLine(loginDiver.GetDiving().ToString());
                                    loginDiver.GetDiving().PrintGears();
                                    Console.WriteLine("Press Enter to Confirm OR any key to go back to main menu.");

                                    Console.ReadKey();
                                    Diver[] diverAdded = shayManger.GetDivers();
                                    for (int i=0;i< diversUser.Length; i++)
                                    {
                                        for(int j = 0; j < diverAdded.Length; j++)
                                        {
                                            if (diversUser[i].Id == diverAdded[j].Id)
                                            {
                                                diversUser[i].SetDivingToAnotherUser(loginDiver.GetDiving());
                                                Console.WriteLine($"Dive was also added to: {diversUser[i].FirstName}");
                                            }
                                        }
                                    }

                                    Console.WriteLine("Dive recorded succsesfuly !");
                                    Console.WriteLine("Press Enter");
                                    Console.ReadKey();

                                    shayManger.SetDivers();
                                    loginDiver.SetClubHeGo();

                                    Console.Clear();


                                }
                                
                                break;
                            case 2:
                                Console.WriteLine("Enter Dive club name OR enter country name(type 'list' to show all dive clubs)");
                                string clubName = Console.ReadLine();
                                loginDiver.enteringClub(clubName);
                                Console.WriteLine("Press Enter to continue");
                                Console.Clear();
                                break;
                            case 3:
                                Console.WriteLine("Enter partner ID OR Add new partner by typing 1");
                                int id = int.Parse(Console.ReadLine());
                                bool sameId = false;
                                if (id == loginDiver.Id)
                                {
                                    Console.WriteLine("you cant add yourself");
                                    Console.WriteLine("Press Enter");
                                    sameId = true;
                                    Console.ReadKey();
                                    Console.Clear();
                                }


                                if (sameId == false)
                                {
                                    shayManger.AddDivers(ref diversUser, id);
                                    Console.WriteLine("Press Enter To continue");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                                break;
                            case 4:
                                Console.WriteLine("Enter country name");
                                string countryName = Console.ReadLine();
                                loginDiver.PrintRegulationByCountry(countryName);
                                Console.WriteLine();
                                Console.WriteLine("Press Enter");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 5:
                                shayManger.SetDivers();
                                loginDiver = new Diver();
                                Console.Clear();
                                break;

                        }
                    }

                }// כאשר יש לו גם יוזר וגם מועדון וגם עוד חבר צוללן איתו. והוא יכול להוסיף צלילה
                else if(loginDiver.FirstName != null && (loginDiver.GetClubHeGo() != null || loginDiver.GetClubHeGo()==null) && loginDiver.GetDiving() != null)
                {
                    int choiceLog = -1;


                    while (choiceLog != 5)
                    {
                        if(loginDiver.GetClubHeGo() != null)
                        {
                            Console.WriteLine(@"User: " + loginDiver.FirstName + "                         " + "\t Dive club: " + loginDiver.GetClubHeGo().NameClub + "                         " + "\t Dive-Partners: " + shayManger.GetDivers().Length);
                        }
                        else
                        {
                            Console.WriteLine(@"User: " + loginDiver.FirstName + "                         " + "\t Dive club: Null                          " + "\t Dive-Partners: " + shayManger.GetDivers().Length);
                        }
                        
                        Console.WriteLine("========================");
                        Console.WriteLine("Welcome To proDiver 2.0");
                        Console.WriteLine("Welcome ,");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Choose: ");
                        Console.WriteLine("1)Add Dive");
                        Console.WriteLine("2)Enter DiveClub");
                        Console.WriteLine("3)Add Diving Partner/s");
                        Console.WriteLine("4)Display Diving regualtions By Country");
                        Console.WriteLine("5)Login menu");
                        Console.WriteLine("6)view previous dives");
                        choiceLog = int.Parse(Console.ReadLine());



                        switch (choiceLog)
                        {
                            case 1:
                                if (shayManger.GetDivers().Length == 0)
                                {
                                    Console.WriteLine("Choose a dive club OR add more partners");
                                    Console.WriteLine("Press Enter");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                                else if (shayManger.GetDivers().Length > 0)
                                {
                                    loginDiver.SetDiving(shayManger);
                                    Console.Clear();

                                    loginDiver.GetDiving().SetDateAndStartTimeAndFinishTime();
                                    Console.WriteLine("Press Enter to continue");
                                    Console.ReadKey();
                                    Console.Clear();

                                    Console.WriteLine("Press 1 To add  Gear or 0 to countine");
                                    int choiceGear = int.Parse(Console.ReadLine());
                                    while (choiceGear == 1)
                                    {
                                        loginDiver.GetDiving().SetGears();
                                        Console.WriteLine("Press 1 To add  Gear or 0 to countine");
                                        choiceGear = int.Parse(Console.ReadLine());
                                    }

                                    Console.Clear();

                                    Console.WriteLine(@"User: " + loginDiver.FirstName + "                         " + "\t Dive club: " + loginDiver.GetClubHeGo().NameClub + "                         " + "\t Dive-Partners: " + shayManger.GetDivers().Length);

                                    Console.WriteLine();

                                    Console.WriteLine(loginDiver.GetDiving().ToString());
                                    loginDiver.GetDiving().PrintGears();
                                    Console.WriteLine("Press Enter to Confirm OR any key to go back to main menu.");

                                    Console.ReadKey();
                                    Diver[] diverAdded = shayManger.GetDivers();
                                    for (int i = 0; i < diversUser.Length; i++)
                                    {
                                        for (int j = 0; j < diverAdded.Length; j++)
                                        {
                                            if (diversUser[i].Id == diverAdded[j].Id)
                                            {
                                                diversUser[i].SetDivingToAnotherUser(loginDiver.GetDiving());
                                                Console.WriteLine($"Dive was also added to: {diversUser[i].FirstName}");
                                            }
                                        }
                                    }

                                    Console.WriteLine("Dive recorded succsesfuly !");

                                    Console.Clear();
                                }

                                break;
                            case 2:
                                Console.WriteLine("Enter Dive club name OR enter country name(type 'list' to show all dive clubs)");
                                string clubName = Console.ReadLine();
                                loginDiver.enteringClub(clubName);
                                Console.WriteLine("Press Enter to continue");
                                Console.Clear();
                                break;
                            case 3:
                                Console.WriteLine("Enter partner ID OR Add new partner by typing 1");
                                int id = int.Parse(Console.ReadLine());
                                bool sameId = false;
                                if (id == loginDiver.Id)
                                {
                                    Console.WriteLine("you cant add yourself");
                                    Console.WriteLine("Press Enter");
                                    sameId = true;
                                    Console.ReadKey();
                                    Console.Clear();
                                }


                                if (sameId == false)
                                {
                                    shayManger.AddDivers(ref diversUser, id);
                                    Console.WriteLine("Press Enter To continue");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                                break;
                            case 4:
                                Console.WriteLine("Enter country name");
                                string countryName = Console.ReadLine();
                                loginDiver.PrintRegulationByCountry(countryName);
                                Console.WriteLine();
                                Console.WriteLine("Press Enter");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 5:
                                shayManger.SetDivers();
                                loginDiver = new Diver();
                                Console.Clear();
                                break;
                            case 6:
                                Console.WriteLine(loginDiver.GetDiving().ToString());
                                loginDiver.GetDiving().PrintGears();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                        }
                    }

                }// אחרי שאותו משתמש הוסיף צלילה , מתווסף לו אופציה לראות את הצלילה הקודמת שלו

            }
            
            



        }

       




        // פונקציה להוספת צוללנים למערכת
        public static Diver[] UpdateDiversUsersArray(Diver[] diversUser, Diver newUser)
        {
            Diver[] newDiversUsers = new Diver[diversUser.Length + 1];
            int i = 0;

            for (; i < newDiversUsers.Length - 1; i++)
            {
                newDiversUsers[i] = diversUser[i];
            }

            newDiversUsers[i] = newUser;

            return newDiversUsers;
        }

        




        

    }
}
