using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Console_App_Introduksjon.Gokstad
{

    /*
      * Person
              - navn (string)
              - fødselsår (int)
              - ???
              - ???
              - Alder ??
              - 
     */
    public class Person
    {
        // konstruktør
        public Person() { }

        public Person(string name, int birthYear)
        {
            // this -> "dette objektet"
            Name = name;
            BirthYear = birthYear;
        }

        // Properties
        public string? Name { get; set; }

        public int BirthYear { get; set; }
    }

}
