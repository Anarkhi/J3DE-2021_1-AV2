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

namespace MCRAFT_DMSQ
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        _Screen screen;
        _Camera camera;
        public Matrix world;

        Solo s;
        
        Personagem P;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            
            world = Matrix.Identity;
            this.screen = _Screen.GetInstance();
            this.screen.SetWidth(graphics.PreferredBackBufferWidth);
            this.screen.SetHeight(graphics.PreferredBackBufferHeight);

            this.camera = new _Camera();
            this.s = new Solo(GraphicsDevice);
            this.P = new Personagem();
            P.Initialize(GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.world *= Matrix.CreateTranslation(0.01f, 0, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.world *= Matrix.CreateTranslation(-0.01f, 0, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.world *= Matrix.CreateTranslation(0, -0.01f, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.world *= Matrix.CreateTranslation(0, 0.01f, 0);
            }

            //P.Update();

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            s.Draw(camera, Vector3.Zero, 0, Vector3.Zero, 0);
            P.Draw(camera);
            base.Draw(gameTime);
        }
    }
}
