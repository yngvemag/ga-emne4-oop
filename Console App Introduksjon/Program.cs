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

        // Person()
        Person yngve = new Person();
        yngve.Name = "Yngve Magnussen";
        yngve.BirthYear = 1973;


        // Person(string name, int birthYear)
        Person ola = new ("Ola Normann", 2000);


        Console.WriteLine($"Navnet på person er {yngve.Name} og er født i år {yngve.BirthYear}");
        Console.WriteLine($"Navnet på person er {ola.Name} og er født i år {ola.BirthYear}");

    }
}