using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DemoProsjekt
{
    // Internal -> denne klassen kan kun brukes i dette prosjektet
    public class Demo
    {
        #region Fields
        // Field ( attributes, variabler i klassen)
        private int _demoId = 0;

        #endregion

        #region konstruktører
        // Konstruktør
        public Demo() { }

        // signature: (int, int)
        public Demo(int demoId, int demoNumber)
        {
            // samtidig sette interne variabler
            DemoId = demoId;
            DemoNumber = demoNumber;
        }
        #endregion

        #region Properties
        // Properties
        public int DemoNumber { get; set; } = 0;

        public int DemoId 
        {
            get { return _demoId; }
            set { _demoId = value; } 
        }
        #endregion

        #region Metoder/funksjoner
        // Metoder / Funksjon
        public double Divide(int a, int b)
        {
            if (b == 0)
                return 0;
            return (double)a / (double)b;
        }

        public int GetDemoId() 
        {
            return _demoId;
        }

        #endregion
    }
}
