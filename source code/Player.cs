using System.Drawing;

namespace Game_platformer5
{
    public class Player
    {
        public Point Position;
        public int Power { get; set; }
        public int Health { get; set; }
        public int VelocityY { get; set; }
        public int VelocityX { get; set; }

        public Player(Point position, int health, int power)
        {
            Health = health;
            Power = power;
            Position = position;
        }
    }
}
