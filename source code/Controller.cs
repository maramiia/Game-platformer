using System;
using System.Media;
using System.Windows.Forms;

namespace Game_platformer5
{
    public class Controller
    {
        public Model game;
        View view;
        int currentSprite;
        int currentAnimation;
        Timer timer1;
        Form form;
        SoundPlayer music;

        public bool fight;
        enum Direction
        {
            Stand,
            Right,
            Left
        }
        Direction direction;
        public Controller(Model game, View view, Form form, Timer timer1, SoundPlayer music)
        {
            this.game = game;
            this.view = view;
            this.form = form;
            this.timer1 = timer1;
            this.music = music;

            currentSprite = 0;
            currentAnimation = 0;
        }
        public void Reset()
        {
            currentSprite = 0;
            currentAnimation = 0;
            direction = Direction.Stand;
            game.fight = false;
            game.Rest();
            view.playerBox.Image = view.playerSprites[currentAnimation];
        }

        public void KeyIsUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Space)
            {
                currentSprite = 0;
                currentAnimation = 0;
                view.StartAnimation(currentSprite, currentAnimation, 38, 48);
                game.Rest();
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Space)
            {
                currentSprite = 3;
                currentAnimation = 1;
                view.StartAnimation(currentSprite, currentAnimation, 38, 48);
                game.Rest();

            }

        }
        public void KeyIsDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                currentAnimation = 2;
                view.StartAnimation(currentSprite, currentAnimation, 66, 48);
                direction = Direction.Right;
                game.MoveRight();
            }
            else if (e.KeyCode == Keys.A)
            {
                currentAnimation = 3;
                view.StartAnimation(currentSprite, currentAnimation, 66, 48);
                direction = Direction.Left;
                game.MoveLeft();
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (direction == Direction.Right)
                {
                    currentAnimation = 4;
                    view.StartAnimation(currentSprite, currentAnimation, 61, 77);
                    game.JumpRight();
                }
                if (direction == Direction.Left)
                {
                    currentAnimation = 5;
                    view.StartAnimation(currentSprite, currentAnimation, 61, 77);
                    game.JumpLeft();
                }
                else
                {
                    currentAnimation = 4;
                    view.StartAnimation(currentSprite, currentAnimation, 61, 77);
                    game.Jump();

                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                Menu menu = new Menu(timer1, form, music);
                menu.Show();
                timer1.Stop();
            }
        }

        public void MouseIsDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && direction == Direction.Right)
            {
                currentAnimation = 6;
                view.StartAnimation(currentSprite, currentAnimation, 96, 48);
                game.fight = true;
            }
            if (e.Button == MouseButtons.Left && direction == Direction.Left)
            {
                currentAnimation = 7;
                view.StartAnimation(currentSprite, currentAnimation, 96, 48);
                game.fight = true;
            }
        }

        public void Update(EventArgs e)
        {
            if (currentAnimation == 0)
            {
                view.StartAnimation(currentSprite, currentAnimation, 38, 48);
                if (currentSprite == 3) currentSprite = 0;
                currentSprite++;
            }
            if (currentAnimation == 1)
            {
                view.StartAnimation(currentSprite, currentAnimation, 38, 48);
                if (currentSprite == 0) currentSprite = 3;
                currentSprite--;
            }
            if (currentAnimation == 2)
            {
                view.StartAnimation(currentSprite, currentAnimation, 66, 48);
                if (currentSprite == 11) currentSprite = 0;
                currentSprite++;
            }
            else if (currentAnimation == 3)
            {
                view.StartAnimation(currentSprite, currentAnimation, 66, 48);
                if (currentSprite == 0) currentSprite = 11;
                currentSprite--;
            }
            else if (currentAnimation == 4)
            {
                view.StartAnimation(currentSprite, currentAnimation, 61, 77);
                if (currentSprite == 4) currentSprite = 0;
                currentSprite++;
            }
            else if (currentAnimation == 5)
            {
                view.StartAnimation(currentSprite, currentAnimation, 61, 77);
                if (currentSprite == 0) currentSprite = 4;
                currentSprite--;
            }
            else if (currentAnimation == 6)
            {
                view.StartAnimation(currentSprite, currentAnimation, 96, 48);
                if (currentSprite == 5)
                {
                    currentSprite = 0;
                    currentAnimation = 0;
                }
                currentSprite++;
            }
            else if (currentAnimation == 7)
            {
                view.StartAnimation(currentSprite, currentAnimation, 96, 48);
                if (currentSprite == 0)
                {
                    currentSprite = 5;
                    currentAnimation = 1;
                }
                currentSprite--;
            }


           
            game.Collision(view.playerSprites, currentAnimation);
            game.Update();


        }


    }
}
