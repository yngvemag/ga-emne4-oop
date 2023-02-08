using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Console_App_Introduksjon.Gokstad
{

    /*
      * Person
              - FirstName (string)
              - LastName
              - FullName (sammensatt property)
          
              
              - DayOfBirth (dato) -> DateTime              
                    1: metode (int year, int month, int day)
                    2: metode ( string -> 'yyyy-mm--dd' )

              - GetAge -> kalkulere (property eller method)
                    1: metode -> lage logikk, skrive litt kode
            
              - ToString() -> returnere data state fra klassen!!

              // List<>()
              - venner ??              
     */
    public class Person
    {
        // konstruktør
        // ()
        public Person() { }

        // (string, string)
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person(string firstName, string lastName, int year, int month, int day)
        {
            FirstName = firstName;
            LastName = lastName;
            DayOfBirth = new DateTime(year, month, day);
        }


        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // 2 måter på FullName
        // 1: property (kun lesing - ikke mulig å legge til fullname property)
        public string? FullName 
        {
            get 
            {
                // legge inn min kode i get!!
                return $"{FirstName} {LastName}";                
            }
        }

        public DateTime DayOfBirth { get; set; }


        // Methods -> Navn (lese metode "Get") -> GetFullName()
        // yngve. må være public
        // public <datatype ut av funksjon> <funksjonsnavn>( evt. parameter )
        public string GetFullName()
        {
            //Console.WriteLine($"{FirstName} {LastName}");
            return $"{FirstName} {LastName}";
        }

        // overloading -> ser på signaturen
        public void SetDayOfBirth(int year, int month, int day)
        {
            DayOfBirth = new DateTime(year, month, day);
        }

        public void SetDayOfBirth(string date, string format)
        {
            CultureInfo cultureInfo = new CultureInfo("nb-NO");
            DayOfBirth = DateTime.ParseExact(date, format, cultureInfo);
        }

        // Alder (antall år)
        public int GetAgeInYear()
        {
            // tidsrom = dato nå - fødselsdato
            TimeSpan span = DateTime.Now - DayOfBirth;
            return (int)span.TotalDays / 365;
        }

        public override string ToString()
        {
            return $"FirstName={FirstName}, LastName={LastName}, FullName={FullName}, DayOfBirth={DayOfBirth.ToString()}";
        }
    }

}
