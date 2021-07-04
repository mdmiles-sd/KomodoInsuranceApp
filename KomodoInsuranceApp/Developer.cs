using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceApp
{   //POCO
    public class Developer
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool Pluralsight { get; set; }

        public Developer() { }

        public Developer(string name, int id, bool pluralsight) 
        {
            Name = name;
            ID = id;
            Pluralsight = pluralsight;
        }

        
    }
}
