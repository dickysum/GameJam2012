using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;


#endif

namespace Ourobits.Entities
{
	public partial class CannonBarrel
	{
	    private bool pushed = false;
	    private int startMousePos = 0;
		private void CustomInitialize()
		{


		}


		private void CustomActivity()
		{

            //Check mouse drag and rotate cannon
            if (InputManager.Mouse.ButtonPushed(Mouse.MouseButtons.LeftButton))
            {
                



                // Now we get the world X and Y of the Cursor (can also use Mouse)
                float worldX = GuiManager.Cursor.WorldXAt(Barrel.Z);
                float worldY = GuiManager.Cursor.WorldYAt(Barrel.Z);
                // Now get the desired rotation for the Sprite
                float desiredRotation = (float)Math.Atan2(
                    Math.Abs(worldY - Barrel.Y), worldX - Barrel.X);

                var offset = (float)Math.PI/2F;

                // finally set the Sprite's rotation
                Barrel.RelativeRotationZ = desiredRotation - offset;

                //// Left mouse button pushed - down this frame, not down last frame

                //var deltaX = InputManager.Mouse.X - startMousePos;

                //float desiredRotation = (float) (Math.PI/2*(deltaX/200F));

                //// finally set the Sprite's rotation
                //Barrel.RelativeRotationZ = desiredRotation;
            }

		    if (InputManager.Mouse.ButtonReleased(Mouse.MouseButtons.LeftButton))
            {
                pushed = false;
            }

		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
