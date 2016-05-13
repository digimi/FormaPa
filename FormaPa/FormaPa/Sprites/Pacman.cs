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
        static int nextX = 0;
        static int nextY = 0;

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
            Rectangle currentRectangle = DestinationRectangle.GetValueOrDefault();

            if (col++ == 3)
            {
                if (row++ == 3) row = 0;
                col = 0;
            }

            // mettre en place la direction suivante
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                nextY = 1;
                nextX = 0;
                y = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                nextY = -1;
                nextX = 0;
                y = -1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                nextX = 1;
                nextY = 0;
                x = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                nextX = -1;
                nextY = 0;
                x = -1;
            }
            // mettre en place la direction courante


            // Construire rectangle de destination
            // Verifier si intersect Wall avec direction courante
            currentRectangle.X += x;
            canHorizontalMove = Game.Maze.Walls.Where(w => w.Rectangle.Intersects(currentRectangle)).Count() == 0;
            // si mouvement impossible changer de direction
            if (!canHorizontalMove)
            {
                currentRectangle.X -= x;
                x = 0;
            }

            currentRectangle.Y += y;
            canVerticalMove = Game.Maze.Walls.Where(w => w.Rectangle.Intersects(currentRectangle)).Count() == 0;
            if (!canVerticalMove)
            {
                currentRectangle.Y -= y;
                y = 0;
            }

            this.SourceRectangle = new Rectangle(32 * col, 32 * row, 32, 32);
            if (this.DestinationX != currentRectangle.X)
                this.SpriteDirection = (this.DestinationX > this.Position.X) ? SpriteDirection.Left : SpriteDirection.Right;
            if (this.DestinationY != currentRectangle.Y)
                this.SpriteDirection = (this.DestinationY > this.Position.Y) ? SpriteDirection.Up : SpriteDirection.Down;

            DestinationRectangle = currentRectangle;

        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}