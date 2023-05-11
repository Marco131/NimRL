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
        public int RoundsNb { get => _roundsNb; private set => _roundsNb = value; }
        private Policy _Policy { get => _policy; set => _policy = value; }


        // Ctor
        public Agent()
        {
            this.RoundsNb = Agent._INITIAL_ROUNDS_NB;

            this._Policy = new Policy();
        }


        // Methods
        /// <summary>
        /// Get an action from the policy
        /// </summary>
        /// <param name="matchesNb"></param>
        /// <returns>Action</returns>
        public int GetAction(int matchesNb)
        {
            int action = this._Policy.GetAction(matchesNb);
            return action;
        }
        
        public int[] GetBestActions()
        {
            // todo implement GetBestActions
            return new int[2];
        }

        public Dictionary<int, Dictionary<int, int>> GetValuesMapByMatchesNb()
        {
            return this._Policy.ValuesMapByMatchesNb;
        }

        /// <summary>
        /// Give a reinforcement to the actions of a game
        /// </summary>
        /// <param name="loserActions">Action of the player that lost</param>
        /// <param name="winnerActions">Action of the player that won</param>
        public void GiveReinforcement(int[] loserActions, int[] winnerActions)
        {
            List<int> loserActionsList = loserActions.ToList();
            List<int> winnerActionsList = winnerActions.ToList();

            // simulate the game in reverse to give reinforcement to each action
            int simulatedMatchesNb = 0;
            bool isLosersTurn = true;
            while (loserActionsList.Count + winnerActionsList.Count > 0)
            {
                int action;
                int lastIndex;
                if (isLosersTurn)
                {
                    lastIndex = loserActionsList.Count - 1;

                    // get their last action then remove it from the list
                    action = loserActionsList[lastIndex];
                    loserActionsList.RemoveAt(lastIndex);
                }
                else // is winners turn
                {
                    lastIndex = winnerActionsList.Count - 1;

                    // get their last action then remove it from the list
                    action = winnerActionsList[lastIndex];
                    winnerActionsList.RemoveAt(lastIndex);
                }

                simulatedMatchesNb += action;
                this._Policy.UpdateValue(simulatedMatchesNb, action, !isLosersTurn);

                // switch turns
                isLosersTurn = !isLosersTurn;
            }

            this.RoundsNb += 1;
        }
    }
}
