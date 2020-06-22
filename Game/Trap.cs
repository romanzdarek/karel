using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Trap : BasicThing
    {
        public enum Options {Bottom, Top };
        public Options Type { get; private set; }

        public Trap(int x, int y, Options type)
        {
            Width = 50;
            Height = 25;
            X = x;
            Y = y;
            Type = type;
        }

        public void Shift(int shift)
        {
            X = X + shift;
        }
    }
}
