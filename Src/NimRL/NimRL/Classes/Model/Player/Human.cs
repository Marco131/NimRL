using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NimRL.Classes.Model.Player
{
    public class Human : Player
    {
        // Constants
        public const string NAME = "Human";
        private const PlayerType _TYPE = PlayerType.Human;


        // Ctor
        public Human() : base(Human._TYPE) {}


        // Methods
        /// <summary>
        /// Gets the name of the class
        /// </summary>
        /// <returns>Name of the class</returns>
        public override string GetName()
        {
            return Human.NAME;
        }
    }
}
