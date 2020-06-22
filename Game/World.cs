using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class World
    {
        public List<Block> Blocks { get; private set; }
        public List<Trap> Traps { get; private set; }
        public List<Cloud> Clouds { get; private set; }
        public List<Monster> Monsters { get; private set; }
        public Flag Flag;

        public World(int level)
        {
            switch (level)
            {
                case 1:
                    CreateLevel1();
                    break;
                case 2:
                    CreateLevel2();
                    break;
                case 3:
                    CreateLevel3();
                    break;
            }
        }

        //Level 1
        void CreateLevel1()
        {
            Blocks = new List<Block>();
            Traps = new List<Trap>();
            Clouds = new List<Cloud>();
            Monsters = new List<Monster>();

            //mraky
            Clouds.Add(new Cloud(400, 10, Cloud.Options.Cloud1));
            Clouds.Add(new Cloud(1200, 40, Cloud.Options.Cloud2));
            Clouds.Add(new Cloud(2000, 60, Cloud.Options.Cloud3));
            Clouds.Add(new Cloud(2800, 50, Cloud.Options.Cloud4));
            Clouds.Add(new Cloud(3600, 20, Cloud.Options.Cloud1));

      

            Blocks.Add(new Block(150, 400, Block.Options.Ground10));

            Blocks.Add(new Block(800, 450, Block.Options.Ground10));
            Blocks.Add(new Block(800, 400, Block.Options.Box));
            Blocks.Add(new Block(1000, 250, Block.Options.Ground1));
            Traps.Add(new Trap(1000, 300, Trap.Options.Top));
            Flag = new Flag(1000, 210);
            Blocks.Add(new Block(1200, 400, Block.Options.Box));
            Blocks.Add(new Block(1250, 400, Block.Options.Box));
            Blocks.Add(new Block(1250, 350, Block.Options.Box));


            Blocks.Add(new Block(1450, 350, Block.Options.Ground5));
            Traps.Add(new Trap(1550, 325, Trap.Options.Bottom));

            Blocks.Add(new Block(1850, 250, Block.Options.Ground4));

            Blocks.Add(new Block(2200, 350, Block.Options.Ground1));

            Blocks.Add(new Block(2400, 450, Block.Options.Ground3));

            Blocks.Add(new Block(2700, 500, Block.Options.Ground2));


            Blocks.Add(new Block(2900, 400, Block.Options.Ground1));


            Blocks.Add(new Block(3100, 350, Block.Options.Ground20));
            Blocks.Add(new Block(3050, 300, Block.Options.MonsterBox));
            Blocks.Add(new Block(4100, 300, Block.Options.MonsterBox));
            Blocks.Add(new Block(3550, 300, Block.Options.Box));
            Blocks.Add(new Block(3600, 300, Block.Options.Box));
            Blocks.Add(new Block(3600, 250, Block.Options.Box));
            Blocks.Add(new Block(3650, 300, Block.Options.Box));
            Monsters.Add(new Monster(3200, 300, Monster.Options.Rat));
            Monsters.Add(new Monster(3550, 0, Monster.Options.Rat));
            Monsters.Add(new Monster(3650, 0, Monster.Options.Rat));
            Monsters.Add(new Monster(3900, 300, Monster.Options.Rat));


            Blocks.Add(new Block(4250, 450, Block.Options.Ground15));
            Blocks.Add(new Block(4400, 400, Block.Options.Box));
            Blocks.Add(new Block(4450, 400, Block.Options.Box));
            Blocks.Add(new Block(4450, 350, Block.Options.Box));
            Blocks.Add(new Block(4500, 400, Block.Options.Box));
            Traps.Add(new Trap(4550, 425, Trap.Options.Bottom));
            Traps.Add(new Trap(4600, 425, Trap.Options.Bottom));
            Traps.Add(new Trap(4650, 425, Trap.Options.Bottom));
            Blocks.Add(new Block(4700, 400, Block.Options.Box));
            Blocks.Add(new Block(4750, 400, Block.Options.Box));
            Blocks.Add(new Block(4750, 350, Block.Options.Box));
            Blocks.Add(new Block(4800, 400, Block.Options.Box));



            Blocks.Add(new Block(5150, 450, Block.Options.Ground5));
            Blocks.Add(new Block(5100, 400, Block.Options.MonsterBox));
            Blocks.Add(new Block(5400, 400, Block.Options.MonsterBox));
            Monsters.Add(new Monster(5200, 400, Monster.Options.UfoPurple));

            Blocks.Add(new Block(5550, 350, Block.Options.Ground3));


            Blocks.Add(new Block(5850, 300, Block.Options.Ground10));

            Blocks.Add(new Block(6400, 400, Block.Options.Ground1));


            Blocks.Add(new Block(6500, 200, Block.Options.Ground5));
            Blocks.Add(new Block(6450, 150, Block.Options.MonsterBox));
            Blocks.Add(new Block(6750, 150, Block.Options.MonsterBox));
            Monsters.Add(new Monster(6550, 150, Monster.Options.UfoYellow));

            Blocks.Add(new Block(6500, 500, Block.Options.Ground10));
            Blocks.Add(new Block(6500, 450, Block.Options.Box));
            Traps.Add(new Trap(6550, 475, Trap.Options.Bottom));
            Blocks.Add(new Block(6600, 450, Block.Options.Box));
            Traps.Add(new Trap(6650, 475, Trap.Options.Bottom));
            Blocks.Add(new Block(6700, 450, Block.Options.Box));
            Traps.Add(new Trap(6750, 475, Trap.Options.Bottom));
            Blocks.Add(new Block(6800, 450, Block.Options.Box));
            Traps.Add(new Trap(6850, 475, Trap.Options.Bottom));
            Blocks.Add(new Block(6900, 450, Block.Options.Box));
            Blocks.Add(new Block(6950, 450, Block.Options.Box));
            Blocks.Add(new Block(6950, 400, Block.Options.Box));


            Blocks.Add(new Block(7100, 300, Block.Options.Ground5));
            Blocks.Add(new Block(7050, 250, Block.Options.MonsterBox));
            Blocks.Add(new Block(7350, 250, Block.Options.MonsterBox));
            Monsters.Add(new Monster(7200, 250, Monster.Options.UfoRed));


            Blocks.Add(new Block(7450, 350, Block.Options.Ground1));


            Blocks.Add(new Block(7550, 500, Block.Options.Ground15));
            Blocks.Add(new Block(7550, 450, Block.Options.Box));
            Traps.Add(new Trap(7600, 475, Trap.Options.Bottom));
            Traps.Add(new Trap(7650, 475, Trap.Options.Bottom));
            Blocks.Add(new Block(7700, 450, Block.Options.Box));
            Monsters.Add(new Monster(7800, 450, Monster.Options.UfoRed));
            Monsters.Add(new Monster(7800, 450, Monster.Options.UfoYellow));
            Blocks.Add(new Block(8100, 450, Block.Options.Box));
            Traps.Add(new Trap(8150, 475, Trap.Options.Bottom));
            Traps.Add(new Trap(8200, 475, Trap.Options.Bottom));
            Blocks.Add(new Block(8250, 450, Block.Options.Box));


            Blocks.Add(new Block(8350, 350, Block.Options.Ground3));
            Blocks.Add(new Block(8300, 300, Block.Options.MonsterBox));
            Blocks.Add(new Block(8500, 300, Block.Options.MonsterBox));
            Monsters.Add(new Monster(8400, 300, Monster.Options.Rat));


            Blocks.Add(new Block(8600, 250, Block.Options.Ground3));
            Blocks.Add(new Block(8550, 200, Block.Options.MonsterBox));
            Blocks.Add(new Block(8750, 200, Block.Options.MonsterBox));
            Monsters.Add(new Monster(8600, 200, Monster.Options.Rat));


            Blocks.Add(new Block(8850, 350, Block.Options.Ground3));
            Blocks.Add(new Block(8800, 300, Block.Options.MonsterBox));
            Blocks.Add(new Block(9000, 300, Block.Options.MonsterBox));
            Monsters.Add(new Monster(8850, 300, Monster.Options.Rat));


            Blocks.Add(new Block(9100, 450, Block.Options.Ground20));
            Blocks.Add(new Block(9100, 400, Block.Options.Box));
            Monsters.Add(new Monster(9200, 400, Monster.Options.UfoPurple));
            Monsters.Add(new Monster(9200, 400, Monster.Options.UfoRed));
            Monsters.Add(new Monster(9200, 400, Monster.Options.UfoYellow));
            Blocks.Add(new Block(10050, 400, Block.Options.Box));
            Blocks.Add(new Block(10000, 400, Block.Options.Box));
            Blocks.Add(new Block(9950, 400, Block.Options.Box));
            Blocks.Add(new Block(9900, 400, Block.Options.Box));
            Blocks.Add(new Block(9850, 400, Block.Options.Box));
            Blocks.Add(new Block(9800, 400, Block.Options.Box));
            Blocks.Add(new Block(9750, 400, Block.Options.Box));
            Blocks.Add(new Block(10000, 350, Block.Options.Box));
            Blocks.Add(new Block(9950, 350, Block.Options.Box));
            Blocks.Add(new Block(9900, 350, Block.Options.Box));
            Blocks.Add(new Block(9850, 350, Block.Options.Box));
            Blocks.Add(new Block(9800, 350, Block.Options.Box));
            Blocks.Add(new Block(9950, 300, Block.Options.Box));
            Blocks.Add(new Block(9900, 300, Block.Options.Box));
            Blocks.Add(new Block(9850, 300, Block.Options.Box));
            Blocks.Add(new Block(9900, 250, Block.Options.Box));
            Flag = new Flag(9923, 210);

        }

        //Level 2
        void CreateLevel2()
        {
            Blocks = new List<Block>();
            Traps = new List<Trap>();
            Clouds = new List<Cloud>();
            Monsters = new List<Monster>();

            //mraky
            Clouds.Add(new Cloud(200, 20, Cloud.Options.Cloud2));
            Clouds.Add(new Cloud(1200, 60, Cloud.Options.Cloud1));
            Clouds.Add(new Cloud(1350, 50, Cloud.Options.Cloud4));
            Clouds.Add(new Cloud(1900, 20, Cloud.Options.Cloud2));
            Clouds.Add(new Cloud(2600, 20, Cloud.Options.Cloud3));
            Clouds.Add(new Cloud(3200, 20, Cloud.Options.Cloud1));

            Blocks.Add(new Block(300, 400, Block.Options.Ground4));

            Blocks.Add(new Block(600, 300, Block.Options.Ground10));
            Traps.Add(new Trap(800, 275, Trap.Options.Bottom));
            Traps.Add(new Trap(850, 275, Trap.Options.Bottom));

            Blocks.Add(new Block(1200, 400, Block.Options.Ground2));

            Blocks.Add(new Block(1400, 500, Block.Options.Ground1));

            Blocks.Add(new Block(1550, 400, Block.Options.Ground1));

            Blocks.Add(new Block(1700, 300, Block.Options.Ground1));

            Blocks.Add(new Block(1850, 200, Block.Options.Ground1));

            Blocks.Add(new Block(2000, 300, Block.Options.Ground1));

            Blocks.Add(new Block(2150, 400, Block.Options.Ground1));

            Blocks.Add(new Block(2300, 500, Block.Options.Ground1));

            Blocks.Add(new Block(2450, 400, Block.Options.Ground5));
            Blocks.Add(new Block(2400, 350, Block.Options.MonsterBox));
            Blocks.Add(new Block(2700, 350, Block.Options.MonsterBox));
            Monsters.Add(new Monster(2500, 350, Monster.Options.Rat));
            Monsters.Add(new Monster(2600, 350, Monster.Options.Rat));


            Blocks.Add(new Block(2800, 300, Block.Options.Ground3));
            Blocks.Add(new Block(2750, 250, Block.Options.MonsterBox));
            Blocks.Add(new Block(2950, 250, Block.Options.MonsterBox));
            Monsters.Add(new Monster(2800, 250, Monster.Options.Rat));
            Monsters.Add(new Monster(2900, 250, Monster.Options.Rat));

            Blocks.Add(new Block(3050, 200, Block.Options.Ground2));
            Blocks.Add(new Block(3000, 150, Block.Options.MonsterBox));
            Blocks.Add(new Block(3150, 150, Block.Options.MonsterBox));
            Monsters.Add(new Monster(3050, 150, Monster.Options.Rat));

            Blocks.Add(new Block(3250, 300, Block.Options.Ground10));
            Blocks.Add(new Block(3200, 250, Block.Options.MonsterBox));
            Blocks.Add(new Block(3750, 250, Block.Options.MonsterBox));
            Monsters.Add(new Monster(3300, 250, Monster.Options.UfoPurple));
            Monsters.Add(new Monster(3400, 250, Monster.Options.UfoYellow));


            Blocks.Add(new Block(3850, 400, Block.Options.Ground10));
            Blocks.Add(new Block(3850, 350, Block.Options.Box));
            Blocks.Add(new Block(3900, 300, Block.Options.Box));
            Blocks.Add(new Block(3900, 350, Block.Options.Box));
            Blocks.Add(new Block(3950, 350, Block.Options.Box));
            Traps.Add(new Trap(4000, 375, Trap.Options.Bottom));
            Traps.Add(new Trap(4050, 375, Trap.Options.Bottom));
            Traps.Add(new Trap(4100, 375, Trap.Options.Bottom));
            Traps.Add(new Trap(4150, 375, Trap.Options.Bottom));
            Blocks.Add(new Block(4200, 350, Block.Options.Box));
            Blocks.Add(new Block(4250, 350, Block.Options.Box));
            Blocks.Add(new Block(4250, 300, Block.Options.Box));
            Blocks.Add(new Block(4300, 350, Block.Options.Box));


            Blocks.Add(new Block(4450, 500, Block.Options.Ground20));
            Blocks.Add(new Block(4400, 450, Block.Options.MonsterBox));
            Blocks.Add(new Block(5450, 450, Block.Options.MonsterBox));
            Monsters.Add(new Monster(4450, 450, Monster.Options.UfoRed));
            Blocks.Add(new Block(4650, 450, Block.Options.Box));
            Monsters.Add(new Monster(4800, 450, Monster.Options.UfoRed));
            Monsters.Add(new Monster(4800, 450, Monster.Options.UfoYellow));
            Monsters.Add(new Monster(4800, 450, Monster.Options.UfoPurple));
            Blocks.Add(new Block(5150, 450, Block.Options.Box));
            Monsters.Add(new Monster(5200, 450, Monster.Options.Rat));
            Monsters.Add(new Monster(5300, 450, Monster.Options.Rat));
            Monsters.Add(new Monster(5400, 450, Monster.Options.Rat));

            Blocks.Add(new Block(5600, 400, Block.Options.Ground2));
            Blocks.Add(new Block(5850, 300, Block.Options.Ground2));
            Blocks.Add(new Block(6100, 200, Block.Options.Ground2));
            Blocks.Add(new Block(6350, 300, Block.Options.Ground2));
            Blocks.Add(new Block(6600, 400, Block.Options.Ground2));


            Blocks.Add(new Block(6850, 400, Block.Options.Ground3));
            Blocks.Add(new Block(6850, 350, Block.Options.Box));
            Blocks.Add(new Block(6900, 350, Block.Options.Box));
            Blocks.Add(new Block(6900, 300, Block.Options.Box));
            Blocks.Add(new Block(6950, 350, Block.Options.Box));
            Blocks.Add(new Block(6950, 300, Block.Options.Box));
            Blocks.Add(new Block(6950, 250, Block.Options.Box));


            Blocks.Add(new Block(7200, 400, Block.Options.Ground3));
            Blocks.Add(new Block(7200, 350, Block.Options.Box));
            Blocks.Add(new Block(7200, 300, Block.Options.Box));
            Blocks.Add(new Block(7200, 250, Block.Options.Box));
            Blocks.Add(new Block(7250, 350, Block.Options.Box));
            Blocks.Add(new Block(7250, 300, Block.Options.Box));
            Blocks.Add(new Block(7300, 350, Block.Options.Box));


            Blocks.Add(new Block(7500, 300, Block.Options.Ground5));
            Blocks.Add(new Block(7450, 250, Block.Options.MonsterBox));
            Blocks.Add(new Block(7750, 250, Block.Options.MonsterBox));
            Monsters.Add(new Monster(7500, 250, Monster.Options.UfoRed));
            Monsters.Add(new Monster(7500, 250, Monster.Options.UfoYellow));

            Blocks.Add(new Block(7850, 400, Block.Options.Ground1));

            Blocks.Add(new Block(8000, 500, Block.Options.Ground1));

            Blocks.Add(new Block(8150, 400, Block.Options.Ground1));

            Blocks.Add(new Block(8300, 300, Block.Options.Ground1));

            Blocks.Add(new Block(8450, 200, Block.Options.Ground1));

            Blocks.Add(new Block(8600, 300, Block.Options.Ground15));
            Blocks.Add(new Block(8550, 250, Block.Options.MonsterBox));
            Blocks.Add(new Block(9350, 250, Block.Options.MonsterBox));
            Monsters.Add(new Monster(8600, 250, Monster.Options.UfoRed));
            Monsters.Add(new Monster(8600, 250, Monster.Options.UfoYellow));
            Monsters.Add(new Monster(8600, 250, Monster.Options.UfoPurple));
            Monsters.Add(new Monster(8900, 250, Monster.Options.Rat));
            Monsters.Add(new Monster(8600, 250, Monster.Options.Rat));


            Blocks.Add(new Block(9550, 450, Block.Options.Ground15));
            Blocks.Add(new Block(9550, 400, Block.Options.Box));
            Blocks.Add(new Block(9550, 350, Block.Options.Box));
            Blocks.Add(new Block(9600, 400, Block.Options.Box));

            Blocks.Add(new Block(10050, 400, Block.Options.Box));
            Blocks.Add(new Block(10000, 400, Block.Options.Box));
            Blocks.Add(new Block(9950, 400, Block.Options.Box));
            Blocks.Add(new Block(9900, 400, Block.Options.Box));
            Blocks.Add(new Block(9850, 400, Block.Options.Box));
            Blocks.Add(new Block(9800, 400, Block.Options.Box));
            Blocks.Add(new Block(9750, 400, Block.Options.Box));
            Blocks.Add(new Block(10000, 350, Block.Options.Box));
            Blocks.Add(new Block(9950, 350, Block.Options.Box));
            Blocks.Add(new Block(9900, 350, Block.Options.Box));
            Blocks.Add(new Block(9850, 350, Block.Options.Box));
            Blocks.Add(new Block(9800, 350, Block.Options.Box));
            Blocks.Add(new Block(9950, 300, Block.Options.Box));
            Blocks.Add(new Block(9900, 300, Block.Options.Box));
            Blocks.Add(new Block(9850, 300, Block.Options.Box));
            Blocks.Add(new Block(9900, 250, Block.Options.Box));
            Flag = new Flag(9923, 210);

        }

        //Level 3
        void CreateLevel3()
        {
            Blocks = new List<Block>();
            Traps = new List<Trap>();
            Clouds = new List<Cloud>();
            Monsters = new List<Monster>();

            //mraky
            Clouds.Add(new Cloud(200, 20, Cloud.Options.Cloud4));

            Clouds.Add(new Cloud(1200, 60, Cloud.Options.Cloud1));
            Clouds.Add(new Cloud(1350, 50, Cloud.Options.Cloud4));
            Clouds.Add(new Cloud(1900, 20, Cloud.Options.Cloud3));

            Clouds.Add(new Cloud(2600, 20, Cloud.Options.Cloud1));
            Clouds.Add(new Cloud(2800, 10, Cloud.Options.Cloud2));

            Clouds.Add(new Cloud(3500, 40, Cloud.Options.Cloud2));

            //zkratka   
            /*
            Blocks.Add(new Block(1350, 150, Block.Options.Ground3));
            Blocks.Add(new Block(1400, 50, Block.Options.Ground20));
            Blocks.Add(new Block(2200, 50, Block.Options.Ground20));
            Blocks.Add(new Block(3300, 50, Block.Options.Ground20));
            Blocks.Add(new Block(4400, 50, Block.Options.Ground20));
            Blocks.Add(new Block(5500, 50, Block.Options.Ground20));
            Blocks.Add(new Block(6600, 50, Block.Options.Ground20));
            Blocks.Add(new Block(7700, 50, Block.Options.Ground20));
            Blocks.Add(new Block(8800, 50, Block.Options.Ground20));
            Blocks.Add(new Block(9900, 50, Block.Options.Ground20));
            Blocks.Add(new Block(10950, 50, Block.Options.Ground20));
            */



            Blocks.Add(new Block(350, 400, Block.Options.Ground2));

            Blocks.Add(new Block(600, 300, Block.Options.Ground2));

            Blocks.Add(new Block(850, 200, Block.Options.Ground2));

            Blocks.Add(new Block(1100, 200, Block.Options.Ground2));

            Blocks.Add(new Block(1350, 300, Block.Options.Ground1));

            Blocks.Add(new Block(1550, 400, Block.Options.Ground1));

            Blocks.Add(new Block(1750, 500, Block.Options.Ground1));

            Blocks.Add(new Block(1950, 400, Block.Options.Ground1));

            Blocks.Add(new Block(2150, 300, Block.Options.Ground1));

            Blocks.Add(new Block(2350, 200, Block.Options.Ground1));


            Blocks.Add(new Block(2600, 200, Block.Options.Ground1));

            Blocks.Add(new Block(2900, 200, Block.Options.Ground1));


            Blocks.Add(new Block(3100, 300, Block.Options.Ground10));
            Blocks.Add(new Block(3100, 250, Block.Options.Box));
            Blocks.Add(new Block(3150, 250, Block.Options.Box));
            Blocks.Add(new Block(3200, 250, Block.Options.Box));
            Traps.Add(new Trap(3250, 275, Trap.Options.Bottom));
            Traps.Add(new Trap(3300, 275, Trap.Options.Bottom));
            Traps.Add(new Trap(3350, 275, Trap.Options.Bottom));
            Traps.Add(new Trap(3400, 275, Trap.Options.Bottom));
            Blocks.Add(new Block(3450, 250, Block.Options.Box));
            Blocks.Add(new Block(3500, 250, Block.Options.Box));
            Blocks.Add(new Block(3550, 250, Block.Options.Box));


            Blocks.Add(new Block(3700, 350, Block.Options.Ground15));
            Blocks.Add(new Block(3650, 300, Block.Options.MonsterBox));
            Blocks.Add(new Block(4450, 300, Block.Options.MonsterBox));
            Monsters.Add(new Monster(3700, 300, Monster.Options.UfoRed));
            Monsters.Add(new Monster(3700, 300, Monster.Options.UfoYellow));
            Monsters.Add(new Monster(3700, 300, Monster.Options.UfoPurple));
            Monsters.Add(new Monster(3700, 300, Monster.Options.Rat));


            Blocks.Add(new Block(4550, 450, Block.Options.Ground15));
            Blocks.Add(new Block(4500, 400, Block.Options.MonsterBox));
            Blocks.Add(new Block(5300, 400, Block.Options.MonsterBox));
            Monsters.Add(new Monster(4700, 400, Monster.Options.UfoRed));
            Monsters.Add(new Monster(4700, 400, Monster.Options.UfoYellow));
            Monsters.Add(new Monster(4700, 400, Monster.Options.UfoPurple));
            Monsters.Add(new Monster(4700, 400, Monster.Options.Rat));
            Monsters.Add(new Monster(4900, 400, Monster.Options.Rat));

            Blocks.Add(new Block(5400, 350, Block.Options.Ground20));
            Traps.Add(new Trap(5650, 325, Trap.Options.Bottom));
            Traps.Add(new Trap(5700, 325, Trap.Options.Bottom));
            Traps.Add(new Trap(5750, 325, Trap.Options.Bottom));
            Traps.Add(new Trap(5950, 325, Trap.Options.Bottom));
            Traps.Add(new Trap(6000, 325, Trap.Options.Bottom));
            Traps.Add(new Trap(6050, 325, Trap.Options.Bottom));


            Blocks.Add(new Block(6550, 450, Block.Options.Ground20));
            Blocks.Add(new Block(6800, 400, Block.Options.Box));
            Blocks.Add(new Block(6700, 250, Block.Options.Ground1));
            Traps.Add(new Trap(6700, 300, Trap.Options.Top));
            Traps.Add(new Trap(6900, 425, Trap.Options.Bottom));
            Blocks.Add(new Block(7100, 400, Block.Options.Box));
            Blocks.Add(new Block(7000, 250, Block.Options.Ground1));
            Traps.Add(new Trap(7000, 300, Trap.Options.Top));
            Traps.Add(new Trap(7200, 425, Trap.Options.Bottom));
            Traps.Add(new Trap(7300, 425, Trap.Options.Bottom));
            Blocks.Add(new Block(7400, 400, Block.Options.Box));
            Blocks.Add(new Block(7450, 400, Block.Options.Box));
            Blocks.Add(new Block(7450, 350, Block.Options.Box));
            Blocks.Add(new Block(7500, 400, Block.Options.Box));
            Blocks.Add(new Block(7500, 350, Block.Options.Box));
            Blocks.Add(new Block(7500, 300, Block.Options.Box));

            Blocks.Add(new Block(7700, 200, Block.Options.Ground20));
            Blocks.Add(new Block(7650, 150, Block.Options.MonsterBox));
            Blocks.Add(new Block(8700, 150, Block.Options.MonsterBox));
            Monsters.Add(new Monster(7700, 150, Monster.Options.UfoRed));
            Monsters.Add(new Monster(7700, 150, Monster.Options.UfoYellow));
            Monsters.Add(new Monster(7700, 150, Monster.Options.UfoPurple));
            Monsters.Add(new Monster(7700, 150, Monster.Options.Rat));
            Monsters.Add(new Monster(7900, 150, Monster.Options.Rat));
            Monsters.Add(new Monster(8100, 150, Monster.Options.Rat));

            Blocks.Add(new Block(8850, 300, Block.Options.Ground10));

            Blocks.Add(new Block(9450, 400, Block.Options.Ground1));


            Blocks.Add(new Block(9600, 450, Block.Options.Ground10));
            Traps.Add(new Trap(9600, 425, Trap.Options.Bottom));
            Blocks.Add(new Block(10050, 400, Block.Options.Box));
            Blocks.Add(new Block(10000, 400, Block.Options.Box));
            Blocks.Add(new Block(9950, 400, Block.Options.Box));
            Blocks.Add(new Block(9900, 400, Block.Options.Box));
            Blocks.Add(new Block(9850, 400, Block.Options.Box));
            Blocks.Add(new Block(9800, 400, Block.Options.Box));
            Blocks.Add(new Block(9750, 400, Block.Options.Box));
            Blocks.Add(new Block(10000, 350, Block.Options.Box));
            Blocks.Add(new Block(9950, 350, Block.Options.Box));
            Blocks.Add(new Block(9900, 350, Block.Options.Box));
            Blocks.Add(new Block(9850, 350, Block.Options.Box));
            Blocks.Add(new Block(9800, 350, Block.Options.Box));
            Blocks.Add(new Block(9950, 300, Block.Options.Box));
            Blocks.Add(new Block(9900, 300, Block.Options.Box));
            Blocks.Add(new Block(9850, 300, Block.Options.Box));
            Blocks.Add(new Block(9900, 250, Block.Options.Box));
            Flag = new Flag(9923, 210);

        }
    }
}
