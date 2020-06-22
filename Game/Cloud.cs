using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Cloud : BasicThing
    {
        public enum Options { Cloud1 , Cloud2, Cloud3, Cloud4};
        public Options Type;

        public Cloud(int x, int y, Options type)
        {
            Width = 300;
            Height = 150;
            X = x;
            Y = y;
            Type = type;
        }

        public void Shift(int shift)
        {
            X += shift;
        }

        public void ToStart()
        {
            X = 4000;
        }

        public bool Recycle()
        {
            return X + Width < 0;
        }


    }
}
