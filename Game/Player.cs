using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : SomeOne
    {
        int deadTimer;

        public Player(): base()
        {
            deadTimer = 0;
            speed = 10;
            Width = 26;
            Height = 50;
            X = 387;
            Y = 350;
        }

        //došli jsme k vlajce?
        public bool LevelEnd()
        {
            int contractionFlag = 15;

            if (X <= Model.World.Flag.X + Model.World.Flag.Width - contractionFlag && X + Width >= Model.World.Flag.X + contractionFlag)
            {
                if (Y <= Model.World.Flag.Y + Model.World.Flag.Height - contractionFlag && Y + Height >= Model.World.Flag.Y + contractionFlag)
                {
                    return true;
                }
            }
            return false;
        }

        //animace umirani
        public virtual void DeadAnimate()
        {
            switch (deadTimer)
            {
                case 0:
                    X = X + 4;
                    deadTimer++;
                    break;
                case 1:
                    X = X - 4;
                    deadTimer++;
                    break;
                case 2:
                    Y = Y + 4;
                    deadTimer++;
                    break;
                case 3:
                    Y = Y - 4;
                    deadTimer++;
                    break;
            }
            deadTimer = (deadTimer == 4) ? 0 : deadTimer;
        }
    }
}
