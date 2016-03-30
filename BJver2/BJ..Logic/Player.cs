using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    public class Player : User
    {
        public List<Card> PlayerHand;
        public List<Card> SplittHand;
        public int balance { get; set; }
        public Player()
        {
            this.balance = 100;
            this.PlayerHand = new List<Card>();
            this.SplittHand = new List<Card>();
        }
        public override string GetCardText()
        {
            string outPut = "";
            int nr = 1;
            foreach (var item in PlayerHand)
            {
                outPut += $"Card {nr}:{item.Type}  {item._Color}  {item._Value}{Environment.NewLine}";
                nr++;
            }

            return outPut;
        }
        public override List<Card> GetHand()
        {
            return PlayerHand;
        }
        public Card GetCard(int index)
        {
            return PlayerHand[index];
        }
        /// <summary>
        /// Adds a card to player hand
        /// </summary>
        /// <param name="newCard"></param>
        public void GetCard(Card newCard)
        {
            PlayerHand.Add(newCard);
        }
        //public bool Pass() 
        //{
        //    return true;
        //}
        /// <summary>
        /// Asks for a bet from user- and returns it
        /// </summary>
        /// <returns>int bet</returns>
        public bool Bet(int bet, Player player)
        {
            if (bet < 0) { return false; }
            if (bet > player.balance) { return false; }


            return true;
        }
        /// <summary>
        /// Retuns palyers cards on hand
        /// </summary>
        /// <returns></returns>
        public List<Card> ShowPlayerHand()
        {
            return PlayerHand;
        }
        /// <summary>
        /// Counts the number of cards there is in the list
        /// </summary>
        /// <returns>int</returns>
        public int numberOfCards()
        {
            int number = 0;
            foreach (var item in PlayerHand)
            {
                number++;
            }
            return number;
        }
        /// <summary>
        /// Removing cards from player hand
        /// </summary>
        public void ClearHand()
        {
            PlayerHand.Clear();
            SplittHand.Clear();
        }
        public bool HitMe(Player player, Dealer dealer ,List<Card> Hand)
        {
            Hand.Add(dealer.GiveCard());
  

            if (Rules.NotOver21(StaticMethods.CountValue(Hand)))
            {
                return true;
            }
            return false;
        }   
    }
}
