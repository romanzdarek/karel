using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class View
    {
        Model model;
        int playerAnimeTimer;
        int gameOverAnimeTimer;
        int levelEndAnimeTimer;
        int ratAnimeTimer;
        int ufoAnimeTimer;
        int flagAnimeTimer;

        Image ITNetwork = Properties.Resources.Itnetwork;

        //player
        Image playerRight1 = Properties.Resources.PlayerRight1;
        Image playerRight2 = Properties.Resources.PlayerRight2;
        Image playerRight3 = Properties.Resources.PlayerRight3;
        Image playerLeft1 = Properties.Resources.PlayerLeft1;
        Image playerLeft2 = Properties.Resources.PlayerLeft2;
        Image playerLeft3 = Properties.Resources.PlayerLeft3;

        //země
        Image ground1 = Properties.Resources.Ground1;
        Image ground2 = Properties.Resources.Ground2;
        Image ground3 = Properties.Resources.Ground3;
        Image ground4 = Properties.Resources.Ground4;
        Image ground5 = Properties.Resources.Ground5;
        Image ground10 = Properties.Resources.Ground10;
        Image ground15 = Properties.Resources.Ground15;
        Image ground20 = Properties.Resources.Ground20;

        //pasti
        Image bottomTrap = Properties.Resources.BottomTrap;
        Image topTrap = Properties.Resources.TopTrap;

        //mraky
        Image claud1 = Properties.Resources.Claud1;
        Image claud2 = Properties.Resources.Claud2;
        Image claud3 = Properties.Resources.Claud3;
        Image claud4 = Properties.Resources.Claud4;

        //krysa
        Image ratRight1 = Properties.Resources.RatRight1;
        Image ratRight2 = Properties.Resources.RatRight2;
        Image ratLeft1 = Properties.Resources.RatLeft1;
        Image ratLeft2 = Properties.Resources.RatLeft2;

        //Ufo
        Image ufoYellowRight1 = Properties.Resources.UfoYellowRight1;
        Image ufoYellowRight2 = Properties.Resources.UfoYellowRight2;
        Image ufoYellowLeft1 = Properties.Resources.UfoYellowLeft1;
        Image ufoYellowLeft2 = Properties.Resources.UfoYellowLeft2;

        Image ufoRedRight1 = Properties.Resources.UfoRedRight1;
        Image ufoRedRight2 = Properties.Resources.UfoRedRight2;
        Image ufoRedLeft1 = Properties.Resources.UfoRedLeft1;
        Image ufoRedLeft2 = Properties.Resources.UfoRedLeft2;

        Image ufoPurpleRight1 = Properties.Resources.UfoPurpleRight1;
        Image ufoPurpleRight2 = Properties.Resources.UfoPurpleRight2;
        Image ufoPurpleLeft1 = Properties.Resources.UfoPurpleLeft1;
        Image ufoPurpleLeft2 = Properties.Resources.UfoPurpleLeft2;

        //zbytek
        Image blood = Properties.Resources.Blood;
        Image flag = Properties.Resources.Flag;
        Image flag2 = Properties.Resources.Flag2;
        Image heart = Properties.Resources.Heart;
        Image box = Properties.Resources.Box;

        Font font;

        public View (Model model)
        {
            this.model = model;
            playerAnimeTimer = 0;
            gameOverAnimeTimer = 0;
            levelEndAnimeTimer = 0;
            ufoAnimeTimer = 0;
            flagAnimeTimer = 0;
            ratAnimeTimer = 0;
        }

        //co se bude vykreslovat?
        public void Draw(PaintEventArgs e)
        {
            //dohráno
            if (model.GameEnd)
            {
                DrawEndScreen(e);
            }
            //ještě není dohráno
            else
            {
                //úvodní obrazovka
                if (!model.GameStart && !model.GameOver)
                {
                    DrawStartScreen(e);
                }
                //gameOver
                else if (!model.GameStart && model.GameOver)
                {
                    DrawOverScreen(e);
                }
                //hra
                else
                {
                    DrawGame(e);
                }
            }
        }

        //dokončení hry
        public void DrawEndScreen(PaintEventArgs e)
        {
            //pozadí
            e.Graphics.FillRectangle(Brushes.Black, 0, 0, GameWindow.FormWidth, GameWindow.FormHeight);
            //nápisy
            font = new Font("arial", 100);
            e.Graphics.DrawString("Dohráno", font, Brushes.White, 130, 200);
            font = new Font("arial", 24);
            e.Graphics.DrawString("Stiskni ENTER a hrej znovu", font, Brushes.White, 155, 330);
        }

        public void DrawStartScreen(PaintEventArgs e)
        {
            //pozadí
            e.Graphics.FillRectangle(Brushes.Black, 0, 0, GameWindow.FormWidth, GameWindow.FormHeight);
            //nápisy
            font = new Font("arial", 100);
            e.Graphics.DrawString("Karel", font, Brushes.White, 220, 200);
            font = new Font("arial", 24);
            e.Graphics.DrawString("Stiskni ENTER a hrej", font, Brushes.White, 245, 330);
            //ITNetwork
            if (GameWindow.startTime + 4 >= DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds)
                e.Graphics.DrawImage(ITNetwork, 0, 75, 800, 450);
        }

        //gameOver
        public void DrawOverScreen(PaintEventArgs e)
        {
            //pozadí
            e.Graphics.FillRectangle(Brushes.Black, 0, 0, GameWindow.FormWidth, GameWindow.FormHeight);
            font = new Font("arial", 100);
            e.Graphics.DrawString("Prohra", font, Brushes.White, 180, 200);
            font = new Font("arial", 24);
            e.Graphics.DrawString("Stiskni ENTER a hrej znovu", font, Brushes.White, 205, 330);
        }

        //vykreslení hry
        //tip na optimalizaci - před vykreslením zkontrolovat zda je vůbec nutné vykreslovat, vykreslovat jen když je objekt viditelný
        public void DrawGame(PaintEventArgs e)
        {
            //pozadí
            e.Graphics.FillRectangle(Brushes.SkyBlue, 0, 0, GameWindow.FormWidth, GameWindow.FormHeight);

            //animace pozadí konec levelu
            if (model.Player.LevelEnd())
            {
                if (levelEndAnimeTimer < 4)
                {
                    e.Graphics.FillRectangle(Brushes.Lime, 0, 0, GameWindow.FormWidth, GameWindow.FormHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.GreenYellow, 0, 0, GameWindow.FormWidth, GameWindow.FormHeight);
                }
                levelEndAnimeTimer++;
                levelEndAnimeTimer = (levelEndAnimeTimer == 8) ? 0 : levelEndAnimeTimer;
            }

            //animace pozadí smrti
            if (!model.Player.Live)
            {
                if (gameOverAnimeTimer < 3)
                {
                    e.Graphics.FillRectangle(Brushes.Red, 0, 0, GameWindow.FormWidth, GameWindow.FormHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Pink, 0, 0, GameWindow.FormWidth, GameWindow.FormHeight);
                }
                gameOverAnimeTimer++;
                gameOverAnimeTimer = (gameOverAnimeTimer == 6) ? 0 : gameOverAnimeTimer;
            }

            //mraky
            foreach (var cloud in Model.World.Clouds)
            {
                switch (cloud.Type)
                {
                    case Cloud.Options.Cloud1:
                        e.Graphics.DrawImage(claud1, cloud.X, cloud.Y);
                        break;
                    case Cloud.Options.Cloud2:
                        e.Graphics.DrawImage(claud2, cloud.X, cloud.Y);
                        break;
                    case Cloud.Options.Cloud3:
                        e.Graphics.DrawImage(claud3, cloud.X, cloud.Y);
                        break;
                    case Cloud.Options.Cloud4:
                        e.Graphics.DrawImage(claud4, cloud.X, cloud.Y);
                        break;
                }
            }

            //bloky
            foreach (Block block in Model.World.Blocks)
            {
                switch (block.Type)
                {
                    case Block.Options.Ground1:
                        e.Graphics.DrawImage(ground1, block.X, block.Y);
                        break;
                    case Block.Options.Ground2:
                        e.Graphics.DrawImage(ground2, block.X, block.Y);
                        break;
                    case Block.Options.Ground3:
                        e.Graphics.DrawImage(ground3, block.X, block.Y);
                        break;
                    case Block.Options.Ground4:
                        e.Graphics.DrawImage(ground4, block.X, block.Y);
                        break;
                    case Block.Options.Ground5:
                        e.Graphics.DrawImage(ground5, block.X, block.Y);
                        break;
                    case Block.Options.Ground10:
                        e.Graphics.DrawImage(ground10, block.X, block.Y);
                        break;
                    case Block.Options.Ground15:
                        e.Graphics.DrawImage(ground15, block.X, block.Y);
                        break;
                    case Block.Options.Ground20:
                        e.Graphics.DrawImage(ground20, block.X, block.Y);
                        break;
                    case Block.Options.Box:
                        e.Graphics.DrawImage(box, block.X, block.Y);
                        break;
                    case Block.Options.MonsterBox:
                        //e.Graphics.FillRectangle(Brushes.DarkGray, block.X, block.Y, block.Width, block.Height);
                        break;
                }
            }

            //pasti
            foreach (Trap trap in Model.World.Traps)
            {
                switch (trap.Type)
                {
                    case Trap.Options.Bottom:
                        e.Graphics.DrawImage(bottomTrap, trap.X, trap.Y);
                        break;
                    case Trap.Options.Top:
                        e.Graphics.DrawImage(topTrap, trap.X, trap.Y);
                        break;
                }
            }

            //vlajka
            if (!model.Player.Live || model.Player.LevelEnd())
            {
                e.Graphics.DrawImage(flag, Model.World.Flag.X, Model.World.Flag.Y);
            }
            else
            {
                if (flagAnimeTimer < 4)
                {
                    e.Graphics.DrawImage(flag, Model.World.Flag.X, Model.World.Flag.Y);
                }
                else
                {
                    e.Graphics.DrawImage(flag2, Model.World.Flag.X, Model.World.Flag.Y);
                }
                flagAnimeTimer++;
                flagAnimeTimer = (flagAnimeTimer == 8) ? 0 : flagAnimeTimer;
            }

            //monstra
            foreach (var monster in Model.World.Monsters)
            {
                switch (monster.Type)
                {
                    case Monster.Options.Rat:
                        //živá
                        if (monster.Live)
                        {
                            //pokud je player dead nebo je konec levelu nebude animace
                            if (!model.Player.Live || model.Player.LevelEnd())
                            {
                                if (monster.Direction == "right")
                                {
                                    e.Graphics.DrawImage(ratRight1, monster.X, monster.Y);
                                }
                                else
                                {
                                    e.Graphics.DrawImage(ratLeft1, monster.X, monster.Y);
                                }
                            }
                            //jinak animuj pohyb
                            else
                            {
                                if (monster.Direction == "right")
                                {
                                    if (ratAnimeTimer < 4)
                                    {
                                        e.Graphics.DrawImage(ratRight1, monster.X, monster.Y);
                                    }
                                    else
                                    {
                                        e.Graphics.DrawImage(ratRight2, monster.X, monster.Y);
                                    }
                                }
                                else
                                {
                                    if (ratAnimeTimer < 4)
                                    {
                                        e.Graphics.DrawImage(ratLeft1, monster.X, monster.Y);
                                    }
                                    else
                                    {
                                        e.Graphics.DrawImage(ratLeft2, monster.X, monster.Y);
                                    }
                                }
                            }
                        }
                        //mrtvá, zobrazíme krev
                        else
                        {
                            e.Graphics.DrawImage(blood, monster.X, monster.Y);
                        }
                        break;

                    case Monster.Options.UfoYellow:
                        //pokud je player dead nebo je konec levelu nebude animace
                        if (!model.Player.Live || model.Player.LevelEnd())
                        {
                            if (monster.Direction == "right")
                            {
                                e.Graphics.DrawImage(ufoYellowRight1, monster.X, monster.Y);
                            }
                            else
                            {
                                e.Graphics.DrawImage(ufoYellowLeft2, monster.X, monster.Y);
                            }
                        }
                        //jinak animuj pohyb
                        else
                        {
                            if (monster.Direction == "right")
                            {
                                if (ufoAnimeTimer < 6)
                                {
                                    e.Graphics.DrawImage(ufoYellowRight1, monster.X, monster.Y);
                                }
                                else
                                {
                                    e.Graphics.DrawImage(ufoYellowRight2, monster.X, monster.Y);
                                }
                            }
                            else
                            {
                                if (ufoAnimeTimer < 6)
                                {
                                    e.Graphics.DrawImage(ufoYellowLeft1, monster.X, monster.Y);
                                }
                                else
                                {
                                    e.Graphics.DrawImage(ufoYellowLeft2, monster.X, monster.Y);
                                }
                            }
                        }
                        break;

                    case Monster.Options.UfoRed:
                        //pokud je player dead nebo je konec levelu nebude animace
                        if (!model.Player.Live || model.Player.LevelEnd())
                        {
                            if (monster.Direction == "right")
                            {
                                e.Graphics.DrawImage(ufoRedRight1, monster.X, monster.Y);
                            }
                            else
                            {
                                e.Graphics.DrawImage(ufoRedLeft2, monster.X, monster.Y);
                            }
                        }
                        //jinak animuj pohyb
                        else
                        {
                            if (monster.Direction == "right")
                            {
                                if (ufoAnimeTimer < 6)
                                {
                                    e.Graphics.DrawImage(ufoRedRight1, monster.X, monster.Y);
                                }
                                else
                                {
                                    e.Graphics.DrawImage(ufoRedRight2, monster.X, monster.Y);
                                }
                            }
                            else
                            {
                                if (ufoAnimeTimer < 6)
                                {
                                    e.Graphics.DrawImage(ufoRedLeft1, monster.X, monster.Y);
                                }
                                else
                                {
                                    e.Graphics.DrawImage(ufoRedLeft2, monster.X, monster.Y);
                                }
                            }
                        }
                        break;

                    case Monster.Options.UfoPurple:
                        //pokud je player dead nebo je konec levelu nebude animace
                        if (!model.Player.Live || model.Player.LevelEnd())
                        {
                            if (monster.Direction == "right")
                            {
                                e.Graphics.DrawImage(ufoPurpleRight1, monster.X, monster.Y);
                            }
                            else
                            {
                                e.Graphics.DrawImage(ufoPurpleLeft2, monster.X, monster.Y);
                            }
                        }
                        //jinak animuj pohyb
                        else
                        {
                            if (monster.Direction == "right")
                            {
                                if (ufoAnimeTimer < 6)
                                {
                                    e.Graphics.DrawImage(ufoPurpleRight1, monster.X, monster.Y);
                                }
                                else
                                {
                                    e.Graphics.DrawImage(ufoPurpleRight2, monster.X, monster.Y);
                                }
                            }
                            else
                            {
                                if (ufoAnimeTimer < 6)
                                {
                                    e.Graphics.DrawImage(ufoPurpleLeft1, monster.X, monster.Y);
                                }
                                else
                                {
                                    e.Graphics.DrawImage(ufoPurpleLeft2, monster.X, monster.Y);
                                }
                            }
                        }
                        break;
                    default:
                        e.Graphics.FillRectangle(Brushes.Brown, monster.X, monster.Y, monster.Width, monster.Height);
                        break;
                }
            }

            //časovače animací
            ratAnimeTimer++;
            ratAnimeTimer = (ratAnimeTimer == 8) ? 0 : ratAnimeTimer;

            ufoAnimeTimer++;
            ufoAnimeTimer = (ufoAnimeTimer == 12) ? 0 : ufoAnimeTimer;

            //player
            //e.Graphics.FillRectangle(Brushes.Blue, model.Player.X, model.Player.Y, model.Player.Width, model.Player.Height);

            //dead - bez animace
            if (!model.Player.Live)
            {
                if(model.Player.Direction == "right")
                {
                    e.Graphics.DrawImage(playerRight2, model.Player.X, model.Player.Y);
                }
                else
                {
                    e.Graphics.DrawImage(playerLeft2, model.Player.X, model.Player.Y);
                }
            }
            //ziju - animuj
            else
            {
                //směr doprava
                if (model.Player.Direction == "right")
                {
                    //skáču nebo padám
                    if (model.Player.JumpTimer > 0 || model.Player.FallTimer > 0)
                    {
                        e.Graphics.DrawImage(playerRight3, model.Player.X, model.Player.Y);
                    }
                    //jsem na zemi
                    else
                    {
                        //stojím
                        if (!model.Player.Moving)
                        {
                            e.Graphics.DrawImage(playerRight1, model.Player.X, model.Player.Y);
                        }
                        //jdu
                        else
                        {
                            //animace chůze...
                            if (playerAnimeTimer < 4)
                            {
                                e.Graphics.DrawImage(playerRight1, model.Player.X, model.Player.Y);

                            }
                            else
                            {
                                e.Graphics.DrawImage(playerRight2, model.Player.X, model.Player.Y);

                            }
                            playerAnimeTimer++;
                            playerAnimeTimer = (playerAnimeTimer == 8) ? 0 : playerAnimeTimer;
                        }
                    }
                }
                //směr doleva
                else
                {
                    //skáču nebo padám
                    if (model.Player.JumpTimer > 0 || model.Player.FallTimer > 0)
                    {
                        e.Graphics.DrawImage(playerLeft3, model.Player.X, model.Player.Y);
                    }
                    //jsem na zemi
                    else
                    {
                        //stojím
                        if (!model.Player.Moving)
                        {
                            e.Graphics.DrawImage(playerLeft1, model.Player.X, model.Player.Y);
                        }
                        //jdu
                        else
                        {
                            //animace chůze...
                            if (playerAnimeTimer < 4)
                            {
                                e.Graphics.DrawImage(playerLeft1, model.Player.X, model.Player.Y);

                            }
                            else
                            {
                                e.Graphics.DrawImage(playerLeft2, model.Player.X, model.Player.Y);

                            }
                            playerAnimeTimer++;
                            playerAnimeTimer = (playerAnimeTimer == 8) ? 0 : playerAnimeTimer;
                        }
                    }
                }
            }
            
            //životy
            if(model.Lives > 0)
            {
                e.Graphics.DrawImage(heart, 690, 10);
            }
            if(model.Lives > 1)
            {
                e.Graphics.DrawImage(heart, 730, 10);
            }
            if (model.Lives > 2)
            {
                e.Graphics.DrawImage(heart, 770, 10);
            }
        } 
    }
}
