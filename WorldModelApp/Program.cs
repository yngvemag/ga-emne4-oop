
using WorldModelLibrary;
using WorldModelLibrary.models;

#region Filepaths

const string cityFile = "C:\\ga\\Emne 4 OOP Introduksjon\\City.csv";
const string countryFile = "C:\\ga\\Emne 4 OOP Introduksjon\\Country.csv";
const string languageFile = "C:\\ga\\Emne 4 OOP Introduksjon\\CountryLanguage.csv";
const string logFile = "C:\\ga\\Emne 4 OOP Introduksjon\\Log.txt";

if (File.Exists(logFile))
    File.Delete(logFile);

#endregion

#region Create and load WorldDataModel

WorldDataModel worldModel = new(cityFile, countryFile, languageFile);

// load models with attache logger
var isLoaded = worldModel.LoadModels( str => 
{
    using StreamWriter writer = new StreamWriter(logFile, true, System.Text.Encoding.UTF8);
    writer.WriteLine($"{DateTime.Now}\t {str}");
});

if (!isLoaded)
    Console.WriteLine("Opps, sjekk logfilen for error!");
#endregion

#region Print Countries with cities and languages

if (worldModel.IsLoadedSucessfully && worldModel.Countries!=null && worldModel.Countries.Any())
{
    foreach (var cntry in worldModel.Countries)
    {
        ExtractCities(cntry);
        ExtractCountryLanguages(cntry);
    }

}

static void ExtractCities(Country cntry)
{
    Console.WriteLine($"Country: {cntry.Name}");
    Console.WriteLine("\tCities:");
    if (cntry.Cities != null)
    {
        foreach (var cty in cntry.Cities.Values)
        {
            Console.WriteLine($"\t\t{cty.Name} ({cty.Population})");
        }
    }
}

static void ExtractCountryLanguages(Country cntry)
{
    Console.WriteLine("\tLanguages:");
    if (cntry.Languages != null)
    {
        foreach (var lang in cntry.Languages.Values)
        {
            Console.WriteLine($"\t\t{lang.Language}");
        }
    }
}

#endregion
