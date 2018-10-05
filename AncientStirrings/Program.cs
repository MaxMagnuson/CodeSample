using AncientStirrings.Cards;
using System;
using System.Collections.Generic;

namespace AncientStirrings
{
    public class Program
    {
        private const double Iterations = 100000;
        private const bool onPlay = true;
        private const int GreenSources = 15;
        private const int LandCount = 22;

        public static void Main(string[] args)
        {
            Random rand = new Random();

            List<ICard> deck = new List<ICard>();
            for(int i = 0; i < GreenSources; i++)
            {
                deck.Add(new Land(Constants.Cards.GreenSource));
            }
            for(int i = 0; i < LandCount - GreenSources; i++)
            {
                deck.Add(new Land(Constants.Cards.NonGreenSource));
            }
            for(int i = 0; i < 4; i++)
            {
                deck.Add(new EnsnaringBridge());
                //deck.Add(new AncientStirring());
            }
            for(int i = 0; i < 4; i++)
            {
                deck.Add(new AncientStirring());
            }
            int cardsLeft = 60 - deck.Count;
            for(int i = 0; i < cardsLeft; i++)
            {
                deck.Add(new Filler());
            }

            Library testLib = new Library(rand, deck);
            testLib.Shuffle();

            State state = new State(testLib);

            double successes = 0.0;

            for(int i = 0; i < Iterations; i++)
            {
                Console.WriteLine("Running Iteration {0}", i);
                state.OpeningHand();
                while(state.ShouldMulligan() && state.Hand.Count > 5)
                {
                    state.Mulligan();
                }

                //state.PrintHand();

                for(int turn = 0; turn < 3; turn++)
                {
                    if(turn!=0 || !onPlay)
                    {
                        state.Draw();
                    }
                    
                    state.PlayLand();

                    foreach(ICard card in state.GreenSources)
                    {
                        if(state.Hand.ContainsName(Constants.Cards.AncientStirrings))
                        {
                            ICard stirrings = state.Hand.FindCard(Constants.Cards.AncientStirrings);
                            stirrings.Resolve(state);
                            state.Hand.RemoveCard(Constants.Cards.AncientStirrings);
                        }
                    }
                }

                if(state.Hand.ContainsName(Constants.Cards.EnsnaringBridge) && ((state.GreenSources.Count + state.NonGreenSources.Count) == 3))
                {
                    successes++;
                }
            }

            Console.WriteLine("Ensnaring Bridge was found {0} percent of games.", successes / Iterations);

            Console.ReadLine();
        }
    }
}
