using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimRL.Classes.Model.Player
{
    public class Human : Player
    {
        // Constants
        private const string _NAME = "Human";
        private const PlayerType _TYPE = PlayerType.Human;


        // Ctor
        public Human() : base(Human._TYPE) {}


        // Methods
        /// <summary>
        /// Updates last chosen action and adds it to the list
        /// </summary>
        /// <param name="action">new last chosen action</param>
        public void UpdateLastChosenAction(int action)
        {
            this.LastChosenAction = action;

            AddActionToList();
        }

        public override string GetName()
        {
            return Human._NAME;
        }
    }
}
