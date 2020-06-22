using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class SomeOne : BasicThing
    {
        bool jump;
        bool jumpEnd;

        protected int speed;
        protected int akcelerateTimer;

        public int JumpTimer { get; protected set; }
        public int FallTimer { get; protected set; }
        public string Direction { get; protected set; }
        public bool Moving { get; protected set; }
        public bool Live { get; protected set; }

        public SomeOne()
        {
            JumpTimer = 0;
            FallTimer = 0;
            akcelerateTimer = 0;
            jump = false;
            jumpEnd = true;
            Direction = "right";
            Moving = false;
            Live = true;
        }

        //naživu?
        public virtual void Alive()
        {
            //zmenšeni pro kolizz
            int contractionUfo = 10;
            int bigContractionUfo = 22;
            int smalContractionUfo = 10;
            int contractionRat = 4;
            int contractionTrap = 6;

            //nejsme v pasti?
            foreach (var trap in Model.World.Traps)
            {
                if (X + Width >= trap.X + contractionTrap && X <= trap.X + trap.Width - contractionTrap)
                {
                    if (Y + Height >= trap.Y + smalContractionUfo && Y <= trap.Y + trap.Height - smalContractionUfo)
                    {
                        Live = false;
                    }
                }
            }

            //nespadli jsme?
            if (Y > GameWindow.FormHeight)
            {
                Live = false;
            }

            //srážka s monstrem
            foreach (var monster in Model.World.Monsters)
            {
                //ufo
                if (monster.Type == Monster.Options.UfoYellow || monster.Type == Monster.Options.UfoRed || monster.Type == Monster.Options.UfoPurple)
                {
                    //tady ještě rozlišíme dva stavy
                    //pokud je ufon nalevo od nás a je natočen směrem od nás a stejně tak i pro pravou stranu...
                    //tak zvýšíme contractionUfo (větší překrytí po kolizy) aby nenastala kolize ještě ve stavu kdyby se nepřekryl žádný pixel ufa a playera
                    if ((X + (Width / 2) > monster.X + (monster.Width / 2) && monster.Direction == "Left") || (X + (Width / 2) < monster.X + (monster.Width / 2) && monster.Direction == "Right"))
                    {
                        //verze s větším překrytím
                        contractionUfo = bigContractionUfo;
                    }
                    else
                    {
                        //malé překrytí
                        contractionUfo = smalContractionUfo;
                    }

                    //nesmíme se dotknout
                    if (X <= monster.X + monster.Width - contractionUfo && X + Width >= monster.X + contractionUfo)
                    {
                        if (Y <= monster.Y + monster.Height - contractionUfo && Y + Height >= monster.Y + contractionUfo)
                        {

                            //srážka
                            Live = false;
                            monster.Run("left", false);
                            monster.Run("right", false);
                        }
                    }
                }

                //rat se dá zašlápnout
                else if (monster.Type == Monster.Options.Rat && monster.Live)
                {
                    if (X <= monster.X + monster.Width - contractionRat && X + Width >= monster.X + contractionRat)
                    {

                        //pokud skočíme na rat
                        if (FallTimer > 0 && Y + Height >= monster.Y && Y + Height <= monster.Y + 20)
                        {
                            //zašlápnutí
                            //pád nesmíme úplně vynulovat jinak nemůžem zašlápnout více potvor najednou
                            Sound.Kill.Play();
                            FallTimer = 1;
                            monster.Kill();
                            //posun po zašlápnutí
                            monster.Y += monster.Height;
                        }
                        //jinak srážka
                        else if (Y <= monster.Y + monster.Height && Y + Height >= monster.Y)
                        {
                            //srážka
                            Live = false;
                            monster.Run("left", false);
                            monster.Run("right", false);
                        }
                    }
                }
            }
        }

        //pohyb 
        public void Move()
        {
            //skok
            if (jump)
            {
                //skákat můžeme pokud zrovna nepadáme nebo nejsme už ve skoku
                if (FallTimer == 0 && JumpTimer == 0)
                {
                    JumpTimer = 1;
                    Sound.Jump.Play();
                }

                if (JumpTimer > 0)
                {
                    switch (JumpTimer)
                    {
                        case 1:
                            Y = Y - CanMove("up", 8);
                            break;
                        case 2:
                            Y = Y - CanMove("up", 9);
                            break;
                        case 3:
                            Y = Y - CanMove("up", 10);
                            break;
                        case 4:
                            Y = Y - CanMove("up", 11);
                            break;
                        case 5:
                            Y = Y - CanMove("up", 11);
                            break;
                        case 6:
                            Y = Y - CanMove("up", 11);
                            break;
                        case 7:
                            Y = Y - CanMove("up", 11);
                            break;
                        case 8:
                            Y = Y - CanMove("up", 10);
                            break;
                        case 9:
                            Y = Y - CanMove("up", 10);
                            break;
                        case 10:
                            Y = Y - CanMove("up", 9);
                            break;
                        case 11:
                            Y = Y - CanMove("up", 8);
                            break;
                        case 12:
                            Y = Y - CanMove("up", 6);
                            break;
                        case 13:
                            Y = Y - CanMove("up", 4);
                            break;
                        case 14:
                            Y = Y - CanMove("up", 2);
                            break;
                        case 15:
                            Y = Y - CanMove("up", 1);
                            break;

                            //původní skok cekem posun o 118
                            /*
                             
                         case 1:
                            Y = Y - CanMove("up", 1);
                            break;
                        case 2:
                            Y = Y - CanMove("up", 2);
                            break;
                        case 3:
                            Y = Y - CanMove("up", 4);
                            break;
                        case 4:
                            Y = Y - CanMove("up", 6);
                            break;
                        case 5:
                            Y = Y - CanMove("up", 9);
                            break;
                        case 6:
                            Y = Y - CanMove("up", 12);
                            break;
                        case 7:
                            Y = Y - CanMove("up", 15);
                            break;
                        case 8:
                            Y = Y - CanMove("up", 20);
                            break;
                        case 9:
                            Y = Y - CanMove("up", 15);
                            break;
                        case 10:
                            Y = Y - CanMove("up", 12);
                            break;
                        case 11:
                            Y = Y - CanMove("up", 9);
                            break;
                        case 12:
                            Y = Y - CanMove("up", 6);
                            break;
                        case 13:
                            Y = Y - CanMove("up", 4);
                            break;
                        case 14:
                            Y = Y - CanMove("up", 2);
                            break;
                        case 15:
                            Y = Y - CanMove("up", 1);
                            break;
                         */
                    }
                    JumpTimer++;
                    //konec skoku
                    if (JumpTimer > 15)
                    {
                        //skáčem dál
                        if (!jumpEnd)
                        {
                            JumpTimer = 0;
                        }
                        //už neskáčem
                        else
                        {
                            JumpTimer = 0;
                            jump = false;
                        }
                    }
                }
            }
            //pád pokud zrovna neskáčeme
            if (JumpTimer == 0)
            {
                //zrušení dalšího skoku pokud jsme pustuli klávesu UP
                if (jumpEnd)
                {
                    jump = false;
                }
                int shift;
                //pád se postupně zrychluje
                switch (FallTimer)
                {
                    case 0:
                        shift = CanMove("down", 1);
                        break;
                    case 1:
                        shift = CanMove("down", 2);
                        break;
                    case 2:
                        shift = CanMove("down", 4);
                        break;
                    case 3:
                        shift = CanMove("down", 6);
                        break;
                    case 4:
                        shift = CanMove("down", 9);
                        break;
                    case 5:
                        shift = CanMove("down", 12);
                        break;
                    default:
                        shift = CanMove("down", 15);
                        break;
                }
                //zrychlení pádu
                if (shift > 0)
                {
                    FallTimer++;
                }
                //pád zastaven
                else
                {
                    FallTimer = 0;
                }
                //výsledný posun
                Y = Y + shift;
            }
            //běh
            if (Moving)
            {
                //posun
                Shift();
            }
            //žijeme?
            Alive();
        }

        //je možný posun?
        protected int CanMove(string directin, int shift)
        {
            //"zúžení" postavy dovolí překrýt o kousek pevné části ve hře
            int contraction = 8;

            int possibleShift;

            switch (directin)
            {
                case "down":
                    foreach (Block block in Model.World.Blocks)
                    {
                        //povrch pod námi na ose X
                        if (X + contraction < block.X + block.Width && X + Width - contraction > block.X)
                        {
                            //ignorujem bloky nad námi
                            if (Y >= block.Y)
                            {

                            }
                            //úplný posun už není možný
                            else if (Y + Height + shift >= block.Y)
                            {
                                //MonsterBox zastavuje jen monstra
                                if (this is Monster || (this is Player && block.Type != Block.Options.MonsterBox))
                                {
                                    //o kolik se ještě můžeme posunout?
                                    possibleShift = block.Y - (Y + Height);
                                    //není možný záporný posun
                                    possibleShift = (possibleShift < 0) ? 0 : possibleShift;
                                    //snížení možného posunu
                                    shift = (possibleShift < shift) ? possibleShift : shift;
                                }  
                            }
                        }
                    }
                    return shift;
                case "up":
                    foreach (Block block in Model.World.Blocks)
                    {
                        //povrch nad námi na ose X
                        if (X + contraction < block.X + block.Width && X + Width - contraction > block.X)
                        {
                            //ignorujem bloky pod námi
                            if (Y + Height <= block.Y)
                            {

                            }
                            //úplný posun už není možný, blok nad námi...
                            else if (Y + shift >= block.Y + block.Height)
                            {
                                //MonsterBox zastavuje jen monstra
                                if (this is Monster || (this is Player && block.Type != Block.Options.MonsterBox))
                                {
                                    //o kolik se ještě můžeme posunout?
                                    possibleShift = Y - (block.Y + block.Height);
                                    //není možný záporný posun
                                    possibleShift = (possibleShift < 0) ? 0 : possibleShift;
                                    //snížení možného posunu
                                    shift = (possibleShift < shift) ? possibleShift : shift;

                                    //nemožný posun? ukončíme skok
                                    JumpTimer = (shift == 0) ? -1 : JumpTimer;

                                    //pokud nedržíme klávesu UP tak přestaneme skákat
                                    if (shift == 0 && jumpEnd)
                                    {
                                        jump = false;
                                    }
                                }
                            }
                        }
                    }
                    return shift;
                case "left":
                    foreach (Block block in Model.World.Blocks)
                    {
                        //pouze bloky na levo 
                        if (X + contraction >= block.X + block.Width)
                        {
                            //blok musí být v naší výšce
                            if (Y < block.Y + block.Height && Y + Height > block.Y)
                            {
                                //MonsterBox zastavuje jen monstra
                                if (this is Monster || (this is Player && block.Type != Block.Options.MonsterBox))
                                {
                                    //o kolik je možný posun
                                    possibleShift = X + contraction - (block.X + block.Width);

                                    //posun nemůže být záporný
                                    possibleShift = (possibleShift < 0) ? 0 : possibleShift;
                                    //snížíme posun
                                    shift = (possibleShift < shift) ? possibleShift : shift;
                                }
                            }
                        }
                    }
                    return shift;
                case "right":
                    foreach (Block block in Model.World.Blocks)
                    {
                        //pouze bloky na pravo 
                        if (X + Width - contraction <= block.X)
                        {
                            //blok musí být v naší výšce
                            if (Y < block.Y + block.Height && Y + Height > block.Y)
                            {
                                //MonsterBox zastavuje jen monstra
                                if (this is Monster || (this is Player && block.Type != Block.Options.MonsterBox))
                                {
                                    //o kolik je možný posun
                                    possibleShift = block.X - (X + Width - contraction);

                                    //posun nemůže být záporný
                                    possibleShift = (possibleShift < 0) ? 0 : possibleShift;
                                    //snížíme posun
                                    shift = (possibleShift < shift) ? possibleShift : shift;
                                }
                            }
                        }
                    }
                    return shift;
                default:
                    return 0;
            }
        }

        //posun mapy (hráče)
        public virtual void Shift()
        {
            int akcelerateShift;
            //rozložení zrychlení
            switch (akcelerateTimer)
            {
                case 0:
                    akcelerateShift = 1;
                    break;
                case 1:
                    akcelerateShift = 2;
                    break;
                case 2:
                    akcelerateShift = 3;
                    break;
                case 3:
                    akcelerateShift = 4;
                    break;
                case 4:
                    akcelerateShift = 5;
                    break;
                case 5:
                    akcelerateShift = 6;
                    break;
                case 6:
                    akcelerateShift = 7;
                    break;
                case 7:
                    akcelerateShift = 8;
                    break;
                case 8:
                    akcelerateShift = 9;
                    break;
                case 9:
                    akcelerateShift = 10;
                    break;
                case 10:
                    akcelerateShift = 10;
                    break;
                default:
                    akcelerateShift = speed;
                    break;
            }
            //nemůžeme zrychlit víc než na naši rychlost
            if(akcelerateShift > speed)
            {
                akcelerateShift = speed;
            }
            //zrychlení
            akcelerateTimer++;

            if (Direction == "right")
            {
                //max možný posun mapy
                int shift = CanMove("right", akcelerateShift);

                //pokud není možný posun vynulejeme zrychlení
                akcelerateTimer = (shift == 0) ? 0 : akcelerateTimer;

                //posun mapy
                foreach (Block block in Model.World.Blocks)
                {
                    block.Shift(-shift);
                }
                //posun mraků
                foreach (Cloud cloud in Model.World.Clouds)
                {
                    cloud.Shift(-2);
                }
                
                //posun vlajky
                Model.World.Flag.Shift(-shift);
                //posun pastí
                foreach (Trap trap in Model.World.Traps)
                {
                    trap.Shift(-shift);
                }
                //posun monster
                foreach (var monster in Model.World.Monsters)
                {
                    monster.Shift("right", shift);
                }
            }
            else
            {
                //max možný posun mapy
                int shift = CanMove("left", akcelerateShift);
                //pokud není možný posun vynulejeme zrychlení
                akcelerateTimer = (shift == 0) ? 0 : akcelerateTimer;
                //posun mapy
                foreach (Block block in Model.World.Blocks)
                {
                    block.Shift(shift);
                }
                //posun mraků
                foreach (Cloud cloud in Model.World.Clouds)
                {
                    cloud.Shift(2);
                }
                
                //posun vlajky
                Model.World.Flag.Shift(shift);
                //posun pastí
                foreach (Trap trap in Model.World.Traps)
                {
                    trap.Shift(shift);
                }
                //posun monster
                foreach (var monster in Model.World.Monsters)
                {
                    monster.Shift("left", shift);
                }
            }
        }

        //Run Forrest Run!
        public void Run(string direction, bool state)
        {

            //stisk
            if (state)
            {
                Moving = true;
                Direction = direction;
            }
            //uvolnění klávesy
            else
            {
                //uvolnění klávesy aktuálního směru
                if (Direction == direction)
                {
                    Moving = false;
                    akcelerateTimer = 0;
                }
            }
        }

        public void Jump(bool state)
        {
            //stisk klávesy
            if (state)
            {
                jump = true;
                jumpEnd = false;
            }
            //uvolnění klávesy
            else
            {
                jumpEnd = true;
            }
        }
    }
}
