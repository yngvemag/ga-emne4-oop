using WorldModelLibrary;
using WorldModelLibrary.models;

namespace WorldModelGui
{
    public partial class WorldGui : Form
    {
        #region Filepaths

        const string cityFile = "C:\\ga\\Emne 4 OOP Introduksjon\\City.csv";
        const string countryFile = "C:\\ga\\Emne 4 OOP Introduksjon\\Country.csv";
        const string languageFile = "C:\\ga\\Emne 4 OOP Introduksjon\\CountryLanguage.csv";
        const string logFile = "C:\\ga\\Emne 4 OOP Introduksjon\\Log.txt";


        #endregion

        private WorldDataModel? _worldModel;
        public WorldGui()
        {
            InitializeComponent();

            this.Load += WorldGui_Load;

        }

        private void WorldGui_Load(object? sender, EventArgs e)
        {
            if (LoadData())
                ExtractData();
        }

        private bool LoadData()
        {
            _worldModel = new(cityFile, countryFile, languageFile);

            // load models with attache logger
            var isLoaded = _worldModel.LoadModels(null);
            if (!isLoaded)
            {
                MessageBox.Show("Opps, sjekk logfilen for error!");
                return false;
            }
            return true;
        }

        private void ExtractData()
        {
            if (_worldModel == null) return;

            treeViewWorld.Nodes.Clear();

            Func<Country, bool> countryFilter = txtCountryFilter.Text.Equals(string.Empty)
                ? cntr => true
                : cntr => cntr.Name.ToLower().Contains(txtCountryFilter.Text);

            /*
            Func<City, bool> cityFilter = txtCityFilter.Text.Equals(string.Empty)
                ? cty => true
                : cty => cty.Name.ToLower().Contains(txtCityFilter.Text);*/

            if (_worldModel.Countries != null)
            {
                foreach (var cntry in _worldModel.Countries.Where(countryFilter))
                {
                    TreeNode cntrNode = new(cntry.Name);

                    AddCitiesTreeNodes(cntry, cntrNode);
                    AddCountryLanguagesTreeNodes(cntry, cntrNode);

                    // add all country properties 
                    foreach (var prop in cntry.GetType().GetProperties())
                    {
                        cntrNode.Nodes.Add($"{prop.Name}: {prop.GetValue(cntry)}");
                    }

                    treeViewWorld.Nodes.Add(cntrNode);
                }
            }
        }

        private static void AddCountryLanguagesTreeNodes(Country? cntry, TreeNode cntrNode)
        {
            if (cntry == null || cntry.Languages == null || cntry.Languages.Values == null) return;

            TreeNode languagesNode = new("Official Languages");
            foreach (var lang in cntry.Languages.Values)
            {
                TreeNode langNode = new(lang.Language);
                languagesNode.Nodes.Add(langNode);
            }
            
            cntrNode.Nodes.Add(languagesNode);
        }

        private static void AddCitiesTreeNodes(Country? cntry, TreeNode cntrNode)
        {
            if (cntry == null || cntry.Cities == null || cntry.Cities.Values == null) return;
            TreeNode citiesNode = new("Cities");

            foreach (var cty in cntry.Cities.Values)
            {
                TreeNode cityNode = new(cty.Name);
                foreach (var prop in cty.GetType().GetProperties())
                {
                    cityNode.Nodes.Add(new TreeNode($"{prop.Name}: {prop.GetValue(cty)}"));
                }

                citiesNode.Nodes.Add(cityNode);
            }
        
            cntrNode.Nodes.Add(citiesNode);
        }

        private void txtCountryFilter_TextChanged(object sender, EventArgs e)
        {
            if (LoadData())
            {
                ExtractData();
            }
        }
    }
}