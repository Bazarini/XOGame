using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXGame
{
    class Player
    {
        public string Character { get; set; }
        public string Name { get; set; }
        public int Wons { get; private set; }

        public Player(string name, string character)
        {
            Character = character;
            Name = name;
        }
        public Player()
        {

        }

        public void Win()
        {
            Wons++;
        }
    }
}
