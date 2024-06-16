using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_platformer5
{
    public partial class Level2 : Form
    {
        SoundPlayer music = new SoundPlayer();

        public List<PictureBox> blocks;
        public List<PictureBox> doors;
        public List<PictureBox> enemies;

        Timer timer1;
        readonly CreateGame modelGame;
        public Level2(Timer timer1)
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
                block7
            };
            doors = new List<PictureBox>
            {
                firePortal2,
                firePortal,
                portalToNextLevel
            };
            enemies = new List<PictureBox>
            {
                enemy,
                enemy2,
                obelisk1,
                obelisk2
            };

            portalToNextLevel.Hide();
            portalToNextLevel.Tag = "portal";
            firePortal.Tag = "fireportal1";
            obelisk1.Tag = "obelisk";
            obelisk2.Tag = "obelisk";
            enemy.Tag = "demon";
            enemy2.Tag = "demon2";

            var pictureBoxes = new List<PictureBox> { player, health,portal, block, block2, block3, obelisk1,
            obelisk2,enemy, enemy2, firePortal, firePortal2};
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.BackColor = Color.Transparent;
            }
            label1.BackColor = Color.Transparent;

            modelGame = new CreateGame(player, portal, health, blocks, doors, enemies, 390, 0,
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

            if (modelGame.game.countKeys == 2)
            {
                portalToNextLevel.Show();
                if (modelGame.game.CheckDoor())
                {
                    Level4 level4 = new Level4(timer1);
                    level4.Show();
                    Hide();    
                }
            }
        }

        private void Level2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
