
using WorldModelLibrary;

#region Filepaths

const string cityFile = "C:\\ga\\Emne 4 OOP Introduksjon\\City.csv";
const string countryFile = "C:\\ga\\Emne 4 OOP Introduksjon\\Country.csv";
const string languageFile = "C:\\ga\\Emne 4 OOP Introduksjon\\CountryLanguage.csv";
const string logFile = "C:\\ga\\Emne 4 OOP Introduksjon\\Log.txt";

if (File.Exists(logFile))
    File.Delete(logFile);

#endregion

#region Create and load WorldDataModel

WorldDataModel worldModel = new();

// load models with attache logger
worldModel.LoadModels(cityFile, countryFile, languageFile, 
    (str) => 
    { 
        using (var writer = new StreamWriter(logFile, true, System.Text.Encoding.UTF8))
        {
            writer.WriteLine($"{DateTime.Now.ToString()}\t {str}");
        }
    });
#endregion

#region Print Countries with cities and languages

if (worldModel.IsLoadedSucessfully)
{
    if (worldModel.Countries != null)
        foreach (var cntry in worldModel.Countries)
        {
            Console.WriteLine($"Country: {cntry.Name}" );
            Console.WriteLine("\tCities:");
            if (cntry.Cities != null)
                foreach (var cty in cntry.Cities.Values)
                    Console.WriteLine($"\t\t{cty.Name} ({cty.Population})");

            Console.WriteLine("\tLanguages:");
            if (cntry.Languages != null)
                foreach (var lang in cntry.Languages.Values)
                    Console.WriteLine($"\t\t{lang.Language}");
        }        
}

#endregion
