using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    public class GameFlow
    {
        Deck deck = new Deck();
        Player player = new Player();
        Dealer dealer = new Dealer();
        bool gameOver = false;
        bool win = true;



        public GameFlow()
        { }
        /// <summary>
        /// Progess of the game - From start to end;
        /// </summary>
        public bool RunGame()
        {
            int DealerValue = 0;
            int DealerAceValue = 0;
            int playerValue = 0;
            int PlayerAceValue = 0;
            int SplitValue = 0;
            int SplitAceValue = 0;
            bool winSplit = false;
            bool split = false;
            bool IWantSplit = false;

            Console.Clear();
            dealer.CheckActiveDeck(deck);
            Printer.LOGG();
            int bet = Printer.AskBet(player); // Get player bet
            dealer.GiveCards(player, dealer); // Clear hands and give start cards
            #region SplittTest
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // int y = 1;   ///////////////////////////////////////////// TRY SPLITT /////////////////////////////////////////////////////
            // int x = 1;  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // string CardType = StaticMethods.GetType(x);  //////////////////////////////////////////////////////////////////////////////
            // player.GetCard(new Card(value: 10, aceValue: 10, color: StaticMethods.ReturnType(y), type: CardType));/////////////////////
            //player.GetCard(new Card(value: 10, aceValue: 10, color: StaticMethods.ReturnType(y), type: CardType));/////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            #endregion
            Printer.PrintGame(player.ShowPlayerHand(), dealer.ShowDealerHand(), bet, player.balance, split, player);
            split = Rules.SplittPosible(player.ShowPlayerHand(), player, bet);
            if (split)
            {
                IWantSplit = Printer.AskSplitt(dealer, player);
            }
            if (IWantSplit)
            {
                dealer.SplittPlayerCards(player);
                {
                    //    player.HitMeSplitt(player, dealer, bet, split);
                }
            }
            else
            {
                Printer.HitMePrint(player, dealer, split, bet); // Give all players card
            }
            if (Rules.NotOver21(StaticMethods.CountValue(player.ShowPlayerHand())))
            {
                Printer.PrintGame(player.ShowPlayerHand(), dealer.ShowDealerHand(), bet, player.balance, split, player);
                dealer.DealerGetAllHisCards(player, dealer, bet, split); // Give dealer all his cards

                if (Rules.NotOver21(StaticMethods.CountValue(dealer.ShowDealerHand())) || Rules.NotOver21(StaticMethods.CountAceValue(dealer.ShowDealerHand())))
                {
                    DealerValue = StaticMethods.CountValue(dealer.ShowDealerHand());
                    DealerAceValue = StaticMethods.CountAceValue(dealer.ShowDealerHand());
                    playerValue = StaticMethods.CountValue(player.ShowPlayerHand());
                    PlayerAceValue = StaticMethods.CountAceValue(player.ShowPlayerHand());
                    if (IWantSplit)
                    {
                        SplitValue = StaticMethods.CountValue(player.SplittHand);
                        SplitAceValue = StaticMethods.CountAceValue(player.SplittHand);
                    }
                    int PlayerwinValue = Rules.SetWinValue(PlayerAceValue, playerValue, player);
                    int SplitwinValue = 0;
                    int DealerwinValue = Rules.SetWinValue(DealerAceValue, DealerValue, dealer);

                    if (SplitAceValue < 22) { SplitwinValue = SplitAceValue; } else if (SplitValue < 22) { SplitwinValue = SplitValue; } else { SplitwinValue = 0; }

                    win = Rules.PlayerWin(PlayerwinValue, DealerwinValue);
                    if (IWantSplit)
                    {
                        winSplit = Rules.PlayerWin(SplitwinValue, DealerwinValue);
                    }
                }
                else
                {
                    win = true;
                    if (IWantSplit)
                    {
                        if (SplitValue < 22) { winSplit = true; }
                    }
                }
            }
            else { win = false; }

            Rules.WinManager(win, winSplit, bet, player, IWantSplit);
            Printer.EndMsg(player.ShowPlayerHand(), dealer.ShowDealerHand(), bet, player.balance, split, player, win, winSplit);

            if (player.balance < 1) { gameOver = true; Printer.GameOver(); }
            return gameOver;
        }
    }
}



