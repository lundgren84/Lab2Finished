using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    public class Dealer : User
    {
        List<Card> ActiveDeck;
       public List<Card> DealerHand;
        public Dealer()
        {

            this.ActiveDeck = new List<Card>();
            this.DealerHand = new List<Card>();
        }
        public override string GetCardText( )
        {
            int nr = 1;
            string outPut = "";

            foreach (var item in DealerHand)
            {
                outPut += $"Card {nr}:{item.Type}  {item._Color}  {item._Value}{Environment.NewLine}";
                nr++;
            }
            return outPut;
        }
        public override List<Card> GetHand()
        {
            return DealerHand;
        }
        /// <summary>
        /// Count the number from cards in a ListOfCards
        /// </summary>
        /// <returns>int total value</returns>
        public int CountCardsInActiveDeck()
        {
            int count = ActiveDeck.Count;
            return count;
        }
        /// <summary>
        /// Check number of cards in active deck and fixes it
        /// </summary>
        /// <param name="deck"></param>
        public void CheckActiveDeck(Deck deck)
        {
            if (CountCardsInActiveDeck() < 53)   // Checking if dealer have more then 53 cards in deck
            {
                ActiveDeck.Clear();
                var x = 0;
                while (x < 2) // Give Dealer 2 deck of cards and shuffle them
                {
                    PutNewDeckToActiveDeck(deck.GiveDeck());
                    ShuffleActiveDeck();
                    x++;
                }
            }
        }
        /// <summary>
        /// Returns a sorted deck with 53 cards
        /// </summary>
        /// <param name="deck"></param>
        public void PutNewDeckToActiveDeck(List<Card> deck)
        {
            foreach (var item in deck)
            {
                ActiveDeck.Add(item);
            }
        }
        public void DealerGetAllHisCards(Player player, Dealer dealer, int bet, bool Splitt)
        {
            bool gogo = true;
            while (gogo)
            {
                if (StaticMethods.CountValue(ShowDealerHand()) > 16)
                { gogo = false; }
                else if (StaticMethods.CountAceValue(ShowDealerHand()) > 16 && StaticMethods.CountAceValue(ShowDealerHand()) < 22 &&
                                          StaticMethods.CountAceValue(ShowDealerHand()) > StaticMethods.CountValue(player.PlayerHand))
                { gogo = false; }
                else if (StaticMethods.CountValue(ShowDealerHand()) > 16 && StaticMethods.CountAceValue(ShowDealerHand()) > 16)
                { gogo = false; }

                else
                {
                    GetCardToDealer();

                }

            }
        }
        public void GiveCards(Player player, Dealer dealer)
        {
            player.PlayerHand.Clear();
            dealer.DealerHand.Clear();

            dealer.GetCardToDealer();
         
            player.GetCard(dealer.GiveCard());
            player.GetCard(dealer.GiveCard());
        }
        /// <summary>
        /// Gives a card from Dealers Active deck and removes it from deck
        /// </summary>
        /// <returns>Card</returns>
        public Card GiveCard()
        {

            Card card = new Card();
            card = ActiveDeck[0];
            ActiveDeck.RemoveAt(0);
            return card;
        }
        /// <summary>
        /// Shuffles Active deck 10000 times
        /// </summary>
        public void ShuffleActiveDeck()
        {
            Random random = new Random();
            Card cardHolder = new Card();

            for (int x = 0; x < 10000; x++)
            {
                int PointCardX = random.Next(ActiveDeck.Count - 1);
                int PointCardY = random.Next(ActiveDeck.Count - 1);

                cardHolder = ActiveDeck[PointCardX];
                ActiveDeck[PointCardX] = ActiveDeck[PointCardY];
                ActiveDeck[PointCardY] = cardHolder;
            }
        }
       
        /// <summary>
        /// Dealer give card to him self and removes it from active deck
        /// </summary>
        public void GetCardToDealer()
        {
            DealerHand.Add(GiveCard());
        }
        /// <summary>
        /// Gives Dealers cards on hand
        /// </summary>
        /// <returns>List with cards</returns>
        public List<Card> ShowDealerHand()
        {
            return DealerHand;
        }
        /// <summary>
        /// Removes cards from hand
        /// </summary>
        public void ClearHand()
        {
            DealerHand.RemoveRange(0, DealerHand.Count);
        }
        /// <summary>
        /// Returns dealers Active deck
        /// </summary>
        /// <returns></returns>
        public List<Card> GiveActiveDeck()
        {
            return ActiveDeck;
        }
        public void SplittPlayerCards(Player player)
        {
            player.SplittHand.Add(player.PlayerHand[0]);
            player.PlayerHand.RemoveAt(0);

        }
    }
}
