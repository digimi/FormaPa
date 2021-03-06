﻿using System;
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

        public Pacman(Game1 game, string texture, Vector2 position) : base(game, texture, position)
        {
            Origin = new Vector2(16, 16);
            DestinationRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            Velocity = 2;
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
                nextY = Velocity;
                nextX = 0;
                y = Velocity;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                nextY = -Velocity;
                nextX = 0;
                y = -Velocity;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                nextX = Velocity;
                nextY = Velocity;
                x = Velocity;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                nextX = -Velocity;
                nextY = 0;
                x = -Velocity;
            }
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

            if (x > 0) this.SpriteDirection = SpriteDirection.Right;
            if (x < 0) this.SpriteDirection = SpriteDirection.Left;
            if (y > 0) this.SpriteDirection = SpriteDirection.Down;
            if (y < 0) this.SpriteDirection = SpriteDirection.Up;

            DestinationRectangle = currentRectangle;


            // verifier si le rectangle de destination collisionne une pastille
            Dot eat = Game.Maze.Dots.Where(w => w.InnerRectangle.Intersects(currentRectangle)).FirstOrDefault();
            // TODO : verifier si pacman collisionne un Fantome

            if (eat != null)
            {
                this.Score += eat.Score;
                Game.Maze.Dots.Remove(eat);
            }
            //Console.WriteLine(this);
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}