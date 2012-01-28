using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Graphics.Model;
using FlatRedBall.Math;
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
        private const bool GENERATE_NEW_TRASH_ON_CLICK = false;

	    private const int TRASH_GEN_COUNT_DOWN = 3;

	    private double countDown = TRASH_GEN_COUNT_DOWN;

		void CustomInitialize()
		{
            
		}

		void CustomActivity(bool firstTimeCalled)
		{
		    countDown -= TimeManager.SecondDifference;

            //Create trash on conveyor 
            if (countDown < 0)
            {
                //Create trash right at the edge of the planet
                var newTrash = GenerateTrash(-230, -300);
                newTrash.AttachTo(ConveyorInstance, true);
                newTrash.OnConveyor = true;

                ////Add to the game screen
                newTrash.AddToManagers(this.Layer);
                countDown = TRASH_GEN_COUNT_DOWN;
            }


		    if (InputManager.Mouse.ButtonPushed(Mouse.MouseButtons.LeftButton))
            {

                // Left mouse button pushed - down this frame, not down last frame
            }


            //Create new trash on release click

            Trash trashToRelease;
            if (InputManager.Mouse.ButtonReleased(Mouse.MouseButtons.LeftButton))
            {

                if (GENERATE_NEW_TRASH_ON_CLICK)
                // Left mouse button relase - down this frame, not down last frame
                {
                    trashToRelease = GenerateTrash(CannonBarrelInstance.X, CannonBarrelInstance.Y);
                    ////Add to the game screen
                    trashToRelease.AddToManagers(this.Layer);
                }
                else
                {
                    trashToRelease = GetTrashFromConveyor(TrashList);
                    
                }


                float worldX = GuiManager.Cursor.WorldXAt(CannonBarrelInstance.Position.Z);
                float worldY = GuiManager.Cursor.WorldYAt(CannonBarrelInstance.Position.Z);

                //Normalize the Y
                //worldY = -newTrash.Y;

                //Lunch the trash
                if (trashToRelease != null)
                {
                    trashToRelease.Detach();
                    trashToRelease.OnConveyor = false;
                    trashToRelease.X = CannonBarrelInstance.X;
                    trashToRelease.Y = CannonBarrelInstance.Y;

                    trashToRelease.Velocity.Y = Math.Abs(worldY - trashToRelease.Y);
                    trashToRelease.Velocity.X = worldX;


                }
                //newTrash.AttachTo(MoonInstance, true);
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

		    CheckTrashCollision(Orbit1Instance, TrashList, 10);

		 
		}

        /// <summary>
        /// Find Trash from Conveyor
        /// </summary>
        /// <param name="trashList"></param>
        /// <returns></returns>
	    private Trash GetTrashFromConveyor(PositionedObjectList<Trash> trashList)
        {
            var trash = (from t in trashList
                         where t.OnConveyor && t.X > -50 && t.X < 50
                         select t).FirstOrDefault();
            return trash;
        }

	    private void CheckTrashCollision(Orbit1 orbit1Instance, FlatRedBall.Math.PositionedObjectList<Trash> trashList, int p)
        {
            var trashLockoutFromSpace = new List<Trash>();

            foreach (var trash in trashList.Where(t => !t.Attached))
            {
                //Check if trash hit other trash
                foreach (var otherTrash in trashList)
                {
                    //Ignore trashes on the planet
                    if (otherTrash == trash || otherTrash.OnConveyor)
                    {
                        continue;
                    }

                    if (trash.CollisionCircle.CollideAgainstBounce(otherTrash.CollisionCircle, 10F, 0.1F, 0))
                    {
                        //trash.AttachTo(null, false);
                        //otherTrash.AttachTo(null, false);
                        trash.Detach();
                        otherTrash.Detach();

                        //trash fly to space
                        return;
                    }
                }

                //Only allow attach once
                if (!trash.Attached && trash.CollisionCircle.CollideAgainstBounce(Orbit1Instance.Circle, 0, 100, 2))
                {
                    trash.AttachTo(Orbit1Instance, true);
                    trash.Attached = true;
                }


                int halfScreenWidth = FlatRedBallServices.ClientWidth/2;
                int halfScreenHeight = FlatRedBallServices.ClientHeight/2;
                if (!trash.OnConveyor && (trash.X > halfScreenWidth ||
                    trash.X < -halfScreenWidth ||
                    trash.Y > halfScreenHeight ||
                    trash.Y < -halfScreenHeight))
                {
                    trashLockoutFromSpace.Add(trash);
                }
            }

            //Remove the trash from game
            foreach (var trash in trashLockoutFromSpace)
            {
                trashList.Remove(trash);
                trash.RemoveSelfFromListsBelongingTo();
                trash.Destroy();
            }

        }

	    private Trash GenerateTrash(float x, float y)
	    {
	        var num = TrashList.Count + 1;
	        var newTrash = new Ourobits.Entities.Trash(ContentManagerName, false);
	        newTrash.Name = "Trash" + num;

	        ////newTrash.X = 100;
	        ////newTrash.Y = -100;
	        this.TrashList.Add(newTrash);

	        Vector3 cannonPointinVector = CannonBarrelInstance.RotationMatrix.Down;

	        newTrash.X = x;
	        newTrash.Y = y;
	        return newTrash;
	    }

	    void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

	}
}
