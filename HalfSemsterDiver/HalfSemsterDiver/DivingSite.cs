using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfSemsterDiver
{
    public class DivingSite
    {
        private string name;
        private string adress;
        private Country countrySite;
        private string about;
        private double deep;
        private string waterType;

        public DivingSite(string name, string adress, Country countrySite, string about, double deep, string waterType)
        {
            this.name = name;
            this.adress = adress;
            this.countrySite = countrySite;
            this.about = about;
            this.deep = deep;
            this.waterType = waterType;
            this.countrySite = countrySite;
        }






        // פעולות set & get


        public string NameDivingSite
        {
            get { return name; }
            set { name = value; }
        }

        public string AdressDivingSite
        {
            get { return adress; }
            set { adress = value; }
        }

        public string AboutDivingSite
        {
            get { return about; }
            set { about = value; }        
        }

        public double DeepDivingSite
        {
            get { return deep; }
            set
            {
                deep = value;
            }
        }

        public string WaterTypeDivingSite
        {
            get { return waterType; }
            set
            {
                waterType = value;
            }
        }




        
    }
}
