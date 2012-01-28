using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Graphics.Model;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using Microsoft.Xna.Framework;
using Ourobits.Entities;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using FlatRedBall.Localization;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
#endif

namespace Ourobits.Screens
{
	public partial class GameScreen
	{

		void CustomInitialize()
		{
            
		}

		void CustomActivity(bool firstTimeCalled)
		{
            if (InputManager.Mouse.ButtonPushed(Mouse.MouseButtons.LeftButton))
            {
                // Left mouse button pushed - down this frame, not down last frame
            }

            //Create new trash on release click
            if (InputManager.Mouse.ButtonReleased(Mouse.MouseButtons.LeftButton))
            {
                // Left mouse button relase - down this frame, not down last frame
                var num = TrashList.Count + 1;
                var newTrash = new Ourobits.Entities.Trash(ContentManagerName, false);
                newTrash.Name = "Trash" + num;

                newTrash.X = 100;
                newTrash.Y = -100;
                this.TrashList.Add(newTrash);

                //Add to the game screen
                newTrash.AddToManagers(this.Layer);

                newTrash.Velocity = new Vector3(10,10,0);
              
            }


            if (InputManager.Mouse.ButtonReleased(Mouse.MouseButtons.MiddleButton))
            {
                // Middle mouse button released - not down this frame, down last frame.
                // This is the same as a click.
            }
            if (InputManager.Mouse.ButtonDown(Mouse.MouseButtons.RightButton))
            {
                // Right mouse button down this frame;
            }
            if (InputManager.Mouse.ButtonDoubleClicked(Mouse.MouseButtons.LeftButton))
            {
                // Left button double-clicked.
            }

		}

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

	}
}
