using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Flextensions;

namespace ToyWars
{
    public class GameRoot : Microsoft.Xna.Framework.Game
    {
        // Game Variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Background ground;

        // CONSTANTS
        public const int WIDTH = 1290, HEIGHT = 720;

        // Constructor
        public GameRoot()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Set View to be the specified Width and Height.
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            IsMouseVisible = true;
        }


        // Init
        protected override void Initialize()
        {
            base.Initialize();
        }

        // Load
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load Images
            Art.Load(Content);
            // Set up variables.
            ResetGame();
        }

        // Reset
        public void ResetGame()
        {
            // Reset Variables, or Set if first run.
            ground = new Background(Art.Background);
        }

        // Update
        protected override void Update(GameTime gameTime)
        {
            // Runs gamepad and keyboard input detection.
            Input.Update();
            // The above code allows the use of Input so instead of this:
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            // we can do,
            if (Input.IsButtonDown(Buttons.Back))
                this.Exit();
            // This also does the same, quits, under different Inputs.
            if (Input.WasButtonPressed(Buttons.Back) || Input.WasKeyPressed(Keys.Escape))
                this.Exit();

            base.Update(gameTime);
        }

        // Draw
        protected override void Draw(GameTime gameTime)
        {
            // Draw the "sky".
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();

            // Draw the background.
            ground.Draw(spriteBatch);

#if DEBUG
            // Draw debug text. Shadow on offset, then white text on top for visibility.
            for (int i = 0; i < 2; i++)
            {
                spriteBatch.DrawString(Art.DebugFont,
                    "DEBUG" +
                    "\nFPS: " + (1 / (float)gameTime.ElapsedGameTime.TotalSeconds).ToString("N0") +
                    "\n",
                    i < 1 ? Vector2.One : Vector2.Zero,    // if (i<1) {Vec.One} else {Vec.Zero}
                    i < 1 ? Color.Black : Color.White );   // if (i<1) {C.Black} else {C.White}
            }
#endif

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
