using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameover = false;
            GameFlow gameFOlow = new GameFlow();
            while (!gameover)
            {
                gameover = gameFOlow.RunGame();
            }
            // 🂡 🂢 🂣 🂤	🂥 🂦 🂧 🂨 🂩 🂪 🂫 🂭 🂮
            // 🃑 🃒 🃓 🃔 🃕 🃖 🃗 🃘 🃙 🃚 🃛 🃝 🃞
            // 🃁 🃂 🃃 🃄 🃅 🃆 🃇 🃈 🃉 🃊 🃋 🃍 🃎
        }
    }
}
