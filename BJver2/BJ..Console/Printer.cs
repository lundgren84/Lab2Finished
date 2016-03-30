
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    static class Printer
    {
        /// <summary>
        /// Prints The cars atributes in one list
        /// </summary>
        /// <param name="CardList"></param>
        public static void PrintCardHand(List<Card> CardList)
        {
            Console.WriteLine("---------------------------------------");
            int CardNr = 1;
            foreach (var item in CardList)
            {
                if (item.Type == "Ace") { Console.Write("Card nr:" + CardNr + "    " + item._Color + " of " + item.Type + " - " + item._Value + " or " + item._AceValue + "\n"); }
                else { Console.Write("Card nr:" + CardNr + "    " + item._Color + " of " + item.Type + " - " + item._Value + "\n"); }

                CardNr++;
            }
        }
        internal static int AskBet(Player player)
        {
            int bet = 0;
            while (true)
            {                    
                Console.WriteLine($"Saldo:{player.balance}");
                Console.WriteLine("How mutch you wanna bet?");
                int.TryParse(Console.ReadLine(), out bet);
                if (bet > player.balance)
                {
                    Console.Clear();
                    LOGG();       
                    Console.WriteLine("You dont have so mutch CASH!!\nTry agan. . .\n");
                }            
                else if(bet == 0)
                {
                    Console.Clear();
                    LOGG();
                    Console.WriteLine("I dont understand you!\nTry again. . .\n");
                }
                else if (bet > 0)
                {
                    return bet;
                }
            }        
        }
        /// <summary>
        /// Prints totalvalue on cards of one list
        /// </summary>
        /// <param name="CardList"></param>
        public static void PrintTotalValue(List<Card> CardList)
        {

            int TotalValue = StaticMethods.CountValue(CardList);
            int TotalAceValue = StaticMethods.CountAceValue(CardList);
            Console.WriteLine("---------------------------------------");
            if (TotalAceValue == TotalValue)
            {
                Console.Write("Total value of the cards: " + TotalValue);
            }
            else
            {
                Console.Write("Total value of the cards: " + TotalValue + " or " + TotalAceValue);
            }
        }
        /// <summary>
        /// Prints BLACK JACK loggotype
        /// </summary>
        public static void LOGG()
        {


            Console.WriteLine(".------..-------..------..------..------.     .-------..------..------..------.");
            Console.WriteLine("| B    || L     || A    || C    || K    |     | J     || A    || C    || K    |");
            Console.WriteLine("|  ()  ||  /\\   ||  \\/  ||  /\\  || /\\   | --- |  ()   ||  \\/  ||  /\\  ||  /\\  |");
            Console.WriteLine("| ()() || (__)  ||  \\/  ||  \\/  || \\/   | --- | ()()  ||  \\/  ||  \\/  ||  \\/  |");
            Console.WriteLine("|     B||     L ||    A ||    C ||    K |     |     J ||    A ||     C||    K |");
            Console.WriteLine(" `-----' `------'`------' `-----' `-----'      `------' `-----' `-----' `-----'");



        }
        internal static void PressForNextCard()
        {
            Console.WriteLine("Press a key to see next card");
            Console.ReadKey();
            Console.Clear();

        }
        /// <summary>
        /// Prints the game
        /// </summary>
        /// <param name="Player"></param>
        /// <param name="Dealer"></param>
        /// <param name="bet"></param>
        /// <param name="PlayerBalance"></param>
        public static void PrintGame(List<Card> PlayerList, List<Card> Dealer, int bet, int PlayerBalance,bool Splitt,Player player)
        {
            Console.Clear();
            LOGG();
            Console.WriteLine("        D e a l e r   H a n d");
            Printer.PrintCardHand(Dealer);
            Printer.PrintTotalValue(Dealer);
            Console.WriteLine("\n");
            Console.WriteLine("        P l a y e r   H a n d");
            Console.WriteLine("        $$ " + PlayerBalance + " $$ Bet :" + bet + " $$");
            Printer.PrintCardHand(PlayerList);
            Printer.PrintTotalValue(PlayerList);
            Console.Write("\n");
            if (Splitt)
            {
                Console.WriteLine("\n\n        S p l i t t   H a n d");            
                Printer.PrintCardHand(player.SplittHand);
                Printer.PrintTotalValue(player.SplittHand);
            }
            Console.WriteLine("\n\n");
           
        }
        internal static void ToLittleCashToSplitt()
        {
            Console.WriteLine("You dont afford to splitt your cards. . .\nPress a key to continue . . .");
            Console.ReadKey();
        }
        /// <summary>
        /// Prints a list with all cards
        /// </summary>
        /// <param name="cardList"></param>
        public static void PrintADeck(List<Card> cardList)
        {
            int x = 1;

            foreach (var item in cardList)
            {
                if (item.Type == "Ace") { Console.Write($"Card:{x} - {item._Value} or {item._AceValue} - {item.Type} - {item._Color}"); }
                else
                {
                    Console.Write($"Card:{x} - {item._Value} - {item.Type} - {item._Color}");
                }
                Console.WriteLine("");
                x++;
            }
        }    
        public static bool AskSplitt(Dealer dealer,Player player)
        {

            Console.ForegroundColor = ConsoleColor.Blue;   Console.WriteLine("Do you wanna splitt your card?  y/n"); Console.ForegroundColor = ConsoleColor.White;
            ConsoleKeyInfo key;
                key = Console.ReadKey(true);
                switch(key.KeyChar)
                {
                    case 'y':
                    return true;                     
                    case 'n':
                    return false;                     
                    default:
                    return false;                     
                }
            
        }
        public static void EndMsg(List<Card> PlayerList, List<Card> Dealer, int bet, int PlayerBalance, bool Splitt, Player player,bool win,bool winSplit)
        {
            Console.Clear();
            LOGG();
            if (!win) { Console.ForegroundColor = ConsoleColor.Yellow; }
            Console.Write("        D e a l e r   H a n d");    
            Console.WriteLine();
            Printer.PrintCardHand(Dealer);
            Printer.PrintTotalValue(Dealer);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n");

            if (win) { Console.ForegroundColor = ConsoleColor.Yellow; }
            Console.Write("        P l a y e r   H a n d");  
            Console.WriteLine();
            Console.WriteLine("        $$ " + PlayerBalance + " $$ Bet :" + bet + " $$");
            Printer.PrintCardHand(PlayerList);
            Printer.PrintTotalValue(PlayerList);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\n\n");

            
            if (Splitt)
            {
                if (winSplit) { Console.ForegroundColor = ConsoleColor.Yellow; }
                Console.Write("\n\n        S p l i t t   H a n d"); 
                Console.WriteLine();
                Printer.PrintCardHand(player.SplittHand);
                Printer.PrintTotalValue(player.SplittHand);
                Console.ForegroundColor = ConsoleColor.White;
            }
           
            Console.ReadKey();
        }
        public static void GameOver()
        {
            Console.WriteLine("You are out of cash. . . GAMEOVER casino WIN!!");
            Console.ReadKey();
            Console.Clear();
        }
        public static void HitMePrint(Player player,Dealer dealer,bool split,int bet)
        {
            bool go = true;
            bool go2 = split;   
                 
            while (go || go2)
            {
                if (go)
                {

                    Console.WriteLine("Want a new card? y/n");
                    ConsoleKeyInfo key;
                    key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case 'y':
                            go = player.HitMe(player, dealer,player.PlayerHand); // Gives a card and returns if true if total value is under 21
                            PrintGame(player.PlayerHand, dealer.DealerHand, bet, player.balance, split, player); // refresh game
                            break;
                        case 'n':
                            go = false;
                            break;
                        default:
                            break;
                    }
                }
                if(go2)
                {
                    Console.WriteLine("Want a new card? y/n");
                    ConsoleKeyInfo key;
                    key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case 'y':
                            go = player.HitMe(player, dealer,player.SplittHand); // Gives a card and returns if true if total value is under 21
                            PrintGame(player.PlayerHand, dealer.DealerHand, bet, player.balance, split, player); // refresh game
                            break;
                        case 'n':
                            go2 = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
