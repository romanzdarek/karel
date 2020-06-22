using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Monster : SomeOne
    {
        public enum Options {Rat, UfoYellow, UfoRed , UfoPurple};
        public Options Type { get; private set; }

        public Monster(int x, int y, Options type) : base()
        {
            X = x;
            Y = y;
            Type = type;
            //jdem
            Moving = true;
            speed = 6;

            //náhodný směr
            if(Model.Random.Next(2) == 0)
            {
                Direction = "right";
            }
            else
            {
                Direction = "left";
            }

            if(type == Options.Rat)
            {
                Height = 18;
                Width = 38;
                speed = 3;
            }
            else if (type == Options.UfoYellow)
            {
                Width = 42;
                Height = 46;
                speed = 5;
            }
            else if (type == Options.UfoRed)
            {
                Width = 42;
                Height = 46;
                speed = 8;
            }
            else if (type == Options.UfoPurple)
            {
                Width = 42;
                Height = 46;
                speed = 4;
            }
        }

        public override void Shift()
        {
            int akcelerateShift;
            //rozložení zrychlení
            switch (akcelerateTimer)
            {
                case 0:
                    akcelerateShift = 1;
                    break;
                case 1:
                    akcelerateShift = 1;
                    break;
                case 2:
                    akcelerateShift = 2;
                    break;
                case 3:
                    akcelerateShift = 2;
                    break;
                case 4:
                    akcelerateShift = 3;
                    break;
                case 5:
                    akcelerateShift = 3;
                    break;
                case 6:
                    akcelerateShift = 3;
                    break;
                case 7:
                    akcelerateShift = 4;
                    break;
                case 8:
                    akcelerateShift = 4;
                    break;
                case 9:
                    akcelerateShift = 4;
                    break;
                case 10:
                    akcelerateShift = 4;
                    break;
                default:
                    akcelerateShift = speed;
                    break;
            }
            //nemůžeme zrychlit víc než na naši rychlost
            if (akcelerateShift > speed)
            {
                akcelerateShift = speed;
            }

            //zrychlení
            akcelerateTimer++;

            if (Direction == "right")
            {
                //max možný posun mapy
                int shift = CanMove("right", akcelerateShift);


                //posun
                X = X + shift;
            }
            else
            {
                //max možný posun mapy
                int shift = CanMove("left", akcelerateShift);

                //posun
                X = X - shift;
            }
        }

        //pro posun s posunem mapy
        public void Shift(string directions, int shift)
        {
            if (directions == "right")
            {
                //posun
                X = X - shift;
            }
            else
            {
                //posun
                X = X + shift;
            }
        }
        
        //AI
        public void AI()
        {
            //zlutej hopsa
            /*
            if(Type == "ufoYellow")
            {
                Jump(true);
            }
            */

            //není kam jít, změna směru
            if(0 == CanMove(Direction, speed))
            {
                akcelerateTimer = 0;

                if(Direction == "right")
                {
                    Direction = "left";
                }
                else
                {
                    Direction = "right";
                }
            }
            Move();
        }

        public override void Alive()
        {
            //nespadli jsme?
            if (Y > GameWindow.FormHeight)
            {
                Live = false;
            }
        }

        public void Kill()
        {
            Live = false;
        }
    }
}
