using AncientStirrings.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace AncientStirrings
{
    public static class ListExtension
    {
        public static bool ContainsName(this List<ICard> group, string cardName)
        {
            for (int i = 0; i < group.Count; i++)
            {
                if (String.Equals(group[i].name, cardName))
                {
                    return true;
                }
            }
            return false;
        }

        public static ICard FindCard(this List<ICard> group, string cardName)
        {
            for(int i = 0; i < group.Count; i++)
            {
                if (String.Equals(group[i].name, cardName))
                {
                    return group[i];
                }
            }
            return null;
        }

        public static ICard RemoveCard(this List<ICard> group, string cardName)
        {
            ICard removedCard = null;
            for (int i = 0; i < group.Count; i++)
            {
                if (String.Equals(group[i].name, cardName))
                {
                    removedCard = group[i];
                    group.RemoveAt(i);
                    return removedCard;
                }
            }
            return removedCard;
        }

        public static int ContainsXLands(this List<ICard> group)
        {
            int total = 0;
            for(int i = 0; i < group.Count; i++)
            {
                ICard card = group[i];
                if (card is Land)
                {
                    total++;
                }
            }

            return total;
        }
    }
}
