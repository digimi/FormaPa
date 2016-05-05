using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonoPac
{
    /// <summary>
    /// this class is used to draw the maze.
    /// the maze with score, life left and eated fruit is represented in a grid of 28*36 tiles.
    /// </summary>
    public class Maze
    {
        private Texture2D wallCornerTopLeft;
        private Texture2D wallCornerTopRight;
        private Texture2D wallCornerBottomRight;
        private Game1 game;
        private Texture2D wallCornerBottomLeft;
        private Texture2D wallHorizontal;
        private Texture2D spriteEmpty;
        private Texture2D wallVertical;
        private Texture2D dot;
        private Texture2D superDot;

        public Maze(Game1 game)
        {
            this.game = game;
            this.Walls = new List<Wall>();
            this.Dots = new List<Dot>();
            this.SuperDots = new List<SuperDot>();
        }

        public List<Rectangle> HitBoxes
        {
            get
            {
                List<Rectangle> result = new List<Rectangle>();
                if (Walls != null)
                {
                    foreach (var item in Walls)
                    {
                        result.Add(item.Rectangle);
                    }
                }
                return result;
            }
        }

        public void Draw()
        {
            foreach (Wall item in this.Walls)
            {
                item.Draw();
            }
            foreach (Dot item in this.Dots)
            {
                item.Draw();
            }
            foreach (SuperDot item in this.SuperDots)
            {
                item.Draw();
            }
        }

        private void GenerateList()
        {
            int[,] ma = MazeArray();

            for (int i = 0; i < ma.GetLength(0); i++)
            {
                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    switch (ma[i, j])
                    {
                        case 1:
                            Walls.Add(new Wall(game, wallCornerTopLeft, new Vector2(i * 32, j * 32)));
                            break;
                        case 2:
                            Walls.Add(new Wall(game, wallCornerTopRight, new Vector2(i * 32, j * 32)));
                            break;
                        case 3:
                            Walls.Add(new Wall(game, wallCornerBottomLeft, new Vector2(i * 32, j * 32)));
                            break;
                        case 4:
                            Walls.Add(new Wall(game, wallCornerBottomRight, new Vector2(i * 32, j * 32)));
                            break;
                        case 5:
                            Walls.Add(new Wall(game, wallVertical, new Vector2(i * 32, j * 32)));
                            break;
                        case 6:
                            Walls.Add(new Wall(game, wallHorizontal, new Vector2(i * 32, j * 32)));
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        case 14:
                            break;
                        case 15:
                            break;
                        case 16:
                            Dots.Add(new Dot(game, dot, new Vector2(i * 32, j * 32)));
                            break;
                        case 17:
                            //SuperDots.Add(new SuperDot(game, superDot, new Vector2(i * 32, j * 32)));
                            break;
                        default:
                            Walls.Add(new Wall(game, spriteEmpty, new Vector2(i * 32, j * 32)));
                            break;
                    }
                }
            }
        }

        internal void LoadContent()
        {
            wallCornerBottomLeft = game.Content.Load<Texture2D>("Images/BottomLeft");
            wallCornerBottomRight = game.Content.Load<Texture2D>("Images/BottomRight");
            wallCornerTopLeft = game.Content.Load<Texture2D>("Images/TopLeft");
            wallCornerTopRight = game.Content.Load<Texture2D>("Images/TopRight");
            wallHorizontal = game.Content.Load<Texture2D>("Images/Horizontal");
            wallVertical = game.Content.Load<Texture2D>("Images/Vertical");
            spriteEmpty = game.Content.Load<Texture2D>("Images/Empty");
            dot = game.Content.Load<Texture2D>("Images/Dot");
            superDot = game.Content.Load<Texture2D>("Images/SuperDot");
            this.GenerateList();
        }

        private SpriteTypes GetSpriteType(int v)
        {
            SpriteTypes result;

            switch (v)
            {
                case 0:
                    result = SpriteTypes.Empty;
                    break;
                case 1:
                    result = SpriteTypes.CornerUpLeft;
                    break;
                case 2:
                    result = SpriteTypes.CornerUpRight;
                    break;
                case 3:
                    result = SpriteTypes.CornerDownLeft;
                    break;
                case 4:
                    result = SpriteTypes.CornerDownRight;
                    break;
                case 5:
                    result = SpriteTypes.Vertical;
                    break;
                case 6:
                    result = SpriteTypes.Horizontal;
                    break;
                case 7:
                    result = SpriteTypes.CrossRoad;
                    break;
                case 8:
                    result = SpriteTypes.TCrossHorizontalUp;
                    break;
                case 9:
                    result = SpriteTypes.TCrossHorizontalDown;
                    break;
                case 10:
                    result = SpriteTypes.TCrossVerticalUp;
                    break;
                case 11:
                    result = SpriteTypes.TCrossVerticalDown;
                    break;
                case 12:
                    result = SpriteTypes.Blinky;
                    break;
                case 13:
                    result = SpriteTypes.Clyde;
                    break;
                case 14:
                    result = SpriteTypes.Inky;
                    break;
                case 15:
                    result = SpriteTypes.Pinky;
                    break;
                case 16:
                    result = SpriteTypes.Dot;
                    break;
                case 17:
                    result = SpriteTypes.SuperDot;
                    break;
                default:
                    result = SpriteTypes.Empty;
                    break;
            }

            return result;
        }

        internal void Update()
        {
            //throw new NotImplementedException();
        }

        private int[,] MazeArray()
        {
            int a = 1;
            int b = 2;
            int c = 3;
            int d = 4;
            int[,] result = {
                {0,0,0,a,5,5,5,5,5,5,5,5,c,0,0,0,6,0,6,0,0,0,a,5,5,5,5,c,a,5,5,5,5,c,0,0},
                {0,0,0,6,16,16,17,16,16,16,16,16,6,0,0,0,6,0,6,0,0,0,6,16,16,16,17,6,6,16,16,16,16,6,0,0},
                {0,0,0,6,16,a,5,c,16,a,c,16,6,0,0,0,6,0,6,0,0,0,6,16,a,c,16,b,d,16,a,c,16,6,0,0},
                {0,0,0,6,16,6,0,6,16,6,6,16,6,0,0,0,6,0,6,0,0,0,6,16,6,6,16,16,16,16,6,6,16,6,0,0},
                {0,0,0,6,16,6,0,6,16,6,6,16,6,0,0,0,6,0,6,0,0,0,6,16,6,b,5,5,c,16,6,6,16,6,0,0},
                {0,0,0,6,16,b,5,d,16,b,d,16,b,5,5,5,d,0,b,5,5,5,d,16,b,5,5,5,d,16,6,6,16,6,0,0},
                {0,0,0,6,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,6,6,16,6,0,0},
                {0,0,0,6,16,a,5,c,16,a,5,5,5,5,5,5,c,0,a,5,5,5,c,16,a,c,16,a,5,5,d,6,16,6,0,0},
                {0,0,0,6,16,6,0,6,16,b,5,5,c,a,5,5,d,0,b,5,5,5,d,16,6,6,16,b,5,5,c,6,16,6,0,0},
                {0,0,0,6,16,6,0,6,16,16,16,16,6,6,0,0,0,0,0,0,0,0,0,16,6,6,16,16,16,16,6,6,16,6,0,0},
                {0,0,0,6,16,6,0,6,16,a,c,16,6,6,0,a,5,5,5,c,0,a,c,16,6,6,16,a,c,16,6,6,16,6,0,0},
                {0,0,0,6,16,b,5,d,16,6,6,16,b,d,0,6,0,0,0,6,0,6,6,16,b,d,16,6,6,16,b,d,16,6,0,0},
                {0,0,0,6,16,16,16,16,16,6,6,16,0,0,0,6,0,0,0,6,0,6,6,16,16,16,16,6,6,16,16,16,16,6,0,0},
                {0,0,0,b,5,5,5,c,16,6,b,5,5,c,0,0,0,0,0,6,0,6,b,5,5,c,16,6,b,5,5,c,16,6,0,0},
                {0,0,0,a,5,5,5,d,16,6,a,5,5,d,0,0,0,0,0,6,0,6,a,5,5,d,16,6,a,5,5,d,16,6,0,0},
                {0,0,0,6,16,16,16,16,16,6,6,16,0,0,0,6,0,0,0,6,0,6,6,16,16,16,16,6,6,16,16,16,16,6,0,0},
                {0,0,0,6,16,a,5,c,16,6,6,16,a,c,0,6,0,0,0,6,0,6,6,16,a,c,16,6,6,16,a,c,16,6,0,0},
                {0,0,0,6,16,6,0,6,16,b,d,16,6,6,0,b,5,5,5,d,0,b,d,16,6,6,16,b,d,16,6,6,16,6,0,0},
                {0,0,0,6,16,6,0,6,16,16,16,16,6,6,0,0,0,0,0,0,0,0,0,16,6,6,16,16,16,16,6,6,16,6,0,0},
                {0,0,0,6,16,6,0,6,16,a,5,5,d,b,5,5,c,0,a,5,5,5,c,16,6,6,16,a,5,5,d,6,16,6,0,0},
                {0,0,0,6,16,b,5,d,16,b,5,5,5,5,5,5,d,0,b,5,5,5,d,16,b,d,16,b,5,5,c,6,16,6,0,0},
                {0,0,0,6,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,6,6,16,6,0,0},
                {0,0,0,6,16,a,5,c,16,a,c,16,a,5,5,5,c,0,a,5,5,5,c,16,a,5,5,5,c,16,6,6,16,6,0,0},
                {0,0,0,6,16,6,0,6,16,6,6,16,6,0,0,0,6,0,6,0,0,0,6,16,6,a,5,5,d,16,6,6,16,6,0,0},
                {0,0,0,6,16,6,0,6,16,6,6,16,6,0,0,0,6,0,6,0,0,0,6,16,6,6,16,16,16,16,6,6,16,6,0,0},
                {0,0,0,6,16,b,5,d,16,b,d,16,6,0,0,0,6,0,6,0,0,0,6,16,b,d,16,a,c,16,b,d,16,6,0,0},
                {0,0,0,6,16,16,17,16,16,16,16,16,6,0,0,0,6,0,6,0,0,0,6,16,16,16,17,6,6,16,16,16,16,6,0,0},
                {0,0,0,b,5,5,5,5,5,5,5,5,d,0,0,0,6,0,6,0,0,0,b,5,5,5,5,d,b,5,5,5,5,d,0,0},  };



            return result;
        }

        public List<Wall> Walls { get; set; }
        public List<Dot> Dots { get; set; }
        public List<SuperDot> SuperDots { get; set; }
    }
}

