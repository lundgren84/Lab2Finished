using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
   public class User
    {
        public virtual string GetCardText( )
        {
            string output ="";
            return output;
        }
       public virtual List<Card> GetHand()
        {
            return new List<Card>();
        }
    
    }
}
