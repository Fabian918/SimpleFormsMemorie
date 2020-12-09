using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class GameKontroller
    {
        public List<Player> Player { get; private set; }

        private int playerIndex = 0;
        public Player ActivePlayer
        {
            get
            {
                return Player[playerIndex];
            }
        }

        public GameKontroller(List<Player> player)
        {
            this.Player = player;
        }

        public void NaechsterSpieler()
        {
            if(this.playerIndex < this.Player.Count-1)
            {
                this.playerIndex++;
            }
            else
            {
                this.playerIndex = 0;
            }
        }
    }
}
