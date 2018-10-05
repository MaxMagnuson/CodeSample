using System;
using System.Collections.Generic;
using System.Text;

namespace AncientStirrings
{
    public class Library
    {
        private Random rand;
        private List<ICard> deck;
        private List<ICard> currentDeck;

        public Library(Random rand, List<ICard> deck)
        {
            this.rand = rand;
            this.deck = deck;
        }

        public int CardsInLibrary()
        {
            return this.currentDeck.Count;
        }

        public ICard Draw()
        {
            ICard draw = this.currentDeck[0];
            this.currentDeck.RemoveAt(0);
            return draw;
        }

        public void Shuffle()
        {
            List<ICard> shuffledDeck = new List<ICard>();
            int tempIndex = deck.Count;
            while (tempIndex > 0)
            {
                int randIndex = rand.Next(tempIndex);
                tempIndex--;
                shuffledDeck.Add(this.deck[randIndex]);
                //Swap Cards
                ICard temp = this.deck[randIndex];
                this.deck[randIndex] = this.deck[tempIndex];
                this.deck[tempIndex] = temp;
            }
            this.currentDeck = shuffledDeck;
        }

        private void PrintList(List<ICard> deckList)
        {
            for(int i = 0; i < deckList.Count; i++)
            {
                Console.Write("{0}, ", deckList[i].name);
            }
            Console.WriteLine();
        }
    }
}
