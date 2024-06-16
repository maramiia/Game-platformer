using System.Drawing;

namespace Game_platformer5
{
    public class Enemy
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public string Type { get; set; }
        public Enemy(int width, int height, int health, int power)
        {
            Width = width;
            Height = height;
            Health = health;
            Power = power;
        }
    }
}
