using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace MonoPac
{
    internal class Pacman : SpriteBase
    {
        static int row;
        static int col;
        static int x = 0;
        static int y = 0;

        public Pacman(Game1 game) : base(game)
        {
            Origin = new Vector2(16, 16);
        }


        public Pacman(Game1 game, Texture2D texture, Vector2 position) : base(game, texture, position)
        {
            Origin = new Vector2(16, 16);
            DestinationRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);
        }

        internal void Update(Maze maze)
        {
            //Vector2 p = this.Position;
            bool canHorizontalMove = true;
            bool canVerticalMove = true;

            if (col++ == 3)
            {
                if (row++ == 3) row = 0;
                col = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                y = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                y = -1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                x = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                x = -1;
            }

            // Construire rectangle de destination
            // Verifier si intersect rectangle
            this.DestinationX += x;
            canHorizontalMove = this.DestinationRectangle != null ? Game.Maze.Walls.Where(w => w.Rectangle.Intersects((Rectangle)this.DestinationRectangle)).Count() == 0 : false;
            if (!canHorizontalMove)
            {
                this.DestinationX = +-x;
            }
            this.DestinationY += y;
            canVerticalMove = this.DestinationRectangle != null ? Game.Maze.Walls.Where(w => w.Rectangle.Intersects((Rectangle)this.DestinationRectangle)).Count() == 0 : false;
            if (!canVerticalMove) this.DestinationY += -y;

            // Si not ok empecher mouvement.
            if (!canHorizontalMove)
            {
                DestinationRectangle = new Rectangle(this.DestinationX--, this.DestinationY--, 32, 32);
            }
            this.SourceRectangle = new Rectangle(32 * col, 32 * row, 32, 32);
            //this.Position = p;
        }

        public SpriteDirection Direction { get; set; }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}