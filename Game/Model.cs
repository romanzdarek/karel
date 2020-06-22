using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Game
{
    class Model
    {
        public static Random Random { get; private set; }
        public static World World { get; private set; }
        public Player Player { get; private set; }
        public int Lives { get; private set; }
        public int Level { get; private set; }

        public bool GameStart { get; private set; }
        public bool GameOver { get; private set; }
        public bool GameEnd { get; private set; }

        int gameOverTimer;
        int levelCompleteTimer;

        public Model()
        {
            Random = new Random();
            Lives = 3;
            Level = 1;//zaciname od 1
            Init(Level);
        }
        void Init(int level)
        {
            World = new World(level);
            Player = new Player();
            GameStart = false;
            GameOver = false;
            GameEnd = false;
            gameOverTimer = 0;
            levelCompleteTimer = 0;
        }
        //start
        public void Start()
        {
            
            //dohráno
            if (GameEnd)
            {
                //nastavíme zase na začátek hry pro restart
                Level = 1;
                Lives = 3;
                Init(Level);
            }
            //první spuštění
            else if(!GameStart && !GameOver)
            {
                GameStart = true;
            }
            //GameOver
            else if(!GameStart && GameOver)
            {
                Init(1);
            }
        }

        //herní smyčka
        public void Loop()
        {
            //hra běží
            if(GameStart && !GameOver)
            {
                //hráč se může pohybovat dokud je naživu
                if (Player.Live)
                {
                    //není konec levelu?
                    if (Player.LevelEnd())
                    {
                        if (levelCompleteTimer == 0) Sound.LevelComplete.Play();
                        levelCompleteTimer++;
                        if(levelCompleteTimer == 80)
                        {
                            if (Level < 3)
                            {
                                //další level
                                Level++;
                                Init(Level);
                                GameStart = true;
                            }
                            else
                            {
                                //dohráli jsme...
                                GameEnd = true;
                                GameStart = false;
                            }
                            levelCompleteTimer = 0;
                        }
                    }
                    //stále hrajem
                    else
                    {
                        //pohyb hráče
                        Player.Move();
                        //pohyb monster
                        foreach (var monster in World.Monsters)
                        {
                            if (monster.Live)
                            {
                                monster.AI();
                            }
                        }
                        //pohyb mraků
                        foreach (Cloud cloud in World.Clouds)
                        {
                            cloud.Shift(-5);
                            if (cloud.Recycle()) cloud.ToStart();
                        }
                    }
                }
                //smrt
                else
                {
                    if(gameOverTimer == 0) Sound.Die.Play();
                    Player.DeadAnimate();
                    gameOverTimer++;
                    if(gameOverTimer == 33)
                    {
                        gameOverTimer = 0;
                        Lives--;

                        if(Lives == 0)
                        {
                            //gameover
                            GameOver = true;
                            GameStart = false;
                            Level = 1;
                            Lives = 3;
                            Sound.GameOver.Play();
                        }
                        else
                        {
                            //restart
                            Init(Level);
                            GameStart = true;
                        }
                    }
                }
            }
        }
    }
}
