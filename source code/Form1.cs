using Game_platformer5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_platformer5
{
    public partial class Level1 : Form
    {
        SoundPlayer music = new SoundPlayer();
       
        public List<PictureBox> blocks;
        public List<PictureBox> doors;
        public List<PictureBox> enemies;

        readonly CreateGame modelGame;
        public Level1()
        {
            InitializeComponent();
            music.SoundLocation = @"Resources\\2- Mazmorra.wav";

            blocks = new List<PictureBox>
            {
                block,
                block1,
                block2,
                block3   
            };
            doors = new List<PictureBox>
            {
                portalToNextLevel
            };
            enemies = new List<PictureBox>
            {
                obelisk,
                enemy    
            };

            var pictureBoxes = new List<PictureBox> { player, portal, obelisk, enemy, health};
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.BackColor = Color.Transparent;
            }

            label1.BackColor = Color.Transparent;
            portalToNextLevel.Hide();

            obelisk.Tag = "obelisk";
            enemy.Tag = "demon";
            portalToNextLevel.Tag = "portal";

            modelGame = new CreateGame(player, portal, health, blocks, doors, enemies, 100, 255,
                ClientSize.Width, ClientSize.Height, this, timer1, music);

            timer1.Interval = 80;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            music.Play();
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

            if (modelGame.game.countKeys == 1)
            {
                portalToNextLevel.Show();
                if (modelGame.game.CheckDoor())
                {
                    Level2 level2 = new Level2(timer1);
                    level2.Show();
                    Hide();   
                }
            }

        }
        

        private void Level1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}


