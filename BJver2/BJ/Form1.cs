using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BJ
{
    public partial class Form1 : Form
    {

        Deck deck = new Deck();
        Player player = new Player();
        Dealer dealer = new Dealer();
        int bet = 0;
        bool running = false;
        bool validBet = false;



        int PlayerCardValue = 0;
        int PlayerCardAceValue = 0;
        int PlayerWinValue = 0;

        int DealerCardValue = 0;
        int DealerCardAceValue = 0;
        int DealerWinValue = 0;



        public Form1()
        {
            //BackgroundImage = Properties.Resources.BlackJack_image4;
            InitializeComponent();
            players.Font = new Font("", 25);
            players2.Font = new Font("", 25);
            label1.Font = new Font("", 80);
            label2.Font = new Font("", 80);
            Player1.Font = new Font("", 15);
            Player2.Font = new Font("", 15);
            Player3.Font = new Font("", 15);

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;



        }
        private void Form1_Load(object sender, EventArgs e)
        {

            _textBoxPlayerPoints.Text = "0";
            textBoxWallet.Text = player.balance.ToString();
            dealer.CheckActiveDeck(deck);





        }
        /// <summary>
        /// Gets a valid bet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _betButton_Click(object sender, EventArgs e)
        {
            int.TryParse(_betReadBox.Text, out bet);
            if (bet > player.balance)
            {
                MessageBox.Show("You don't have enough CASH!");
                bet = 0;
                _betReadBox.Text = bet.ToString();
            }
            if (!running && bet > 0 && bet <= player.balance)
            {
                validBet = true;
                dealer.CheckActiveDeck(deck);

                player.balance -= bet;

                textBoxWallet.Text = player.balance.ToString();
                dealer.GiveCards(player, dealer);
                running = true;




                
            }
            Update();
            if (validBet)
            {
                CardDealer2.Image = Properties.Resources.Cardback;
                CardDealer2.Visible = Visible;
            }
        }

        private void getRightPictureBox(List<Card> UsingHand)
        {
            //foreach (var item in UsingHand)
            //{
            //    if (StaticMethods.GetPictCard(item)== "h1") { }
            //}
            if (UsingHand == dealer.DealerHand)
            {
                CardDealer6.Visible = false;
                CardDealer1.Visible = false;
                CardDealer2.Visible = false;
                CardDealer3.Visible = false;
                CardDealer4.Visible = false;
                CardDealer5.Visible = false;
            }
            if(UsingHand == player.PlayerHand)
            {
                CardPlayer6.Visible = false;
                CardPlayer1.Visible = false;
                CardPlayer2.Visible = false;
                CardPlayer3.Visible = false;
                CardPlayer4.Visible = false;
                CardPlayer5.Visible = false;
            }
            

            for (int index = 0; index < UsingHand.Count; index++)
            {
                if (index == 0)
                {
                    if (UsingHand == dealer.DealerHand) { ChangePic(CardDealer1, getRightCardPicture(UsingHand[index])); CardDealer1.Visible = Visible; }
                    else { ChangePic(CardPlayer1, getRightCardPicture(UsingHand[index])); CardPlayer1.Visible = Visible; }
                }

                if (index == 1)
                {
                    if (UsingHand == dealer.DealerHand) { ChangePic(CardDealer2, getRightCardPicture(UsingHand[index])); CardDealer2.Visible = Visible; }
                    else { ChangePic(CardPlayer2, getRightCardPicture(UsingHand[index])); CardPlayer2.Visible = Visible; }
                }
                if (index == 2)
                {

                    if (UsingHand == dealer.DealerHand) { ChangePic(CardDealer3, getRightCardPicture(UsingHand[index]));CardDealer3.Visible = Visible; }
                    else { ChangePic(CardPlayer3, getRightCardPicture(UsingHand[index])); CardPlayer3.Visible = Visible; }
                }
                if (index == 3)
                {
                    if (UsingHand == dealer.DealerHand) { ChangePic(CardDealer4, getRightCardPicture(UsingHand[index])); CardDealer4.Visible = Visible; }
                    else { ChangePic(CardPlayer4, getRightCardPicture(UsingHand[index])); CardPlayer4.Visible = Visible; }
                }
                if (index == 4)
                {
                    if (UsingHand == dealer.DealerHand) { ChangePic(CardDealer5, getRightCardPicture(UsingHand[index])); CardDealer5.Visible = Visible; }
                    else { ChangePic(CardPlayer5, getRightCardPicture(UsingHand[index])); CardPlayer5.Visible = Visible; }
                }
                if (index == 5)
                {
                    if (UsingHand == dealer.DealerHand) { ChangePic(CardDealer6, getRightCardPicture(UsingHand[index])); CardDealer6.Visible = Visible; }
                    else { ChangePic(CardPlayer6, getRightCardPicture(UsingHand[index])); CardPlayer6.Visible = Visible; }
                }


            }

            //Properties.Resources.h1;
        }

        private Bitmap getRightCardPicture(Card input)
        {
            string test = StaticMethods.GetPictCard(input);
            if (test == "h1") { return Properties.Resources.h1; }
            if (test == "h2") { return Properties.Resources.h2; }
            if (test == "h3") { return Properties.Resources.h3; }
            if (test == "h4") { return Properties.Resources.h4; }
            if (test == "h5") { return Properties.Resources.h5; }
            if (test == "h6") { return Properties.Resources.h6; }
            if (test == "h7") { return Properties.Resources.h7; }
            if (test == "h8") { return Properties.Resources.h8; }
            if (test == "h9") { return Properties.Resources.h9; }
            if (test == "h10") { return Properties.Resources.h10; }
            if (test == "h11") { return Properties.Resources.h11; }
            if (test == "h12") { return Properties.Resources.h12; }
            if (test == "h13") { return Properties.Resources.h13; }

            if (test == "d1") { return Properties.Resources.d1; }
            if (test == "d2") { return Properties.Resources.d2; }
            if (test == "d3") { return Properties.Resources.d3; }
            if (test == "d4") { return Properties.Resources.d4; }
            if (test == "d5") { return Properties.Resources.d5; }
            if (test == "d6") { return Properties.Resources.d6; }
            if (test == "d7") { return Properties.Resources.d7; }
            if (test == "d8") { return Properties.Resources.d8; }
            if (test == "d9") { return Properties.Resources.d9; }
            if (test == "d10") { return Properties.Resources.d10; }
            if (test == "d11") { return Properties.Resources.d11; }
            if (test == "d12") { return Properties.Resources.d12; }
            if (test == "d13") { return Properties.Resources.d13; }

            if (test == "s1") { return Properties.Resources.s1; }
            if (test == "s2") { return Properties.Resources.s2; }
            if (test == "s3") { return Properties.Resources.s3; }
            if (test == "s4") { return Properties.Resources.s4; }
            if (test == "s5") { return Properties.Resources.s5; }
            if (test == "s6") { return Properties.Resources.s6; }
            if (test == "s7") { return Properties.Resources.s7; }
            if (test == "s8") { return Properties.Resources.s8; }
            if (test == "s9") { return Properties.Resources.s9; }
            if (test == "s10") { return Properties.Resources.s10; }
            if (test == "s11") { return Properties.Resources.s11; }
            if (test == "s12") { return Properties.Resources.s12; }
            if (test == "s13") { return Properties.Resources.s13; }

            if (test == "c1") { return Properties.Resources.c1; }
            if (test == "c2") { return Properties.Resources.c2; }
            if (test == "c3") { return Properties.Resources.c3; }
            if (test == "c4") { return Properties.Resources.c4; }
            if (test == "c5") { return Properties.Resources.c5; }
            if (test == "c6") { return Properties.Resources.c6; }
            if (test == "c7") { return Properties.Resources.c7; }
            if (test == "c8") { return Properties.Resources.c8; }
            if (test == "c9") { return Properties.Resources.c9; }
            if (test == "c10") { return Properties.Resources.c10; }
            if (test == "c11") { return Properties.Resources.c11; }
            if (test == "c12") { return Properties.Resources.c12; }
            if (test == "c13") { return Properties.Resources.c13; }

            return Properties.Resources.Cardback;
        }

        /// <summary>
        /// QUIT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _exitBotton_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
        /// <summary>
        /// Give player a card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _pickCard_Click(object sender, EventArgs e)
        {
            if (validBet)
            {
                player.GetCard(dealer.GiveCard());
                Update();
                CardDealer2.Image = Properties.Resources.Cardback;
                CardDealer2.Visible = Visible;
                PlayerCardValue = StaticMethods.CountValue(player.ShowPlayerHand());
                if (PlayerCardValue > 21)
                {
                    Loose();
                }
            }
        }
        /// <summary>
        /// Player stands and let dealer get cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _stand_Click(object sender, EventArgs e)
        {
            if (DealerCardValue < 17 && validBet)
            {
                DealerCardValue = 0;
                while (Rules.GiveDealerCard(DealerCardValue))
                {
                    dealer.GetCardToDealer();
                    DealerCardValue = StaticMethods.CountAceValue(dealer.ShowDealerHand());
                    Update();
                  
                }
                Update();
                if (!Rules.NotOver21(DealerCardValue))
                {
                    Win();
                }
                else if (PlayerWinValue == 21 && DealerWinValue == 21)
                {
                    Draw();
                }
                else if (PlayerWinValue > DealerWinValue)
                {
                    Win();
                }
                else
                {
                    Loose();
                }
            }
            Update();
        }
        /// <summary>
        /// Loose msg
        /// </summary>
        private void Loose()
        {
            pictureBoxLost.Image = Properties.Resources.lost;
            pictureBoxLost.Visible = true;
            Refresh();
            Thread.Sleep(1500);
            pictureBoxLost.Visible = false;
            ClearVisualCards();
            if (player.balance < 1)
            {
                MessageBox.Show("OUT OF CASH!!");
                Environment.Exit(-1);
            }
        }
        /// <summary>
        /// Win msg
        /// </summary>
        private void Win()
        {
            pictureBoxLost.Image = Properties.Resources.winner12;
            pictureBoxLost.Visible = true;
            Refresh();
            Thread.Sleep(1500);
            pictureBoxLost.Visible = false;
            player.balance += bet;
            player.balance += bet;
            
            ClearVisualCards();
        }
        private void Draw()
        {
            player.balance += bet;
            MessageBox.Show("DRAW!!");
            ClearVisualCards();
        }
        /// <summary>
        /// Cleans Board
        /// </summary>
        public void ClearVisualCards()
        {
            bet = 0;
            running = false; ;
            validBet = false;
            PlayerCardValue = 0;
            DealerCardValue = 0;
            player.PlayerHand.Clear();
            dealer.DealerHand.Clear();
            _betReadBox.Text = "";
            Update();
        }
        /// <summary>
        /// Updates all boards textboxes and stuff
        /// </summary>
        private new void Update()
        {
            string VisualCardHandPlayer = "";
            string VisualCardHandDealer = "";
            int CardNr = 0;
            foreach (var item in player.PlayerHand)
            {
                string VisualCard = StaticMethods.GetFormCard(item);
                VisualCardHandPlayer += VisualCard;
                Card card = player.GetCard(CardNr);
            }
            foreach (var item in dealer.DealerHand)
            {
                string VisualCard = StaticMethods.GetFormCard(item);
                VisualCardHandDealer += VisualCard;
                Card card = player.GetCard(CardNr);
            }
            getRightPictureBox(player.PlayerHand);
            getRightPictureBox(dealer.DealerHand);
            //label1.Text = VisualCardHandPlayer;
            //label2.Text = VisualCardHandDealer;

            textBoxWallet.Text = player.balance.ToString();

            PlayerWinValue = Rules.SetWinValue(PlayerCardAceValue, PlayerCardValue, player);
            DealerWinValue = Rules.SetWinValue(DealerCardAceValue, DealerCardValue, dealer);

            _textBoxDealerPoints.Text = Rules.GetBestValue(DealerCardAceValue, DealerCardValue, dealer).ToString();
            _textBoxPlayerPoints.Text = Rules.GetBestValue(PlayerCardAceValue, PlayerCardValue, player).ToString();
        }

        public string nl()
        {
            return Environment.NewLine;
        }

        private void bid1_Click(object sender, EventArgs e)
        {
            if (!validBet)
            {
                bet += 1;
                _betReadBox.Text = bet.ToString();
                Update();
            }
        }

        private void bid5_Click(object sender, EventArgs e)
        {
            if (!validBet)
            {
                bet += 5; Update();
                _betReadBox.Text = bet.ToString();
                Update();
            }
        }

        private void bid10_Click(object sender, EventArgs e)
        {
            if (!validBet)
            {
                bet += 10; Update();
                _betReadBox.Text = bet.ToString();
                Update();
            }
        }

        private void bid25_Click(object sender, EventArgs e)
        {
            if (!validBet)
            {
                bet += 25; Update();
                _betReadBox.Text = bet.ToString();
                Update();
            }
        }

        private void bid100_Click(object sender, EventArgs e)
        {
            if (!validBet)
            {
                bet += 100; Update();
                _betReadBox.Text = bet.ToString();
                Update();
            }
        }
        public void ChangePic(PictureBox box, Bitmap location)
        {

            box.Image = location;
            //Properties.Resources.d1
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PlayerPicBox.Image = Properties.Resources.Shirzad;

            Player1.Visible = false;
            Player2.Visible = false;
            Player3.Visible = false;
            players.Visible = false;
            players2.Visible = false;

            player1Pic.Visible = false;
            player2Pic.Visible = false;
            player3Pic.Visible = false;
            playersPic.Visible = false;
        }

        private void player1Pic_Click(object sender, EventArgs e)
        {
            PlayerPicBox.Image = Properties.Resources.Player;

            Player1.Visible = false;
            Player2.Visible = false;
            Player3.Visible = false;
            players.Visible = false;
            players2.Visible = false;

            player1Pic.Visible = false;
            player2Pic.Visible = false;
            player3Pic.Visible = false;
            playersPic.Visible = false;
        }

        private void player3Pic_Click(object sender, EventArgs e)
        {
            PlayerPicBox.Image = Properties.Resources.Andres;

            Player1.Visible = false;
            Player2.Visible = false;
            Player3.Visible = false;
            players.Visible = false;
            players2.Visible = false;

            player1Pic.Visible = false;
            player2Pic.Visible = false;
            player3Pic.Visible = false;
            playersPic.Visible = false;
        }
    }
}
