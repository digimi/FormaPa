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
            Origin = new Vector2(16, 16);
        }

        internal void Update(Maze maze)
        {

            Vector2 p = this.Position;


            if (col++ == 3)
            {
                if (row++ == 3) row = 0;
                col = 0;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                int y = this.Rectangle.Y - 1;
                Rectangle r = new Rectangle(this.Rectangle.X, y, 32, 32);
                foreach (var item in maze.Walls)
                {
                    if (item.Rectangle.Intersects(r))
                    {
                        y++;
                        break;
                    }
                }
                this.SpriteDirection = SpriteDirection.Up;
                p.Y=y;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                int y = this.Rectangle.Y + 1;
                Rectangle r = new Rectangle(this.Rectangle.X, y, 32, 32);
                foreach (var item in maze.Walls)
                {
                    if (item.Rectangle.Intersects(r))
                    {
                        y--;
                        break;
                    }
                }
                this.SpriteDirection = SpriteDirection.Up;
                p.Y = y;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                int x = this.Rectangle.X + 1;
                Rectangle r = new Rectangle(x, this.Rectangle.Y, 32, 32);
                foreach (var item in maze.Walls)
                {
                    if (item.Rectangle.Intersects(r))
                    {
                        x--;
                    }
                }
                this.SpriteDirection = SpriteDirection.Right;
                p.X = x;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                int x = this.Rectangle.X - 1;
                Rectangle r = new Rectangle(x, this.Rectangle.Y, 32, 32);
                foreach (var item in maze.Walls)
                {
                    if (item.Rectangle.Intersects(r))
                    {
                        x++;
                    }
                }
                this.SpriteDirection = SpriteDirection.Right;
                p.X = x;
            }


            this.SourceRectangle = new Rectangle(32 * col, 32 * row, 32, 32);
            this.Position = p;
        }

    }
}