using System;
using System.Collections.Generic;
using System.Text;

namespace AncientStirrings.Cards
{
    public class EnsnaringBridge : ICard
    {
        public string name { get; }

        public EnsnaringBridge()
        {
            this.name = Constants.Cards.EnsnaringBridge;
        }

        public State Resolve(State state)
        {
            return state;
        }
    }
}
