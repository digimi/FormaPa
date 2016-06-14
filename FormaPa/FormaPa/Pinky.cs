using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace MonoPac
{
    internal class Pinky : SpriteBase
    {
        private int col;
        private int nextX;
        private int nextY;
        private int row;
        private int x = 1;
        private int y = 0;
        Random randomDirection = new Random();

        public Pinky(Game1 game, string textureName, Vector2 position) : base(game, textureName, position)
        {
            this.Origin = new Vector2(16, 16);
            Velocity = 2;
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
            var distanceY = Game.Pacman.Position.Y - this.Position.Y;
            var distanceX = Game.Pacman.Position.X - this.Position.X;
            var directionY = distanceY / System.Math.Abs(distanceY);
            var directionX = distanceX / System.Math.Abs(distanceX);

            nextX = Velocity * (int)directionX;
            nextY = Velocity * (int)directionY;
            x = nextX;
            y = nextY;


            //if (distanceX > distanceY)
            //{
            //    nextY = Velocity;
            //    nextX = 0;
            //    y = Velocity;
            //}
            //else
            //{
            //    nextX = Velocity;
            //    nextY = 0;
            //    x = Velocity;
            //}
            //if (Game.Pacman.Position.Y < this.Position.Y)
            //{
            //    nextY = Velocity;
            //    nextX = 0;
            //    y = Velocity;
            //}
            //if (Game.Pacman.Position.Y > this.Position.Y)
            //{
            //    nextY = -Velocity;
            //    nextX = 0;
            //    y = -Velocity;
            //}
            //if (Game.Pacman.Position.X > this.Position.X)
            //{
            //    nextX = Velocity;
            //    nextY = 0;
            //    x = Velocity;
            //}
            //if (Game.Pacman.Position.X < this.Position.X)
            //{
            //    nextX = -Velocity;
            //    nextY = 0;
            //    x = -Velocity;
            //}
            /* mettre en place la direction courante
             Construire rectangle de destination
             Verifier si intersect Wall avec direction courante */
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

            //if (x > 0) this.SpriteDirection = SpriteDirection.Right;
            //if (x < 0) this.SpriteDirection = SpriteDirection.Left;
            //if (y > 0) this.SpriteDirection = SpriteDirection.Down;
            //if (y < 0) this.SpriteDirection = SpriteDirection.Up;

            DestinationRectangle = currentRectangle;

        }

    }
}