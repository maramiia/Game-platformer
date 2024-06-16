using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_platformer5
{
    public class Block
    {
        public Rectangle Rectangle { get; set; }
        public string Tag { get; set; }
        public Block(Rectangle rectangle, string tag)
        {
            Rectangle = rectangle;
            Tag = tag;
        }
    }
}
