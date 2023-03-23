using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfSemsterDiver
{
    public class Instructor : Diver
    {
        private Club[] workplaces;
        private Diver[] divers;
        private int[] startDates;
        private int[] endDates;

        public Instructor(string firstName,string lastName, string password, int id) : base(firstName, lastName,password,id)
        {
            this.workplaces = new Club[3];
            this.divers= new Diver[0];

        }

        public void AddWorkPlaces(Club[] workplaces)
        {
            this.workplaces = workplaces;
        }

        public Club[] GetWorkPlaces()
        {
            return this.workplaces;
        }


        public void AddDivers(ref Diver[] diversProm,int idDiver)
        {
            Diver[] newDivers = new Diver[divers.Length + 1];
            if (idDiver == 1)
            {
                Console.WriteLine("Enter first name:");
                string fName = Console.ReadLine();
                Console.WriteLine("Enter last name:");
                string lName = Console.ReadLine();

                Diver newDiverUser = new Diver(fName, lName);
                newDiverUser.Register(fName, lName);
                newDivers[divers.Length] = newDiverUser;

                this.divers = newDivers;

                Diver[] newArrayForDiversRegisters = new Diver[diversProm.Length + 1];
                int j = 0;
                for (; j < diversProm.Length; j++)
                {
                    newArrayForDiversRegisters[j] = diversProm[j];
                }

                newArrayForDiversRegisters[j] = newDiverUser;

                diversProm = newArrayForDiversRegisters;
            }

            bool alreadyExists = false;

            for(int i = 0; i < divers.Length; i++)
            {
                if (divers[i].Id == idDiver)
                {
                    alreadyExists = true;
                    Console.WriteLine("already exists");
                    break;
                }
            }
            
            if (!alreadyExists)
            {
                for (int i = 0; i < diversProm.Length; i++)
                {
                    if (diversProm[i].Id == idDiver)
                    {
                        newDivers[newDivers.Length-1] = diversProm[i];
                    }
                }

                this.divers = newDivers;

                Console.WriteLine($"{newDivers[newDivers.Length-1].FirstName} was added Successfuly");
            }
            
        }


        public Diver[] GetDivers()
        {
            return this.divers;
        }

        public void SetDivers()
        {
            this.divers = new Diver[0];
        }



    }
}
