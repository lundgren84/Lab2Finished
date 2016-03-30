using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
   public class StaticMethods
    {/// <summary>
    /// Changes returns a type depended on int y
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
        public static string ReturnType(int y)
        {
            string Ytype = "";

            if (y == 0) { Ytype = "Heart"; }
            if (y == 1) { Ytype = "Dimond"; }
            if (y == 2) { Ytype = "Spade"; }
            if (y == 3) { Ytype = "Clubs"; }

            return Ytype;
        }
        /// <summary>
        /// Counts all cards value and return total value
        /// </summary>
        /// <param name="CardList"></param>
        /// <returns></returns>
        public static int CountValue(List<Card> CardList)
        {
            int totalValue = 0;
            foreach (var item in CardList)
            {
                
                totalValue += item._Value;
                //if ( item.Type == "Ace") { item._AceValue = 10 + totalValue; }
           
            }
            return totalValue;
        }
        /// <summary>
        /// Counts all cards value and return total Acevalue
        /// </summary>
        /// <param name="CardList"></param>
        /// <returns></returns>
        public static int CountAceValue(List<Card> CardList)
        {
            int totalValue = 0;
            int countAce = 0;
            foreach (var item in CardList)
            {
                if ( item._AceValue== 11) { countAce++; }
                totalValue += item._AceValue;   
            }
            if (totalValue > 21 && countAce > 1)
            {
                totalValue -= 10;
            }
            if (totalValue > 21 && countAce > 2)
            {
                totalValue -= 10;
            }
            if (totalValue > 21 && countAce > 3)
            {
                totalValue -= 10;
            }
            if (totalValue > 21 && countAce > 4)
            {
                totalValue -= 10;
            }
            return totalValue;
        }
      
        
        public static string GetType(int x)
        {
            string type = "";
            if (x == 0) { type = "Ace"; }
            if (x == 1) { type = "Two"; }
            if (x == 2) { type = "Three"; }
            if (x == 3) { type = "Four"; }
            if (x == 4) { type = "Five"; }
            if (x == 5) { type = "Six"; }
            if (x == 6) { type = "Seven"; }
            if (x == 7) { type = "Eight"; }
            if (x == 8) { type = "Nine"; }
            if (x == 9) { type = "Ten"; }
            if (x == 10) { type = "Knight"; }
            if (x == 11) { type = "Queen"; }
            if (x == 12) { type = "King"; }
            return type;
        }
        public static string GetFormCard(Card card)
        {
            string output = "";
            if (card._Color == "Heart")// 🂱 🂲 🂳 🂴 🂵 🂶 🂷 🂸 🂹 🂺 🂻 🂽 🂾
            {
                if ( card.Type == "Ace") { return "🂱"; }
                if (card.Type == "Two") { return "🂲"; }
                if (card.Type == "Three") { return "🂳"; }
                if (card.Type == "Four") { return "🂴"; }
                if (card.Type == "Five") { return "🂵"; }
                if (card.Type == "Six") { return "🂶"; }
                if (card.Type == "Seven") { return "🂷"; }
                if (card.Type == "Eight") { return "🂸"; }
                if (card.Type == "Nine") { return "🂹"; }
                if (card.Type == "Ten") { return "🂺"; }
                if (card.Type == "Knight") { return "🂻"; }
                if (card.Type == "Queen") { return "🂽"; }
                if (card.Type == "King") { return "🂾"; }
            } 
            if (card._Color == "Dimond")// 🃁 🃂 🃃 🃄 🃅 🃆 🃇 🃈 🃉 🃊 🃋 🃍 🃎
            {
                if (card.Type == "Ace") { return "🃁"; }
                if (card.Type == "Two") { return "🃂"; }
                if (card.Type == "Three") { return "🃃"; }
                if (card.Type == "Four") { return "🃄"; }
                if (card.Type == "Five") { return "🃅"; }
                if (card.Type == "Six") { return "🃆"; }
                if (card.Type == "Seven") { return "🃇"; }
                if (card.Type == "Eight") { return "🃈"; }
                if (card.Type == "Nine") { return "🃉"; }
                if (card.Type == "Ten") { return "🃊"; }
                if (card.Type == "Knight") { return "🃋"; }
                if (card.Type == "Queen") { return "🃍"; }
                if (card.Type == "King") { return "🃎"; }
            } 
            if (card._Color == "Spade")// 🂡 🂢 🂣 🂤 🂥 🂦 🂧 🂨 🂩 🂪 🂫 🂭 🂮
            {
                if (card.Type == "Ace") { return "🂡"; }
                if (card.Type == "Two") { return "🂢"; }
                if (card.Type == "Three") { return "🂣"; }
                if (card.Type == "Four") { return "🂤"; }
                if (card.Type == "Five") { return "🂥"; }
                if (card.Type == "Six") { return "🂦"; }
                if (card.Type == "Seven") { return "🂧"; }
                if (card.Type == "Eight") { return "🂨"; }
                if (card.Type == "Nine") { return "🂩"; }
                if (card.Type == "Ten") { return "🂪"; }
                if (card.Type == "Knight") { return "🂫"; }
                if (card.Type == "Queen") { return "🂭"; }
                if (card.Type == "King") { return "🂮"; }
            }
            if (card._Color == "Clubs")  // 🃑 🃒 🃓 🃔  🃕 🃖 🃗 🃘  🃙 🃚 🃛 🃝 🃞
            {
                if (card.Type == "Ace") { return "🃑"; }
                if (card.Type == "Two") { return "🃒"; }
                if (card.Type == "Three") { return "🃓"; }
                if (card.Type == "Four") { return "🃔"; }
                if (card.Type == "Five") { return "🃕"; }
                if (card.Type == "Six") { return "🃖"; }
                if (card.Type == "Seven") { return "🃗"; }
                if (card.Type == "Eight") { return "🃘"; }
                if (card.Type == "Nine") { return "🃙"; }
                if (card.Type == "Ten") { return "🃚"; }
                if (card.Type == "Knight") { return "🃛"; }
                if (card.Type == "Queen") { return "🃝"; }
                if (card.Type == "King") { return "🃞"; }
            }
            return output;
        }
        public static string GetPictCard(Card card)
        {
            string output = "";
            if (card._Color == "Heart")// 🂱 🂲 🂳 🂴 🂵 🂶 🂷 🂸 🂹 🂺 🂻 🂽 🂾
            {
                if (card.Type == "Ace") { return "h1"; }
                if (card.Type == "Two") { return "h2"; }
                if (card.Type == "Three") { return "h3"; }
                if (card.Type == "Four") { return "h4"; }
                if (card.Type == "Five") { return "h5"; }
                if (card.Type == "Six") { return "h6"; }
                if (card.Type == "Seven") { return "h7"; }
                if (card.Type == "Eight") { return "h8"; }
                if (card.Type == "Nine") { return "h9"; }
                if (card.Type == "Ten") { return "h10"; }
                if (card.Type == "Knight") { return "h11"; }
                if (card.Type == "Queen") { return "h12"; }
                if (card.Type == "King") { return "h13"; }
            }
            if (card._Color == "Dimond")// 🃁 🃂 🃃 🃄 🃅 🃆 🃇 🃈 🃉 🃊 🃋 🃍 🃎
            {
                if (card.Type == "Ace") { return "d1"; }
                if (card.Type == "Two") { return "d2"; }
                if (card.Type == "Three") { return "d3"; }
                if (card.Type == "Four") { return "d4"; }
                if (card.Type == "Five") { return "d5"; }
                if (card.Type == "Six") { return "d6"; }
                if (card.Type == "Seven") { return "d7"; }
                if (card.Type == "Eight") { return "d8"; }
                if (card.Type == "Nine") { return "d9"; }
                if (card.Type == "Ten") { return "d10"; }
                if (card.Type == "Knight") { return "d11"; }
                if (card.Type == "Queen") { return "d12"; }
                if (card.Type == "King") { return "d13"; }
            }
            if (card._Color == "Spade")// 🂡 🂢 🂣 🂤 🂥 🂦 🂧 🂨 🂩 🂪 🂫 🂭 🂮
            {
                if (card.Type == "Ace") { return "s1"; }
                if (card.Type == "Two") { return "s2"; }
                if (card.Type == "Three") { return "s3"; }
                if (card.Type == "Four") { return "s4"; }
                if (card.Type == "Five") { return "s5"; }
                if (card.Type == "Six") { return "s6"; }
                if (card.Type == "Seven") { return "s7"; }
                if (card.Type == "Eight") { return "s8"; }
                if (card.Type == "Nine") { return "s9"; }
                if (card.Type == "Ten") { return "s10"; }
                if (card.Type == "Knight") { return "s11"; }
                if (card.Type == "Queen") { return "s12"; }
                if (card.Type == "King") { return "s13"; }
            }
            if (card._Color == "Clubs")  // 🃑 🃒 🃓 🃔  🃕 🃖 🃗 🃘  🃙 🃚 🃛 🃝 🃞
            {
                if (card.Type == "Ace") { return "c1"; }
                if (card.Type == "Two") { return "c2"; }
                if (card.Type == "Three") { return "c3"; }
                if (card.Type == "Four") { return "c4"; }
                if (card.Type == "Five") { return "c5"; }
                if (card.Type == "Six") { return "c6"; }
                if (card.Type == "Seven") { return "c7"; }
                if (card.Type == "Eight") { return "c8"; }
                if (card.Type == "Nine") { return "c9"; }
                if (card.Type == "Ten") { return "c10"; }
                if (card.Type == "Knight") { return "c11"; }
                if (card.Type == "Queen") { return "c12"; }
                if (card.Type == "King") { return "c13"; }
            }
            return output;
        }

    }
}
