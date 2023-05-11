using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NimRL.Classes.Model.AI
{
    public class Policy
    {
        // Constants
        private const int _ACTION1 = 1;
        private const int _ACTION2 = 2;
        private const int _ACTION3 = 3;

        private const int _DEFAULT_VALUE = 100;

        private static readonly Dictionary<int, int> _DEFAULT_VALUES_BY_ACTION_DICT = new Dictionary<int, int>() 
        {
            {Policy._ACTION1 , Policy._DEFAULT_VALUE},
            {Policy._ACTION2 , Policy._DEFAULT_VALUE},
            {Policy._ACTION3 , Policy._DEFAULT_VALUE}
        };


        // Fields
        private Dictionary<int, Dictionary<int, int>> _valuesMapByMatchesNb; // Maps values to actions to a number of matches;
                                                                             // <number of matches, <action, value>>
                                                                             // number of matches   : [1, 20]
                                                                             // action : 1, 2, 3
                                                                             // value  : N
                                                                             //
                                                                             // The dict doesn't have default values, when updating values
                                                                             // if the step doesn't exist it is added

        private Random _random; 

        // Properties
        public Dictionary<int, Dictionary<int, int>> ValuesMapByMatchesNb { get => _valuesMapByMatchesNb; private set => _valuesMapByMatchesNb = value; }
        private Random _Random { get => _random; set => _random = value; }


        // Ctor
        public Policy()
        {
            this.ValuesMapByMatchesNb = new Dictionary<int, Dictionary<int, int>>();

            this._Random = new Random(Guid.NewGuid().GetHashCode());
        }


        // Methods
        /// <summary>
        /// Adds a number of matches to the Map as a key
        /// </summary>
        /// <param name="matchesNb">Number of matches (Key)</param>
        private void AddMatchesNb(int matchesNb)
        {
            this.ValuesMapByMatchesNb.Add(matchesNb, new Dictionary<int, int>(Policy._DEFAULT_VALUES_BY_ACTION_DICT));
        }

        /// <summary>
        /// Gets a random action, where each action's value weights the selection
        /// </summary>
        /// <param name="matchesNb"></param>
        /// <returns>Random action</returns>
        public int GetAction(int matchesNb)
        {
            int action;
            // if the matchesNb exists in the map
            if (this.ValuesMapByMatchesNb.ContainsKey(matchesNb))
            {
                Dictionary<int, int> valueByActionDict = this.ValuesMapByMatchesNb[matchesNb];
                
                // get actions' values
                int action1Value = valueByActionDict[Policy._ACTION1];
                int action2Value = valueByActionDict[Policy._ACTION2];
                int action3Value = valueByActionDict[Policy._ACTION3];
                
                int randomNb = this._Random.Next(action1Value + action2Value + action3Value);

                if (randomNb < action1Value)
                {
                    action = Policy._ACTION1;
                }
                else if (randomNb < action1Value + action2Value)
                {
                    action = Policy._ACTION2;
                }
                else // randomNb < action1Value + action2Value + action3Value
                {
                    action = Policy._ACTION3;
                }
            }
            else // if it doesn't
            {
                // generate a random action
                action = this._Random.Next(1, Policy._ACTION3 + 1);
            }

            return action;
        }

        /// <summary>
        /// Updates the value of an action of a matches number
        /// </summary>
        /// <param name="matchesNb"></param>
        /// <param name="action"></param>
        /// <param name="isPositiveReinforcement"></param>
        /// <exception cref="Exception">Throws an error if the action is invalid</exception>
        public void UpdateValue(int matchesNb, int action, bool isPositiveReinforcement)
        {
            const int INCREASE = 1;
            const int DECREASE = -1;

            // determine the reinforcement
            int reinforcement;
            if (isPositiveReinforcement)
            {
                reinforcement = INCREASE;
            }
            else
            {
                reinforcement = DECREASE;
            }

            // if the key doesn't exist, add it
            if (!this.ValuesMapByMatchesNb.ContainsKey(matchesNb))
            {
                AddMatchesNb(matchesNb);
            }

            Dictionary<int, int> valueByActionDict = this.ValuesMapByMatchesNb[matchesNb];
            // check that the action is available
            if (valueByActionDict.ContainsKey(action))
            {
                // give reinforcement
                valueByActionDict[action] += reinforcement;

                MakeMapCompliant(matchesNb);
            }
            else
            {
                throw new Exception("Invalid action");
            }
        }

        /// <summary>
        /// Make sure a value of the map is compliant
        /// </summary>
        /// <param name="matchesNb"></param>
        private void MakeMapCompliant(int matchesNb)
        {
            Dictionary<int, int> valueByActionDict = this.ValuesMapByMatchesNb[matchesNb];
            
            // make sure no action is lower than 0
            for (int i = 0; i < valueByActionDict.Count; i++)
            {
                KeyValuePair<int, int> actionValuePair = valueByActionDict.ElementAt(i);
                if (actionValuePair.Value < 0)
                {
                    valueByActionDict[actionValuePair.Key] = 0;
                }
            }

            // if all the actions' values are equal to 0
            if (valueByActionDict[1] + valueByActionDict[2] + valueByActionDict[3] == 0)
            {
                valueByActionDict[1] = Policy._DEFAULT_VALUE;
                valueByActionDict[2] = Policy._DEFAULT_VALUE;
                valueByActionDict[3] = Policy._DEFAULT_VALUE;
            }
        }


        public override string ToString()
        {
            // todo implement ToString
            return $"";
        }
    }
}