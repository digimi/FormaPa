using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoPac
{
    public class Dot : SpriteBase
    {
        public Dot(Game1 game,Texture2D texture , Vector2 position) : base(game)
        {
            this.Texture = texture;
            this.Position = position;
            this.Score = 10;
        }
    }
}
