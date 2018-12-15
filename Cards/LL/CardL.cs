using SO;
using System.Collections.Generic;
using static PL.CardP;

namespace LL
{
    public static class CardL
    {
        public static IEnumerable<Card> ListCards()
        {
            foreach (Card c in ListDeb())
                yield return c;
            foreach (Card c in ListCred())
                yield return c;
        }
    }
}