using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfSemsterDiver
{
    public class Gear
    {
        private string name;
        private int amount;
        private string note;


        public Gear(string name, int amount, string note)
        {
            this.name = name;
            this.amount = amount;
            this.note = note;
        }

        public string NameGear
        {
            set { name = value; }
            get { return name; }
        }

        public int AmountGear
        {
            set { amount = value; }
            get { return amount; }
        }

        public string NoteGear
        {
            set { note = value; }
            get { return note; }
        }


        public override string ToString()
        {
            string print = $"Type: {name} Amount:{amount} Comment:{note}";
            return print ;
        }

    }
}
