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
        private int destinationY;
        private int destinationX;

        public SpriteBase(Game1 game)
        {
            this.Game = game;
        }

        public SpriteBase(Game1 game, Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Game = game;
            this.Position = position;
        }

        public Game1 Game { get; private set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
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
                        rad = ((float)Math.PI / 180.0f) * 270.0f;
                        //rad = 0.0f;
                        break;
                    case SpriteDirection.Down:
                        rad = ((float)Math.PI / 180.0f) * 90.0f;
                        break;
                    case SpriteDirection.Left:
                        rad = ((float)Math.PI / 180.0f) * 180.0f;
                        this.rotation = 0.0f;
                        break;
                    case SpriteDirection.Right:
                        rad = 0.0f;
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
            get
            {
                return destinationRectangle;
            }
            set {
                this.destinationX = value.Value.X;
                this.destinationY = value.Value.Y;
                this.position = new Vector2(value.Value.X, value.Value.Y);
                destinationRectangle = value;
            }
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

        public List<TiledPosition> TiledPositions { get; set; }

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
                this.Position = new Vector2(this.destinationX, this.destinationY);
            }
        }

        public int DestinationX
        {
            get
            {
                return this.destinationX;
            }
            set
            {
                destinationX = value;
                destinationRectangle = new Rectangle(destinationX, destinationY, 32, 32);
            }
        }
        public int DestinationY
        {
            get { return this.destinationY; }
            set
            {
                destinationY = value;
                destinationRectangle = new Rectangle(destinationX, destinationY, 32, 32);
            }
        }

        public int Velocity { get; set; }


        public override string ToString()
        {
            return $"Position {GetType().Name} => X = {this.Position.X} : Y = {this.Position.Y} -- Top:{this.Rectangle.Top}, Left:{this.Rectangle.Left}, Bottom:{this.Rectangle.Bottom}, Right:{this.Rectangle.Right} -- Size = Height:{this.Rectangle.Height}, Width:{this.Rectangle.Width}";
        }

    }
}
