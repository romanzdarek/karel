using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Game
{
    //okno hry
    public partial class GameWindow : Form
    {

        //rozliseni herni plochy
        public static readonly int FormWidth = 800;
        public static readonly int FormHeight = 600;

        public static Int32 startTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        //MVC
        Model model;
        View view;
        Controller controller;

        public GameWindow()
        {
            //příprava komponent
            InitializeComponent();

            //rozmer formu
            ClientSize = new Size(FormWidth, FormHeight);

            //MVC
            model = new Model();
            view = new View(model);
            controller = new Controller(model);
        }

        //herní smyčka
        private void GameLoopEvent(object sender, EventArgs e)
        {
            //překreslení
            Invalidate();
            //herní smyčka
            model.Loop();
        }

        //stisk klávesy
        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            controller.Controll("down", e);
        }

        //uvolnění klávesy
        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            controller.Controll("up", e);
        }

        //vykreslování
        private void PaintEvent(object sender, PaintEventArgs e)
        {
            view.Draw(e);
        }

        private void GameWindowClick(object sender, EventArgs e)
        {
            if(GameWindow.startTime + 4 >= DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds)
            Process.Start("https://www.itnetwork.cz/");
        }
    }
}
