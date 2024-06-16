using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_platformer5
{
    public class CreateGame
    {
        public Controller controller;
        public Model game;
        public View view;

        public List<PictureBox> blocks;
        public List<PictureBox> doors;
        public List<PictureBox> enemies;

        public CreateGame(PictureBox player, PictureBox portal, PictureBox health,
            List<PictureBox> blocks, List<PictureBox> doors, List<PictureBox> enemies, int x, int y,
            int clientSizeWidth, int clientSizeHeight, Form form, Timer timer1, SoundPlayer music)
        {

            view = new View(player, 
                enemies, portal, health, blocks, doors);
            game = new Model(player, x, y, view, clientSizeHeight, clientSizeWidth);
            controller = new Controller(game, view, form, timer1, music);
        }

        public void Reset()
        {
            game.Reset();
            view.Reset();
            controller.Reset();
        }
        public void KeyIsUp(object sender, KeyEventArgs e)
        {
            controller.KeyIsUp(e);
        }

        public void KeyIsDown(object sender, KeyEventArgs e)
        {
            controller.KeyIsDown(e);
        }
        public void MouseIsDown(object sender, MouseEventArgs e)
        {
            controller.MouseIsDown(e);
        }

    }
}
