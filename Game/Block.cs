using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Block : BasicThing
    {
        int minimalWidth = 50;
        public enum Options {Ground1, Ground2, Ground3, Ground4, Ground5, Ground10, Ground15, Ground20, Box, MonsterBox };
        public Options Type { get; private set; }

        public Block(int x, int y, Options type)
        {
            X = x;
            Y = y;
            Type = type;
            Height = 50;

            switch (type)
            {
                case Options.Ground2:
                    Width = 2 * minimalWidth;
                    break;
                case Options.Ground3:
                    Width = 3 * minimalWidth;
                    break;
                case Options.Ground4:
                    Width = 4 * minimalWidth;
                    break;
                case Options.Ground5:
                    Width = 5 * minimalWidth;
                    break;
                case Options.Ground10:
                    Width = 10 * minimalWidth;
                    break;
                case Options.Ground15:
                    Width = 15 * minimalWidth;
                    break;
                case Options.Ground20:
                    Width = 20 * minimalWidth;
                    break;
                default:
                    Width = minimalWidth;
                    break;
            }
        }

        public void Shift(int shift)
        {
            X = X + shift;
        }
    }
}
