using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_platformer5
{
    public partial class Level3 : Form
    {
        SoundPlayer music = new SoundPlayer();

        public List<PictureBox> blocks;
        public List<PictureBox> doors;
        public List<PictureBox> enemies;

        Timer timer1;
        CreateGame modelGame;

        public Level3(Timer timer1)
        {
            InitializeComponent();

            this.timer1 = timer1;
            music.SoundLocation = @"Resources\\3- Boss Fight.wav";
            blocks = new List<PictureBox>
            {
                mainBlock,
                mainBlock2,
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
                portalToNextLevel,
                
            };
            enemies = new List<PictureBox>
            {
                boss,
                ghost2,
                ghost3,
                wizard,
                handEnemy
            };

            portalToNextLevel.Hide();
            portalToNextLevel.Tag = "portal";
            boss.Tag = "boss";
            ghost2.Tag = "ghost";
            ghost3.Tag = "ghost";
            wizard.Tag = "wizard";
            handEnemy.Tag = "handEnemy";

            block.Tag = "danger";
            block7.Tag = "danger";

            var pictureBoxes = new List<PictureBox> {player, portal, health, ghost2, ghost3, boss, fireBall,
            handEnemy, wizard};
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.BackColor = Color.Transparent;
            }
            label1.BackColor = Color.Transparent;

            modelGame = new CreateGame(player, portal, health, blocks, doors, enemies, 90, 255,
                ClientSize.Width, ClientSize.Height, this, timer1, music);
            fireBall.Hide();

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
           
            boss.Location = new Point(980, 12);
            fireBall.Hide();
            

            timer1.Start();
           
        }
      
        public void update(object sender, EventArgs e)
        {
            modelGame.controller.Update(e);
            modelGame.view.Update();
            DeathEvent();
            if (boss.Image == null)
            {
                portalToNextLevel.Show();
                enemies.Clear();

                if (modelGame.game.CheckDoor())
                {
                    End end = new End();
                    end.Show();
                    this.Hide();
                    music.Stop();

                }
            }

        }


        private void Level3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
