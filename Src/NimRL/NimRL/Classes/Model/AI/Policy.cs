using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimRL.Classes.Model.AI
{
    public class Policy
    {
        // Constants
        private static readonly Dictionary<int, int> _DEFAULT_VALUES_BY_OPTION_DICT = new Dictionary<int, int>() 
        {
            {1 , 5},
            {2 , 5},
            {3 , 5}
        };


        // Fields
        private Dictionary<int, Dictionary<int, int>> _valuesMapByMatchesNb;


        // Properties
        public Dictionary<int, Dictionary<int, int>> ValuesMapByMatchesNb { get => _valuesMapByMatchesNb; private set => _valuesMapByMatchesNb = value; }


        // Ctor
        public Policy()
        {
            this.ValuesMapByMatchesNb = new Dictionary<int, Dictionary<int, int>>();
        }


        // Methods
        private void AddMatchesNb(int matchesNb)
        {
            // todo implement AddMatchesNb

        }

        public int GetAction(int matchesNb)
        {
            // todo implement GetAction
            return 0;
        }

        public void UpdateValues(int matchesNb, int action, bool isPositiveReinforcement)
        {
            // todo implement UpdateValues
        }


        public override string ToString()
        {
            // todo implement ToString
            return $"";
        }
    }
}
