using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
   public class Card
    {
        private string _Type;

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public int _Value { get; set; }
        public int _AceValue { get; set; }
        public string _Color { get; set; }
       public Card(int value,int aceValue,string color,string type)
        {
            this._Color = color;
            this._Value = value;
            this._Type = type;
            this._AceValue = aceValue;
        }
        public Card()
        { }
    }
}
