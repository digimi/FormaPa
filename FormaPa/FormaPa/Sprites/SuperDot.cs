using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoPac
{
    public class SuperDot : Dot
    {

        public SuperDot(Game1 game, Texture2D texture, Vector2 position) : base(game, texture, position)
        {
            this.Texture = texture;
            this.Score = 50;
            this.Scale *= 0.5f;
        }
    }
}
