using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MonoPac
{
    internal class Pacman : SpriteBase
    {
        static int row;
        static int col;

        public Pacman(Game1 game) : base(game)
        {
            Origin = new Vector2(16, 16);
        }


        public Pacman(Game1 game, Texture2D texture, Vector2 position) : base(game, texture, position)
        {
            
        }

        internal void Update()
        {

            Vector2 p = (Vector2)this.Position;
            int r = 0;

            if (col++ == 3)
            {
                if (row++ == 3) row = 0;
                col = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                r = row;
                p.Y--;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                r = row + 4;
                p.Y++;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                r = row + 12;
                p.X++;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                r = row + 8;
                p.X--;
            }


            this.SourceRectangle = new Rectangle(32 * col, 32 * r, 32, 32);
            this.Position = p;
        }

    }
}