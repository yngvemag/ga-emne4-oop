using Console_App_Introduksjon.Gokstad;

internal class Program
{   
    /*
        - Lage skriver ut navn og fødselssår på personer
        
        Lage en beskrivelse av dette!
        'class' -> oppskrift på noe!!
        
        eks: bake kake:
            oppskrift : 'class'
            prosess lage kake
                'new' !!!
                    konstruktører 
                    konstruktører (med nonstop)
            når kaka er ferdig og du kan spise: 'object'

        * Person
              - navn (Field, Property!!)
              - fødselsår (Property)
     
     */

    private static void Main(string[] args)
    {

        // StreamReader
        // (StreamWriter)

        /*
            with open("file.txt", "r") as fin:
                line = fin.readline()         
                
         */
        List<Person> persons = new List<Person>();

        string filename = "C:\\ga\\Emne 4 OOP Introduksjon\\Console App Introduksjon\\names.txt";
        using (StreamReader reader = new StreamReader(filename))
        {
            string? line = reader.ReadLine();
            while ( line != null) 
            {
                Person person = new Person();

                // Yngve, Magnussen, 1973, 04, 30
                // arr[0] = Yngve
                // arr[1] = Magnussen
                // arr[2] = 1973
                // arr[3] = 4
                // arr[4] = 30
                var arr = line.Split(",");

                person.FirstName = arr[0];
                person.LastName = arr[1];


                // legger til i listen
                persons.Add(person);

                line = reader.ReadLine();
            }


            foreach(Person person in persons) 
            {
                Console.WriteLine(person.ToString());
            }
            
        }

    }

    private void OldStuff()
    {
        // ALT ER Objekt !!!!
        // Person()
        Person p1 = new Person("Yngve", "Magnussen", 1973, 04, 30);
        Person p2 = new Person("Ola", "Normann", 2000, 10, 4);
        Person p3 = new Person("Kari", "Normann", 1998, 7, 15);

        // to måter å håndtere flere objekter
        // 1. Array
        // 2. List

        // Array på 3 elementer!
        Person[] persons = { p1, p2, p3 }; // bruker også new - men implisitt

        /*

        // for-løkke
        // range(start, stop, step)
        for (int i=0; i<persons.Length;i++) 
            Console.WriteLine(persons[i].ToString());
        

        foreach (var person in persons)
        {
            Console.WriteLine(person.ToString());
        }

        // 1 person til !! -> så er det vanskelig
        
       
        
            Person[] persons_2 = new Person[] { p1, p2, p3 };

            Person[] persons_3 = new Person[3];
            persons_3[0] = p1;
            persons_3[1] = p2;
            persons_3[2] = p3;     
        */

        //yngve.SetDayOfBirth("1973-04-30", "yyyy-mm-dd");

        // 2. List (generic)
        //List<Person> people = new List<Person>()
        List<Person> people = new();
        people.Add(p1);
        people.Add(p2);
        people.Add(p3);

        //for (int i = 0; i < people.Count; i++)
        //Console.WriteLine(people[i].ToString());

        /*
        foreach (Person person in people)
        {
            Console.WriteLine(person.ToString());
        }
        */

        people.ForEach(person => Console.WriteLine(person.ToString()));



        // Person(string name, int birthYear)
        //Person ola = new Person("Ola Normann", 2000); // "" -> string, 2000 -> int


        //Console.WriteLine($"Navnet på person er {yngve.FullName} og er født i år {yngve.DayOfBirth} Alder={yngve.GetAgeInYear()}");
        //Console.WriteLine($"Navnet på person er {ola.Name} og er født i år {ola.BirthYear}");

        //Console.WriteLine(yngve.ToString());
    }
}