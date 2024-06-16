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
    public partial class Level5 : Form
    {
        SoundPlayer music = new SoundPlayer();

        public List<PictureBox> blocks;
        public List<PictureBox> doors;
        public List<PictureBox> enemies;

        Timer timer1;
        readonly CreateGame modelGame;
        public Level5(Timer timer1)
        {
            InitializeComponent();

            this.timer1 = timer1;
            music.SoundLocation = @"Resources\\2- Mazmorra.wav";

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
                obelisk3,
                handEnemy,
                wizard,
                handEnemy2,
                wizard2
            };

            portalToNextLevel.Hide();
            portalToNextLevel.Tag = "portal";
            obelisk1.Tag = "obelisk";
            obelisk2.Tag = "obelisk";
            obelisk3.Tag = "obelisk";
            handEnemy.Tag = "handEnemy";
            handEnemy2.Tag = "handEnemy2";
            wizard.Tag = "wizard";
            wizard2.Tag = "wizard2";


            var pictureBoxes = new List<PictureBox> { player, health,portal, block, block2, block3, obelisk1,
            obelisk2, obelisk3, handEnemy, wizard, wizard2, handEnemy2};
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.BackColor = Color.Transparent;
            }
            label1.BackColor = Color.Transparent;

            modelGame = new CreateGame(player, portal, health, blocks, doors, enemies, 693, 0,
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
            music.Play();
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
                    Level3 level3 = new Level3(timer1);
                    level3.Show();
                    Hide();
                }
            }
        }

        

        private void Level5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
