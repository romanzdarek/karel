using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Flag : BasicThing
    {
        public Flag(int x, int y)
        {
            X = x;
            Y = y;
            Width = 36;
            Height = 40;
        }
        public void Shift(int shift)
        {
            X = X + shift;
        }
    }
}
