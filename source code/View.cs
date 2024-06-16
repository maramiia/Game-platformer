using Game_platformer5.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game_platformer5
{ 
    public class View
    {
       
        public Image[] playerSprites;
        public List<PictureBox> blocks;
        public List<PictureBox> doors;
        public List<PictureBox> enemies;
        public PictureBox playerBox;
        public PictureBox portal;
        public PictureBox health;
        

        public bool hasGeneratedHealth = false;
        public int currentImage;
        
        public int currentSprite;
        public Enemy enemy;
        public Dictionary<string, Enemy> enemiesDictionary;
        public Dictionary<string, List<Image>> enemiesImages;
        public Dictionary<string, List<int>> currentSprites;
        public View(PictureBox playerBox, List<PictureBox> enemies,PictureBox portal,PictureBox health,
            List<PictureBox> blocks, List<PictureBox> doors)
        {
            
            currentImage = 21;
            currentSprite = 0;
            this.playerBox = playerBox;
            this.portal = portal;

            playerSprites = new Image[]
            {
                Image.FromFile(@"Resources\\gothic-hero-idle.png"),
                Image.FromFile(@"Resources\\gothic-hero-idle-left.png"),
                Image.FromFile(@"Resources\\gothic-hero-run.png"),
                Image.FromFile(@"Resources\\gothic-hero-run-left.png"),
                Image.FromFile(@"Resources\\gothic-hero-jump.png"),
                Image.FromFile(@"Resources\\gothic-hero-jump-left.png"),
                Image.FromFile(@"Resources\\gothic-hero-attack.png"),
                Image.FromFile(@"Resources\\gothic-hero-attack-left.png")
            };

            enemiesDictionary = new Dictionary<string, Enemy>
            {
                { "demon", new Enemy(55, 160, 30, 1)  },
                { "demon2", new Enemy(55, 160, 30, 1)  },
                { "obelisk",  new Enemy(60, 78, 50, 0) },
                { "ghost", new Enemy(64, 80, 40, 1) },
                { "boss", new Enemy(160, 192, 60, 3)},
                { "handEnemy", new Enemy(62, 64, 40, 1)},
                { "handEnemy2", new Enemy(62, 64, 40, 1)},
                { "wizard", new Enemy(80, 80, 50, 2)},
                { "wizard2", new Enemy(80, 80, 50, 2)}
            };
            enemiesImages = new Dictionary<string, List<Image>>
            {
                { "demon", new List<Image> { Image.FromFile(@"Resources\\hell-beast-burn.png"),
                    Image.FromFile(@"Resources\\hell-beast-idle.png") } },
                { "demon2", new List<Image> { Image.FromFile(@"Resources\\hell-beast-burn.png"),
                    Image.FromFile(@"Resources\\hell-beast-idle.png") } },
                { "ghost", new List<Image> { Image.FromFile(@"Resources\\ghost-shriek.png"),
                    Image.FromFile(@"Resources\\ghost-idle.png")} },
                { "boss", new List<Image> { Image.FromFile(@"Resources\\demon-idle.png"),
                    Image.FromFile(@"Resources\\demon-idle.png")} },
                { "handEnemy", new List<Image> { Image.FromFile(@"Resources\\HandEnemy.png"),
                    Image.FromFile(@"Resources\\HandEnemy.png")} },
                { "handEnemy2", new List<Image> { Image.FromFile(@"Resources\\HandEnemy.png"),
                    Image.FromFile(@"Resources\\HandEnemy.png")} },
                { "wizard", new List<Image> { Image.FromFile(@"Resources\\wizard attack.png"),
                    Image.FromFile(@"Resources\\wizard idle.png") } },
                 { "wizard2", new List<Image> { Image.FromFile(@"Resources\\wizard attack.png"),
                    Image.FromFile(@"Resources\\wizard idle.png") } }

            };
            currentSprites = new Dictionary<string, List<int>>
            {
                { "demon", new List<int> { 0, 5} },
                { "demon2", new List<int> { 0, 5} },
                { "ghost", new List<int> { 0, 6} },
                { "boss", new List<int>{ 0, 5} },
                { "handEnemy", new List<int> { 0, 7} },
                { "handEnemy2", new List<int> { 0, 7} },
                { "wizard", new List<int> { 0, 5} },
                { "wizard2", new List<int> { 0, 5} }
            };
            this.blocks = blocks;
            this.doors = doors;
            this.health = health;

            health.Hide();
     
            this.enemies = enemies;   
        }

        public void GenerateHealth()
        {
            if (hasGeneratedHealth) return;

            if (blocks.Count > 0)
            {
                var randomBlock = blocks[new Random().Next(blocks.Count)];
                health.Location = new Point(randomBlock.Location.X, randomBlock.Location.Y - randomBlock.Height - 15) ;
                health.Show();
                hasGeneratedHealth = true;
            }
            else
            {
                health.Hide();
            }
        }
        
        public void UpdatePortal()
        {
            portal.Image = Image.FromFile(@"Resources\\portal.png");
            portal.Location = new Point(playerBox.Location.X - 50, playerBox.Location.Y - 30);
            DoSpriteAnimation(portal.Image, 64, 75, currentImage, portal);
            currentImage++;
        }

        public void Update()
        {    
            UpdatePortal();
        }

        public void Reset()
        {
            
            currentImage = 0;
            hasGeneratedHealth = false;
            foreach (var e in enemies)
            {
                if (enemiesDictionary.ContainsKey((string)e.Tag) && (string)e.Tag == "obelisk")
                {
                    e.Image = Image.FromFile(@"Resources\\Obelisk.gif");
                }
                else if (enemiesDictionary.ContainsKey((string)e.Tag))
                {
                    e.Image = enemiesImages[(string)e.Tag][0];
                }
            }

            health.Hide();
        }
        public void DoEnemiesSprites(PictureBox e, int width, int height,
            Dictionary<string, List<int>> currentSprites, string enemyType)
        {
            DoSpriteAnimation(e.Image, width, height, currentSprites[enemyType][0], e);
            if (currentSprites[enemyType][0] == currentSprites[enemyType][1]) currentSprites[enemyType][0] = 0;
            currentSprites[enemyType][0] = currentSprites[enemyType][0] + 1;
        }
        public void StartAnimation(int currentSprite, int currentAnimation, int imageWidth, int imageHeight)
        {
            DoSpriteAnimation(playerSprites[currentAnimation], imageWidth, imageHeight, currentSprite, playerBox);
        }

        public bool IsCollidingWithBlock(PictureBox pictureBox, PictureBox block)
        {
            var playerRect = new Rectangle(pictureBox.Left, pictureBox.Top, pictureBox.Width - 20, pictureBox.Height);
            var blockRect = new Rectangle(block.Left, block.Top - 5, block.Width, block.Height + 10);
            return playerRect.IntersectsWith(blockRect);
        }

        public void DoSpriteAnimation(Image playerSprites, int width, int height, int currentImage, PictureBox Box)
        {
            var oneSprite = new Bitmap(width, height);
            var newSprite = Graphics.FromImage(oneSprite);
            newSprite.DrawImage(playerSprites, 0, 0, new Rectangle(new Point(width * currentImage, 0), new Size(width, height)), GraphicsUnit.Pixel);
            Box.Image = oneSprite;
        }
    }
}
