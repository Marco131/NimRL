using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NimRL.Classes.Model.Player;
using NimRL.Classes.Model.AI;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.Serialization;

namespace NimRL.Classes.Controller
{
    public class AIController
    {
        // Constants
        private static readonly List<int> _OPTIMIZED_CHOICES = new List<int>()
        {
            0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3
        };

        // Fields
        private Agent _agent;

        private Action _updateAIDisplay;


        // Properties
        public Agent Agent { get => _agent; private set => _agent = value; }
        private Action _UpdateAIDisplay { get => _updateAIDisplay; set => _updateAIDisplay = value; }


        // Ctor
        public AIController(Action UpdateAIDisplay)
        {
            this.Agent = new Agent();

            this._UpdateAIDisplay = UpdateAIDisplay;
        }

        public AIController() {}


        // Methods
        public Dictionary<int, Dictionary<int, int>> GetActionValues()
        {
            return this.Agent.GetValuesMapByMatchesNb();
        }

        public float CalculateLearningPercentage()
        {
            const int INDIFERENT_CHOICE = 0;
            const int IMPORTANT_CHOICES_NB = GameController.INITIAL_MATCHES_NB - (GameController.INITIAL_MATCHES_NB / 4);

            float percentageSum = 0;
            Dictionary<int, Dictionary<int, int>> valuesMapByMatchesNb = this.Agent.GetValuesMapByMatchesNb();
            for (int i = GameController.INITIAL_MATCHES_NB; i >= 1; i--)
            {
                if (valuesMapByMatchesNb.ContainsKey(i))
                {
                    Dictionary<int, int> valueByActionDict = valuesMapByMatchesNb[i];

                    int optimizedAction = AIController._OPTIMIZED_CHOICES[i-1];
                    if (optimizedAction != INDIFERENT_CHOICE)
                    {
                        // find highest valued action and it's percentage
                        KeyValuePair<int, int> highestValuedAction = valueByActionDict.ElementAt(0);
                        for (int j = 1; j < valueByActionDict.Count; j++)
                        {
                            KeyValuePair<int, int> currentAction = valueByActionDict.ElementAt(j);
                            if (currentAction.Value > highestValuedAction.Value)
                            {
                                highestValuedAction = currentAction;
                            }
                        }

                        float highestValuedActionPercentage =  (float)highestValuedAction.Value / valueByActionDict.Values.Sum();

                        percentageSum += highestValuedActionPercentage;
                    }
                }
            }

            return percentageSum / IMPORTANT_CHOICES_NB;
        }

        /// <summary>
        /// Calls the agent to give reinforcement for the actions of a round
        /// </summary>
        /// <param name="loserActions">List of actions from the player that lost</param>
        /// <param name="winnerActions">List of actions from the player that won</param>
        public void RequestReinforcementUpdate(int[] loserActions, int[] winnerActions)
        {
            this.Agent.GiveReinforcement(loserActions, winnerActions);

            this._UpdateAIDisplay();
        }
    }
}
