using System;
using System.Collections.Generic;
using System.Text;

namespace AncientStirrings
{
    public class State
    {
        public List<ICard> Hand { get; private set; }
        public Library Library { get; private set; }
        public List<ICard> GreenSources { get; private set; }
        public List<ICard> NonGreenSources { get; private set; }

        public State(Library library)
        {
            this.Library = library;
            this.Hand = new List<ICard>();
            this.GreenSources = new List<ICard>();
            this.NonGreenSources = new List<ICard>();
        }

        public void Mulligan()
        {
            int handSize = Hand.Count;
            Library.Shuffle();
            Hand = new List<ICard>();
            for (int i = 0; i < handSize-1; i++)
            {
                Draw();
            }
        }

        public bool ShouldMulligan()
        {
            int lands = Hand.ContainsXLands();
            return lands > 5 || lands < 2;
        }

        public void PlayLand()
        {
            if(Hand.ContainsName(Constants.Cards.GreenSource))
            {
                GreenSources.Add(Hand.RemoveCard(Constants.Cards.GreenSource));
                //Console.WriteLine("Played green land");
            }
            else if(Hand.ContainsName(Constants.Cards.NonGreenSource))
            {
                NonGreenSources.Add(Hand.RemoveCard(Constants.Cards.NonGreenSource));
                //Console.WriteLine("Played non-green land");
            }
        }

        public void OpeningHand()
        {
            Library.Shuffle();
            this.GreenSources = new List<ICard>();
            this.NonGreenSources = new List<ICard>();
            this.Hand = new List<ICard>();
            for(int i = 0; i < 7; i++)
            {
                Draw();
            }
        }

        public void Draw()
        {
            this.Hand.Add(this.Library.Draw());
        }

        public void PrintHand()
        {
            foreach (var card in Hand)
            {
                Console.Write("{0}, ", card.name);
            }
            Console.WriteLine();
        }
    }
}
