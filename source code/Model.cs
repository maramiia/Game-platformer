using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Game_platformer5
{
    public class Model
    {
        public int height;
        public int width;
        public View view;
        public int countKeys;

        private Random random = new Random();
        public Player player;
        public int VelocityX;
        public int VelocityY;
        public int x;
        public int y;

        public bool isOnGround { get; set; }
        public PictureBox pictureBox;
        public List<PictureBox> blocks;
        readonly List<PictureBox> doors;

        public int count;
        public int countClick;
        public bool fight;

        public Rectangle wizardBlock;
        public Model(PictureBox pictureBox,int x, int y, View view, int height, int width)
        {
            this.x = x;
            this.y = y;
            player = new Player(new Point(x, y), 100, 5);
            VelocityX = player.VelocityX;
            VelocityY = player.VelocityY;

            isOnGround = true;

            this.pictureBox = pictureBox;
            blocks = view.blocks;
            doors = view.doors;
            this.view = view;

            fight = false;
            countClick = 0;
            count = 0;

            countKeys = 0;
            this.height = height;
            this.width = width;

        }
        public void CheckWindowSize()
        {
            var windowHeight = height;
            var windowWidth = width;
            if (player.Position.X < 0)
            {
                player.Position.X = 0;
            }
            else if (player.Position.X + pictureBox.Width > windowWidth)
            {
                player.Position.X = windowWidth - pictureBox.Width;
            }

            if (player.Position.Y < 0)
            {
                player.Position.Y = 0;
            }
            else if (player.Position.Y + pictureBox.Height > windowHeight)
            {
                player.Position.Y = windowHeight - pictureBox.Height;
                player.Health = 0;
            }
        }
    
        public void MoveEnemies()
        {
            if (player.Health < 75)
            {
                view.GenerateHealth();

                if (view.IsCollidingWithBlock(view.playerBox, view.health))
                {
                    player.Health += 25;
                    view.health.Hide();
                    view.hasGeneratedHealth = false;
                }
            }

            var enemies = view.enemies;
            var enemiesDictionary = view.enemiesDictionary;
            var playerBox = view.playerBox;
            _ = view.enemy;
            var enemiesImages = view.enemiesImages;
            var currentSprites = view.currentSprites;

            foreach (var e in enemies)
            {
                if (enemiesDictionary.ContainsKey((string)e.Tag) && (string)e.Tag == "obelisk")
                {
                    if (Death(playerBox, e, enemiesDictionary[(string)e.Tag].Health))
                    {
                        e.Image = null;
                        countKeys += 1;
                    }
                }
                else if (enemiesDictionary.ContainsKey((string)e.Tag))
                {
                    var enemyType = (string)e.Tag;
                    var enemy = enemiesDictionary[enemyType];
                    if (view.IsCollidingWithBlock(playerBox, e) && e.Image != null)
                    {
                        e.Image = enemiesImages[enemyType][0];

                        view.DoEnemiesSprites(e, enemy.Width, enemy.Height, currentSprites, enemyType);
                        player.Health -= enemy.Power;
                    }
                    else if (!view.IsCollidingWithBlock(playerBox, e) && e.Image != null)
                    {

                        e.Image = enemiesImages[enemyType][1];
                        view.DoEnemiesSprites(e, enemy.Width, enemy.Height, currentSprites, enemyType);
                        
                    }

                    if (Death(playerBox, e, enemy.Health))
                    {
                        e.Image = null;
                    }


                    if (enemiesDictionary.ContainsKey((string)e.Tag) && ((string)e.Tag == "ghost"
                        || (string)e.Tag == "ghost2") && e.Image != null)
                    {
                        if (e.Visible)
                        {
                            var playerLocation = playerBox.Location;
                            int speed = 2;
                            if (e.Location.X <= playerLocation.X - 20)
                            {
                                e.Location = new Point(e.Location.X + speed, e.Location.Y);
                            }
                            else if (e.Location.X >= playerLocation.X + 20)
                            {
                                e.Location = new Point(e.Location.X - speed, e.Location.Y);
                            }
                        }
                        else
                        {
                            e.Location = new Point(e.Location.X,e.Location.Y);
                        }
                    }

                    if (enemiesDictionary.ContainsKey((string)e.Tag) && (string)e.Tag == "boss")
                    {
                        if (e.Visible)
                        {
                            var playerLocation = playerBox.Location;
                            int speed = 3;

                            if (e.Location.Y <= playerLocation.Y - 30)
                            {
                                e.Location = new Point(e.Location.X, e.Location.Y + speed);
                            }
                            else if (e.Location.Y >= playerLocation.Y - 30)
                            {
                                e.Location = new Point(e.Location.X, e.Location.Y - speed);
                            }
                        }

                    }
                }
            }
        }
        public void Reset()
        {
            player = new Player(new Point(x, y), 100, 5);
            isOnGround = true;

            countKeys = 0;
            countClick = 0;
            count = 0;
            fight = false;
        }
        public bool Fight(int countCLick, int enemyHealth)
        {
            if (countCLick * player.Power - enemyHealth >= 0)
            {
                return true;
            }
            return false;
        }

        public bool Death(PictureBox playerBox, PictureBox enemy, int enemyHealth)
        {
            if (view.IsCollidingWithBlock(playerBox, enemy) && fight == true)
            {
                fight = false;
                if (Fight(countClick, enemyHealth))
                {
                    countClick = 0;
                    fight = true;
                    return true;
                }
                else
                {
                    countClick += 1;
                }
                return false;
            }
            
            return false;
        }

        public bool CheckDoor()
        {  
            foreach (var door in doors)
            {
                if (view.IsCollidingWithBlock(pictureBox, door) && door.Visible
                    && (string)door.Tag == "portal")
                {
                    return true;
                }
                else if (view.IsCollidingWithBlock(pictureBox, door) && (string)door.Tag == "fireportal1")
                {
                    player.Position = new Point(65, -500);  
                }
                else if (view.IsCollidingWithBlock(pictureBox, door))
                {
                    player.Position = new Point(655, -500);
                }
            }
            return false;
        }
        public void CheckBlock()
        {
            foreach (var block in blocks)
            {
                if (view.IsCollidingWithBlock(view.playerBox, block) && (string)block.Tag == "danger")
                {
                    player.Health -= 1;
                }
            }
        }




        public void Collision(Image[] playerSprites, int currentAnimation)
        {
            PictureBox currentBlock = null;

            player.Position = new Point(player.Position.X + VelocityX, player.Position.Y + VelocityY);
            VelocityY = 0;
            VelocityX = 0;
            VelocityY += 50;

            if (currentBlock != null && view.IsCollidingWithBlock(pictureBox, currentBlock))
            {
                player.Position = new Point(player.Position.X, currentBlock.Top - pictureBox.Height);

                VelocityY = 0;
                VelocityX = 0;
                isOnGround = true;
            }
            else
            {
                foreach (var block in blocks)
                {
                    if (view.IsCollidingWithBlock(pictureBox, block))
                    {
                        currentBlock = block;
                        player.Position = new Point(player.Position.X, block.Top - playerSprites[currentAnimation].Height);
                        VelocityY = 0;
                        VelocityX = 0;
                        isOnGround = true;
                        break;
                    }

                }

                if (currentBlock == null)
                {
                    isOnGround = false;
                }
            }
        }
        
        public void Rest()
        {
            player.Position = new Point(player.Position.X, player.Position.Y);
        }

        public void MoveRight()
        {
            player.Position.X += 6;
        }

        public void MoveLeft()
        {
            player.Position.X -= 6;
        }

        public void Jump()
        {
            if (isOnGround)
            {
                VelocityY -= 80;
                VelocityX = 0;
                isOnGround = false;
            }
        }

        public void JumpRight()
        {
            if (isOnGround)
            {
                VelocityY = -80;
                VelocityX = 90;
                isOnGround = false;
            }
            else
            {
                VelocityX = 90;
            }
            isOnGround = false;
        }

        public void JumpLeft()
        {
            if (isOnGround)
            {
                VelocityY = -80;
                VelocityX = -90;
                isOnGround = false;
            }
            else
            {
                VelocityX = -90;
            }

            isOnGround = false;
        }

        public void Update()
        {
            
            CheckDoor();
            CheckWindowSize();
            MoveEnemies();
            CheckBlock();
            view.playerBox.Location = player.Position;
        }


    }
}
