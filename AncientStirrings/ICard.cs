using System;
using System.Collections.Generic;
using System.Text;

namespace AncientStirrings
{
    public interface ICard
    {
        string name { get; }
        State Resolve(State state);
    }
}
