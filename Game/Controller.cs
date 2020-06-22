using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Controller
    {
        Model model;

        public Controller(Model model)
        {
            this.model = model;
        }

        public void Controll(string upOrDown, KeyEventArgs e)
        {
            //stisk
            if(upOrDown == "down")
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        model.Start();
                        break;
                    case Keys.Space:
                        break;
                    case Keys.Left:
                        if (model.GameStart && model.Player.Live)
                        {
                            model.Player.Run("left", true);
                        }
                        break;
                    case Keys.Up:
                        if (model.GameStart && model.Player.Live)
                        {
                            model.Player.Jump(true);
                        }
                        break;
                    case Keys.Right:
                        if (model.GameStart && model.Player.Live)
                        {
                            model.Player.Run("right", true);
                        }
                        break;
                    case Keys.Down:
                        break;
                }
            }

            //uvolnění
            if (upOrDown == "up")
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        break;
                    case Keys.Space:
                        break;
                    case Keys.Left:
                        if (model.GameStart && model.Player.Live)
                        {
                            model.Player.Run("left", false);
                        }
                        break;
                    case Keys.Up:
                        if (model.GameStart && model.Player.Live)
                        {
                            model.Player.Jump(false);
                        }
                        break;
                    case Keys.Right:
                        if (model.GameStart && model.Player.Live)
                        {
                            model.Player.Run("right", false);
                        }
                        break;
                }
            }
        }
    }
}
