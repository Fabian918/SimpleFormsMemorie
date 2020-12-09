using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Player
    {
        public string name { get; private set; }

        public List<MemoryKachel> Kacheln { get; set; } = new List<MemoryKachel>();

        
        public Player(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
