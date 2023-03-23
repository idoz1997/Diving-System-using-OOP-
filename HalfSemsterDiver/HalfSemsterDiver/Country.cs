using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfSemsterDiver
{
    public class Country
    {
        private string name;
        private string regulation;


        public Country(string name)
        {
            this.name = name;
        }

        public void SetRegulation(string reg)
        {
            this.regulation = reg;
        }


        public string GetRegulation()
        {
            return regulation;
        }


        public string NameCountry
        {
            set { name = value; }
            get { return name; }

        }


    }
}
