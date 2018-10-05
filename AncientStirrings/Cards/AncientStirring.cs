using System;
using System.Collections.Generic;
using System.Text;

namespace AncientStirrings.Cards
{
    public class AncientStirring : ICard
    {
        public string name { get; }

        public AncientStirring()
        {
            this.name = Constants.Cards.AncientStirrings;
        }

        public State Resolve(State state)
        {
            Library library = state.Library;
            List<ICard> stirrings = new List<ICard>();
            for(int i = 0; i < 5; i++)
            {
                stirrings.Add(library.Draw());
            }
            //Functionality for Lantern Control
            if(stirrings.ContainsName(Constants.Cards.EnsnaringBridge))
            {
                state.Hand.Add(stirrings.FindCard(Constants.Cards.EnsnaringBridge));
            }
            else if (stirrings.ContainsName(Constants.Cards.GreenSource))
            {
                state.Hand.Add(stirrings.FindCard(Constants.Cards.GreenSource));
            }
            else if (stirrings.ContainsName(Constants.Cards.NonGreenSource))
            {
                state.Hand.Add(stirrings.FindCard(Constants.Cards.NonGreenSource));
            }
            else
            {
                state.Hand.Add(new Filler());
            }

            return state;
        }
    }
}
