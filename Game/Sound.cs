using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    static class Sound
    {
        public readonly static SoundPlayer Jump = new SoundPlayer(Properties.Resources.Jump);
        public readonly static SoundPlayer Die = new SoundPlayer(Properties.Resources.Die);
        public readonly static SoundPlayer LevelComplete = new SoundPlayer(Properties.Resources.LevelComplete);
        public readonly static SoundPlayer Kill = new SoundPlayer(Properties.Resources.Kill);
        public readonly static SoundPlayer GameOver = new SoundPlayer(Properties.Resources.GameOver);

    }
}
