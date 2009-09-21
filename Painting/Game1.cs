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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Painting
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        private StrokeManager strokes;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            ContentLibrary.Add("background70", Content.Load<Texture2D>("background70"));
            ContentLibrary.Add("exitButton", Content.Load<Texture2D>("exitButton"));
            ContentLibrary.Add("yesButton", Content.Load<Texture2D>("yesButton"));
            ContentLibrary.Add("noButton", Content.Load<Texture2D>("noButton"));
            ContentLibrary.Add("minusButton", Content.Load<Texture2D>("minusButton"));
            ContentLibrary.Add("plusButton", Content.Load<Texture2D>("plusButton"));
            ContentLibrary.Add("circle", Content.Load<Texture2D>("circle"));
            ContentLibrary.Add("pointer", Content.Load<Texture2D>("pointer"));
            ContentLibrary.Add("brush", ContentLibrary.Get("circle"));
            strokes = new StrokeManager();

            MainMenu mainMenu = new MainMenu();
            ExitMenu exitMenu = new ExitMenu();
            MenuManager.Register(mainMenu);
            MenuManager.Register(exitMenu);

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
            
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            Input.Update();
            strokes.Update();
            MenuManager.Update();
            CursorManager.Update();
            
            // Allows the game to exit
            if (Input.Exit() || Mailbox.CheckMailbox(Mailbox.Name.ExitProgram))
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            strokes.Draw();
            MenuManager.Draw();
            CursorManager.Draw();
            DrawingLayer.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
