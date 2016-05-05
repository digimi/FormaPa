using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MonoPac
{
    /// <summary>
    /// This class represent a case wall on the maze.
    /// </summary>
    public class Wall : SpriteBase
    {
        public Wall(Game1 game, Texture2D texture, Vector2 position) :
            base(game)
        {
            this.Texture = texture;
            this.Position = position;
        }

        public void Update()
        {
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}

