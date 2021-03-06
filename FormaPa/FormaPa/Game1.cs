﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoPac
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Maze maze;
        SpriteFont font;
        Pacman pacman;
        Pinky pinky;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 1152;
            graphics.PreferredBackBufferWidth = 896;
            Content.RootDirectory = "Content";
            pacman = new Pacman(this, "Images/Pacman", new Vector2(448, 848));
            pinky = new Pinky(this, "Images/Blinky", new Vector2(448, 464));
            maze = new Maze(this);
        }

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
            set { spriteBatch = value; }
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Font/pacfont");
           // pacman = new Pacman(this, Content.Load<Texture2D>("Images/Pacman"), new Vector2(448, 848));
            pacman.LoadContent();
            pinky.LoadContent();
            // TODO: use this.Content to load your game content here
            maze.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            maze.Update();
            pacman.Update(maze);
            pinky.Update(maze);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            maze.Draw();
            spriteBatch.DrawString(font, $"SCORE : {pacman.Score}", new Vector2(10, 10), Color.White);
            pacman.Draw();
            pinky.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Maze Maze { get { return this.maze; } }
        
    
        internal Pacman Pacman
        {
            get { return pacman; }
            set { pacman = value; }
        }

    }
}
