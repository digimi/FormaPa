using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoPac
{
    public class SpriteBase
    {
        private float rotation = 0.0f;
        private SpriteDirection spriteDirection = SpriteDirection.None;
        private Rectangle? destinationRectangle = null;
        private Rectangle? sourceRectangle = null;
        private Vector2? position = null;
        private Vector2? scale = Vector2.One;
        private Vector2? origin = Vector2.Zero;
        private Color? color = Microsoft.Xna.Framework.Color.White;
        private SpriteEffects effects = SpriteEffects.None;
        private float layerDepth = 0.0f;

        public SpriteBase(Game1 game)
        {
            this.Game = game;
        }

        public SpriteBase(Game1 game, Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Game = game;
            this.Position = position;

            //switch (spriteType)
            //{
            //    case SpriteTypes.Empty:
            //        Texture = game.Content.Load<Texture2D>("Images/Empty");
            //        break;
            //    case SpriteTypes.CrossRoad:
            //        Texture = game.Content.Load<Texture2D>("Images/CrossRoad");
            //        break;
            //    case SpriteTypes.CornerUpLeft:
            //        Texture = game.Content.Load<Texture2D>("Images/CornerUpLeft");
            //        break;
            //    case SpriteTypes.CornerUpRight:
            //        Texture = game.Content.Load<Texture2D>("Images/CornerUpRight");
            //        break;
            //    case SpriteTypes.CornerDownLeft:
            //        Texture = game.Content.Load<Texture2D>("Images/CornerDownLeft");
            //        break;
            //    case SpriteTypes.CornerDownRight:
            //        Texture = game.Content.Load<Texture2D>("Images/CornerDownRight");
            //        break;
            //    case SpriteTypes.Vertical:
            //        Texture = game.Content.Load<Texture2D>("Images/Vertical");
            //        break;
            //    case SpriteTypes.Horizontal:
            //        Texture = game.Content.Load<Texture2D>("Images/Horizontal");
            //        break;
            //    case SpriteTypes.TCrossHorizontalUp:
            //        Texture = game.Content.Load<Texture2D>("Images/TCrossHorizontalUp");
            //        break;
            //    case SpriteTypes.TCrossHorizontalDown:
            //        Texture = game.Content.Load<Texture2D>("Images/TCrossHorizontalDown");
            //        break;
            //    case SpriteTypes.TCrossVerticalUp:
            //        Texture = game.Content.Load<Texture2D>("Images/TCrossVerticalUp");
            //        break;
            //    case SpriteTypes.TCrossVerticalDown:
            //        Texture = game.Content.Load<Texture2D>("Images/TCrossVerticalDown");
            //        break;
            //    case SpriteTypes.Pinky:
            //        Texture = game.Content.Load<Texture2D>("Images/Pinky");
            //        break;
            //    case SpriteTypes.Inky:
            //        Texture = game.Content.Load<Texture2D>("Images/Inky");
            //        break;
            //    case SpriteTypes.Blinky:
            //        Texture = game.Content.Load<Texture2D>("Images/Blinky");
            //        break;
            //    case SpriteTypes.Clyde:
            //        Texture = game.Content.Load<Texture2D>("Images/Clyde");
            //        break;
            //    case SpriteTypes.Pacman:
            //        Texture = game.Content.Load<Texture2D>("Images/PacmanMove");
            //        break;
            //    case SpriteTypes.Dot:
            //        Texture = game.Content.Load<Texture2D>("Images/Dot");
            //        break;
            //    case SpriteTypes.SuperDot:
            //        Texture = game.Content.Load<Texture2D>("Images/SuperDot");
            //        break;
            //    default:
            //        break;
            //}
        }

        public Game1 Game { get; private set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int) Position.X, (int) Position.Y, 32,32);
            }
        }

        public float Rotation
        {
            get
            {
                return this.rotation;
            }
            set
            {
                this.rotation = value;
            }
        }

        public Texture2D Texture
        {
            get;
            set;
        }

        public SpriteDirection SpriteDirection
        {
            get
            {
                return this.spriteDirection;
            }
            set
            {
                float rad = 0.0f;
                switch (value)
                {
                    case SpriteDirection.Up:
                        rad = 0.0f;
                        break;
                    case SpriteDirection.Down:
                        rad = ((float)Math.PI / 180.0f) * 180.0f;
                        break;
                    case SpriteDirection.Left:
                        rad = ((float)Math.PI / 180.0f) * 270.0f;
                        this.rotation = 0.0f;
                        break;
                    case SpriteDirection.Right:
                        rad = ((float)Math.PI / 180.0f) * 90.0f;
                        break;
                    default:
                        rad = 0.0f;
                        break;
                }
                this.rotation = rad;
                this.spriteDirection = value;
            }
        }

        public Rectangle? DestinationRectangle
        {
            get { return destinationRectangle; }
            set { destinationRectangle = value; }
        }

        public Rectangle? SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }

        public Vector2 Position
        {
            get { return position.GetValueOrDefault(); }
            set { position = value; }
        }

        public Vector2? Origin
        {
            get { return this.origin; }
            set { this.origin = value; }
        }

        public Vector2? Scale
        {
            get { return this.scale; }
            set { this.scale = value; }
        }

        public Color? Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public SpriteEffects Effects
        {
            get { return this.effects; }
            set { this.effects = value; }
        }

        public float LayerDepth
        {
            get { return this.layerDepth; }
            set { this.layerDepth = value; }
        }

        public int Score { get; set; }

        public void Draw()
        {
            if (this.position == null && this.destinationRectangle == null)
            {
                // TODO: Log Error => position OR destinationRectangle must be set.
                return;
            }
            if (this.DestinationRectangle == null)
            {
                this.Game.SpriteBatch.Draw(
                    this.Texture,
                    this.Position,
                    this.DestinationRectangle,
                    this.SourceRectangle,
                    this.Origin,
                    this.Rotation,
                    this.Scale,
                    this.Color,
                    this.Effects,
                    this.LayerDepth);
            }
            else
            {
                this.Game.SpriteBatch.Draw(
                    this.Texture,
                    null,
                    this.DestinationRectangle,
                    this.SourceRectangle,
                    this.Origin,
                    this.Rotation,
                    this.Scale,
                    this.Color,
                    this.Effects,
                    this.LayerDepth);
            }
        }

    }
}
