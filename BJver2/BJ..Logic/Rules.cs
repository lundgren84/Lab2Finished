using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    public static class Rules
    {
        /// <summary>
        /// Check if player can get another card
        /// </summary>
        /// <param name="totalValueCar"></param>
        /// <returns></returns>
        public static bool GiveDealerCard(int totalValueCar)
        {
            if (totalValueCar < 17 ) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Check if Black Jack
        /// </summary>
        /// <param name="totalvaluecard"></param>
        /// <returns></returns>
        public static bool BlackJack(int totalvaluecard)
        {
            bool check = false;

            if (totalvaluecard == 21) { check = true; }
            return check;
        }

        /// <summary>
        /// Check if total cards points are over 21
        /// </summary>
        /// <param name="playerValue"></param>
        /// <param name="dealerValue"></param>
        /// <returns></returns>
        public static bool NotOver21(int totalvaluecard)
        {
            if (totalvaluecard < 22)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compare total amount of points and return who is the winner
        /// </summary>
        /// <param name="playerValue"></param>
        /// <param name="dealerValue"></param>
        /// <returns></returns>
        public static bool PlayerWin(int playerValue, int dealerValue)
        {

            if (playerValue > dealerValue) { return true; }
            else { return false; }

        }

        public static void WinManager(bool Win, bool WinSplit, int bet, Player player, bool split)
        {
            if (split)
            {
                if (WinSplit) { player.balance += bet; }
                else { player.balance -= bet; }
            }

            if (Win) { player.balance += bet; }
            else { player.balance -= bet; }
        }
        public static bool SplittPosible(List<Card> Input, Player player, int bet)
        {
            if (Input[0]._Value == Input[1]._Value && bet * 2 > player.balance)
            {
               
                return false;
            }
            if (Input[0]._Value == Input[1]._Value && bet * 2 < player.balance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int SetWinValue(int UserAceValue, int UserValue,User player)
        {
            int UserwinValue = 0;

            UserAceValue = StaticMethods.CountAceValue(player.GetHand());        
            UserValue = StaticMethods.CountValue(player.GetHand());
                      
            if (UserAceValue < 22) { UserwinValue = UserAceValue; } else if (UserValue < 22) { UserwinValue = UserValue; } else { UserwinValue = 0; }
            return UserwinValue;
        }
        public static int GetBestValue(int UserAceValue, int UserValue, User player)
        {
            int UserwinValue = 0;

            UserAceValue = StaticMethods.CountAceValue(player.GetHand());
            UserValue = StaticMethods.CountValue(player.GetHand());

            if (UserAceValue < 22) { UserwinValue = UserAceValue; } else  { UserwinValue = UserValue; }
            return UserwinValue;
        }
    }
}
