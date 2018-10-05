using System;
using System.Collections.Generic;
using System.Text;

namespace AncientStirrings.Cards
{
    public class Land : ICard
    {
        public string name { get; }

        public Land(string name)
        {
            this.name = name;
        }

        public State Resolve(State state)
        {
            return state;
        }
    }
}
