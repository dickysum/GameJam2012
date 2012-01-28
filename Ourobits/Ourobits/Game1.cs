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
using FlatRedBall;
using FlatRedBall.Graphics;
using FlatRedBall.Utilities;

using Ourobits.Screens;

namespace Ourobits
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";
			
			BackStack<string> bs = new BackStack<string>();
			bs.Current = string.Empty;
        }

        protected override void Initialize()
        {
            Renderer.UseRenderTargets = false;
            FlatRedBallServices.InitializeFlatRedBall(this, graphics);

            //Ensure our game camera look at the game in 2D
            SpriteManager.Camera.Orthogonal = true;
            SpriteManager.Camera.OrthogonalWidth = FlatRedBallServices.ClientWidth;
            SpriteManager.Camera.OrthogonalHeight = FlatRedBallServices.ClientHeight;

			Screens.ScreenManager.Start(typeof(Ourobits.Screens.GameScreen).FullName);


            //Setup control
            if (FlatRedBall.Input.InputManager.Xbox360GamePads[0].IsConnected == false)
            {
                FlatRedBall.Input.InputManager.Xbox360GamePads[0].CreateDefaultButtonMap();
            }

            //Set moon gravity
            

            base.Initialize();
        }


        protected override void Update(GameTime gameTime)
        {
            FlatRedBallServices.Update(gameTime);

            ScreenManager.Activity();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            FlatRedBallServices.Draw();

            base.Draw(gameTime);
        }
    }
}
