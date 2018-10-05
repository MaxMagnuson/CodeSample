using System;
using System.Collections.Generic;
using System.Text;

namespace AncientStirrings.Cards
{
    public class Filler : ICard
    {
        public string name { get; }

        public Filler()
        {
            this.name = Constants.Cards.Filler;
        }

        public State Resolve(State state)
        {
            return state;
        }
    }
}
