using CustomerInformation.classicmodels;

/*    ​
    lage program.cs​​
        - lag en liste (List<>) som alle "Customer" skal legges i
        - Leser filen "Customer.csv"
        - Leser linje for linje
        - splitter linjene til Array[]
        - Henter ut verdier fra array
        - Lager et object fra klassen Customer og legger inn verdier fra array
        - for alle customer i listen -> skriv ut med ToString()
*/

// Array -> string[]
// List -> List<int>, List<string>, List<Customer>
List<Customer> customerList = new();

string customerFileName = "C:\\ga\\Emne 4 OOP Introduksjon\\Customers.csv";
using (StreamReader reader = new(customerFileName))
{
    string? headerLine = reader.ReadLine();
    if (headerLine != null)
    {
        string? line = reader.ReadLine();
        while (line != null)
        {
            // csv - comma separated values
            // CustomerNumber,CustomerName,   Phone,        Address,          City,      Country
            // '103' ,  "Atelier graphique"  ,  40.32.2555  ,"54 rue Royale" ,  Nantes  ,  France
            // [0] ,        [1]            ,       [2]    ,     [3]        ,   [4]    ,    [5]

            //  148  ,  "Dragon Souveniers,     Ltd.",   "+65 221 7555"   ,  "Bronz Sok. "   ,Singapore     ,  Singapore
            //  [0]  ,        [1]         ,      [2] ,         [3]        ,    [4]           ,  [5]         ,   [6]

            string[] lineSplitValuesByComma = line.Split(",");

            if ( lineSplitValuesByComma.Length == 6)
            {
                Customer customer = new();
                customer.CustomerNumber = int.Parse(lineSplitValuesByComma[0]);
                customer.CustomerName = lineSplitValuesByComma[1];
                customer.Phone = lineSplitValuesByComma[2];
                customer.Address = lineSplitValuesByComma[3];
                customer.City = lineSplitValuesByComma[4];
                customer.Country = lineSplitValuesByComma[5];

                customerList.Add(customer);
            }
            else
            {
                Console.WriteLine($"BAD INPUT: {line}");
            }

           

            //Console.WriteLine($"CustomerNumber={lineSplitValuesByComma[0]}," +
            //    $"CustomerName={lineSplitValuesByComma[1]}");

            line = reader.ReadLine();
        }
    }
}

// CustomerNumber,CustomerName,   Phone,        Address,          City,      Country
foreach ( var c in customerList )
{
    Console.WriteLine(c.ToString());
}
/*
for ( var i = 0; i < customerList.Count; i++ )
{
    customerList[i].CustomerNumber = i;
}*/

// customerList.ForEach(elem => Console.WriteLine(""));



