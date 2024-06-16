using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_platformer5
{
    public partial class Level4 : Form
    {
        SoundPlayer music = new SoundPlayer();

        public List<PictureBox> blocks;
        public List<PictureBox> doors;
        public List<PictureBox> enemies;

        Timer timer1;
        readonly CreateGame modelGame;
        public Level4(Timer timer1)
        {
            InitializeComponent();
            music.SoundLocation = @"Resources\\2- Mazmorra.wav";
            this.timer1 = timer1;


            blocks = new List<PictureBox>
            {
                block,
                block2,
                block3,
                block4,
                block5,
                block6,
                block7,
                block8
            };
            doors = new List<PictureBox>
            {
                portalToNextLevel
            };
            enemies = new List<PictureBox>
            {
                obelisk1,
                obelisk2,
                obelisk3
            };

            portalToNextLevel.Hide();
            portalToNextLevel.Tag = "portal";
            obelisk1.Tag = "obelisk";
            obelisk2.Tag = "obelisk";
            obelisk3.Tag = "obelisk";
            block2.Tag = "danger";
            block.Tag = "danger";
            block6.Tag = "danger";
            block7.Tag = "danger";

            var pictureBoxes = new List<PictureBox> { player, health,portal, block, block2, block3, obelisk1,
            obelisk2, obelisk3};
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.BackColor = Color.Transparent;
            }
            label1.BackColor = Color.Transparent;

            modelGame = new CreateGame(player, portal, health, blocks, doors, enemies, 500, 0,
               ClientSize.Width, ClientSize.Height, this, timer1, music);

            timer1.Interval = 80;
            timer1.Tick += new EventHandler(update);
            timer1.Start();

            KeyDown += modelGame.KeyIsDown;
            KeyUp += modelGame.KeyIsUp;
            MouseDown += modelGame.MouseIsDown;
        }
        public void DeathEvent()
        {
            if (modelGame.game.player.Health > 1)
            {
                healthBar.Value = (int)modelGame.game.player.Health;
            }
            else
            {
                music.Stop();
                RestartGame();
            }
        }
        public void RestartGame()
        {
            music.Play();
            modelGame.Reset();
            healthBar.Value = (int)modelGame.game.player.Health;
            portalToNextLevel.Hide();
            timer1.Start();
        }

        public void update(object sender, EventArgs e)
        {
            modelGame.controller.Update(e);
            modelGame.view.Update();

            DeathEvent();

            if (modelGame.game.countKeys == 3)
            {
                portalToNextLevel.Show();
                if (modelGame.game.CheckDoor())
                {
                    Level5 level5 = new Level5(timer1);
                    level5.Show();
                    Hide();
                }
            }
        }

        private void Level4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
