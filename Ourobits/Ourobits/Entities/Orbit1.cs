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
	public partial class Orbit1
	{
        //backup the original position so the orbit doesn't get knok off
	    private float originalX;
        private float origianlY;

		private void CustomInitialize()
		{
		    originalX = this.X;
            origianlY = this.Y;

		}

		private void CustomActivity()
		{
            //Fix the orbrite location
            if (this.Velocity.X != 0 || this.Velocity.Y !=0)
            {
                this.Velocity.X = 0;
                this.Velocity.Y = 0;
                this.X = originalX;
                this.Y = origianlY;
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
