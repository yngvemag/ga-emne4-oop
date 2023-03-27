using GATools.File;
using GATools.String;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using WorldModelLibrary.models;

namespace WorldModelLibrary
{
    public class WorldDataModel
    {
        #region Fields

        // readonly:
        // readonly-variabel en variabel som ikke kan endres etter at den er initialisert.
        //      * Du kan bare tilordne en verdi til en readonly-variabel i konstruktøren, eller når du erklærer variabelen.
        //      * Du kan ikke endre verdien på en readonly-variabel senere i programmet, uansett hvor i koden det er.

        private readonly string _cityFileName;
        private readonly string _countryFileName;
        private readonly string _countryLanguageFileName;

        #endregion

        #region Construktor
        public WorldDataModel(string cityFileName, string countryFileName, string countryLanguageFileName)
        {
            _cityFileName = cityFileName;
            _countryFileName = countryFileName; 
            _countryLanguageFileName = countryLanguageFileName;
        }

        #endregion

        #region Delegates

        private Action<string> _log = str => { };

        #endregion

        #region Properties

        public bool IsLoadedSucessfully { get; set; }
        public List<City>? Cities { get; set; }
        public List<Country>? Countries { get; set; }
        public List<CountryLanguage>? Languages { get; set; }

        #endregion

        #region Functions/Methods
        public bool LoadModels(Action<string>? log) // hvis du velger å implementere egen log funksjon kan du sende den inn som paramter
        {            
            if (log != null)
                _log = log;

            Cities = LoadCities(_cityFileName)?.ToList();
            Countries = LoadCountries(_countryFileName)?.ToList();
            Languages = LoadCountryLanguages(_countryLanguageFileName)?.ToList();

            // kobler sammen modellen
            ConnectModels();

            // dette er det samme som if setningen under
            IsLoadedSucessfully = true ? (Cities != null && Countries != null && Languages != null) : false;

            /*
            if (Cities != null && Countries != null && Languages != null)
                IsLoadedSucessfully = true;
            else
                IsLoadedSucessfully = false;
            */

            return IsLoadedSucessfully;
        }

        private ICollection<City>? LoadCities(string fileName)
        {
            if (!File.Exists(fileName))
            {
                _log($"File does not exist: {fileName}");
                return null;
            }

            //    ID,Name,CountryCode,District,Population
            //    1,Kabul,AFG,Kabol,1780000 
            return GAFileObjects<City>.GetLineObjects(
                fileName,
                line => CSVTool.Split(line),
                arr =>
                {
                    if (arr is [var idStr, var name, var countryCode, var district, var populationStr])
                    {
                        if (!int.TryParse(idStr, out int id))
                            _log($"Failed to parse City.Id {idStr} as int");
                        if (!uint.TryParse(populationStr, out uint population))
                            _log($"Failed to parse City.Population:{populationStr} as uint");

                        return new City() { Id = id, District = district, CountryCode = countryCode, Name = name, Population = population };
                    }
                    return null;
                });
        }

        private ICollection<Country>? LoadCountries(string fileName)
        {
            if (!File.Exists(fileName))
            {
                _log($"File does not exist: {fileName}");
                return null;
            }

            //Code,Name,Continent,Region,SurfaceArea,IndepYear,Population,LifeExpectancy,GNP,GNPOld,LocalName,GovernmentForm,HeadOfState,Capital,Code2
            //ABW, Aruba,"North America",Caribbean,193.00,NULL,103000,78.4,828.00,793.00,Aruba,"Nonmetropolitan Territory of The Netherlands",Beatrix,129,AW
            return GAFileObjects<Country>.GetLineObjects(
                fileName,
                line => CSVTool.Split(line),
                arr =>
                {
                    if (arr is [var code, var name, var continet, var region, var surfaceArea, var indepYear, 
                        var population, var lifeExpectancy, var gnp, var gnpOld, var localName, var govermentForm, var headOfState, var capital, var code2 ])
                    {
                        if (!float.TryParse(surfaceArea, CultureInfo.InvariantCulture, out float surfArea))
                            _log($"Failed to parse Country.SurfaceArea:{surfaceArea} as float");
                        if (!int.TryParse(indepYear, out int indYear))
                            _log($"Failed to parse Country.IndepYear:{indepYear} as int");
                        if (!uint.TryParse(population, out uint pop))
                            _log($"Failed to parse  Country.Population:{population} as int");
                        if (!float.TryParse(lifeExpectancy, CultureInfo.InvariantCulture, out float lifeExp))
                            _log($"Failed to parse  Country.LifeExpectancy:{lifeExpectancy} as float");
                        if (!float.TryParse(gnp, CultureInfo.InvariantCulture, out float gnpf))
                            _log($"Failed to parse Country.GNP:{gnp} as float");
                        if (!float.TryParse(gnpOld, CultureInfo.InvariantCulture, out float gnpOldf))
                            _log($"Failed to parse Country.GNP_Old{gnpOld} as float");
                        if (!int.TryParse(capital, out int cap))
                            _log($"Failed to parse Country.Capital:{capital} as int");

                        return new Country() 
                        {
                            Code = code, Name = name, Continent = continet, Region = region, SurfaceArea = surfArea, IndepYear = indYear, Population = pop, LifeExpectancy = lifeExp,
                            GNP = gnpf, GNP_Old = gnpOldf, LocalName = localName, GovernmentForm = govermentForm, HeadOfState = headOfState, Capital = cap, Code2 = code2
                        };
                    }
                    return null;
                });
        }

        private ICollection<CountryLanguage>? LoadCountryLanguages(string fileName)
        {
            if (!File.Exists(fileName))
            {
                _log($"File does not exist: {fileName}");
                return null;
            }

            // CountryCode,Language,IsOfficial,Percentage
            // ABW,Dutch,T,5.3
            return GAFileObjects<CountryLanguage>.GetLineObjects(
                fileName,
                line => CSVTool.Split(line),
                arr =>
                {
                    if (arr is [var countryCode, var language, var isOfficial, var percentage])
                    {
                        var official = true ? isOfficial.ToLower().Equals("T") : false;
                        if (!float.TryParse(percentage, CultureInfo.InvariantCulture, out float fpercentage))
                        {
                            _log($"Failed to parse CountryLanguage.Percentage:{percentage} as float");
                        }

                        return new CountryLanguage() 
                        {
                            CountryCode = countryCode, Language = language, IsOfficial = official, Percentage = fpercentage
                        };
                    }
                    else return null;
                });
        }

        private void ConnectModels()
        {
            // kobler sammen objektene ved hjelp av fremmednøkkel (CountryCode)
            if (Countries != null && Countries.Any())
            {
                foreach (var cntr in Countries)
                {
                    // legger all byene som har samme contrycode
                    if (Cities != null && Cities.Any())
                    {
                        foreach (var cty in Cities.Where(c => c.CountryCode.Equals(cntr.Code)))
                        {
                            cntr.AddCity(cty);
                        }
                    }

                    // legger til alle offisielle språk 
                    if (Languages != null && Languages.Any())
                    {
                        foreach (var lang in Languages.Where(l => l.CountryCode.Equals(cntr.Code)))
                        {
                            cntr.AddLanguage(lang);
                        }
                    }
                }
            }

        }

        #endregion
    }
}