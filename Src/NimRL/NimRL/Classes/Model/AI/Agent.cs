using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimRL.Classes.Model.AI
{
    public class Agent
    {
        // Constants
        private const int _INITIAL_ROUNDS_NB = 0;


        // Fields
        private int _roundsNb;

        private Policy _policy;


        // Properties
        private int _RoundsNb { get => _roundsNb; set => _roundsNb = value; }
        private Policy _Policy { get => _policy; set => _policy = value; }


        // Ctor
        public Agent()
        {
            this._RoundsNb = Agent._INITIAL_ROUNDS_NB;

            this._Policy = new Policy();
        }


        // Methods
        public int GetAction()
        {
            // todo implement GetAction
            return 0;
        }
        
        public int[] GetBestActions()
        {
            // todo implement GetBestActions
            return new int[2];
        }

        public Dictionary<int, Dictionary<int, int>> GetValuesMapByMatchesNb()
        {
            // todo implement GetValuesMapByMatchesNb
            return new Dictionary<int, Dictionary<int, int>>();
        }


        public void GiveReinforcement(int[] loserActions, int[] winnerActions)
        {
            // todo implement GiveReinforcement
        }
    }
}
