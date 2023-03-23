using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HalfSemsterDiver
{
    public class Club 
    {
        private int id;
        private string name;
        private string cotact;
        private string city;
        private string street;
        private Country countryClub;
        private string phoneNumber;
        private string email;
        private string website;

        public Club(int id, string name, string cotact, string city, string street, string phoneNumber, string email, string website,string country)
        {
            this.id = id;
            this.name = name;
            this.cotact = cotact;
            this.city = city;
            this.street = street;
            this.countryClub = new Country(country.ToLower());
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.website = website;
        }
        
        public string GetCountryName()
        {
            return countryClub.NameCountry;
        }

        public void SetRegulationToCountry(string reg)
        {
            countryClub.SetRegulation(reg);
        }

        public string GetRegulationByCountry(string countryName)
        {
                return this.countryClub.GetRegulation();
        }

        public Country CountryClub
        {
            get { return this.countryClub;}
            set { this.countryClub = value;}
        }

        public int IdClub
        {
            get { return id; }
            set { id = value; }
        }

        public string NameClub
        {
            get { return name; }
            set { name = value; }
        }



        public string Cotact
        {
            get { return cotact; }
            set
            {
                cotact = value;
            }
        }

        public string CityClub
        {
            get { return city; }
            set
            {
                city = value;
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                street = value;
            }
        }

        public string PhoneNumberClub
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
            }
        }

        public string EmailClub
        {
            get { return email; }
            set
            {
                email = value;
            }
        }

        public string WebsiteClub
        {
            get { return website; }
            set
            {
                website = value;
            }
        }

    }
}
