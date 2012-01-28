using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math.Geometry;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Input;
using FlatRedBall.IO;
using FlatRedBall.Instructions;
using FlatRedBall.Math.Splines;
using FlatRedBall.Utilities;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if XNA4
using Color = Microsoft.Xna.Framework.Color;
#else
using Color = Microsoft.Xna.Framework.Graphics.Color;
#endif

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Microsoft.Xna.Framework.Media;
#endif

// Generated Usings
using FlatRedBall.Broadcasting;
using Ourobits.Entities;
using FlatRedBall;
using FlatRedBall.Math;

namespace Ourobits.Screens
{
	public partial class GameScreen : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		private Scene BackgroundFile;
		
		private Ourobits.Entities.Moon MoonInstance;
		private PositionedObjectList<Trash> TrashList;
		private Ourobits.Entities.Trash TrashDummy;
		private Ourobits.Entities.CannonBarrel CannonBarrelInstance;

		public GameScreen()
			: base("GameScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			BackgroundFile = FlatRedBallServices.Load<Scene>("content/screens/gamescreen/backgroundfile.scnx", ContentManagerName);
			MoonInstance = new Ourobits.Entities.Moon(ContentManagerName, false);
			MoonInstance.Name = "MoonInstance";
			TrashList = new PositionedObjectList<Trash>();
			TrashDummy = new Ourobits.Entities.Trash(ContentManagerName, false);
			TrashDummy.Name = "TrashDummy";
			CannonBarrelInstance = new Ourobits.Entities.CannonBarrel(ContentManagerName, false);
			CannonBarrelInstance.Name = "CannonBarrelInstance";
			TrashList.Add(TrashDummy);
			
			
			PostInitialize();
			base.Initialize(addToManagers);
			if (addToManagers)
			{
				AddToManagers();
			}

        }
        
// Generated AddToManagers
		public override void AddToManagers ()
		{
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				MoonInstance.Activity();
				for (int i = TrashList.Count - 1; i > -1; i--)
				{
					if (i < TrashList.Count)
					{
						// We do the extra if-check because activity could destroy any number of entities
						TrashList[i].Activity();
					}
				}
				CannonBarrelInstance.Activity();
			}
			else
			{
			}
			base.Activity(firstTimeCalled);
			if (!IsActivityFinished)
			{
				CustomActivity(firstTimeCalled);
			}
			BackgroundFile.ManageAll();


				// After Custom Activity
				
            
		}

		public override void Destroy()
		{
			// Generated Destroy
			if (MoonInstance != null)
			{
				MoonInstance.Destroy();
			}
			for (int i = TrashList.Count - 1; i > -1; i--)
			{
				TrashList[i].Destroy();
			}
			if (CannonBarrelInstance != null)
			{
				CannonBarrelInstance.Destroy();
			}
			BackgroundFile.RemoveFromManagers(ContentManagerName != "Global");
			

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
public virtual void PostInitialize ()
{
}
public virtual void AddToManagersBottomUp ()
{
	BackgroundFile.AddToManagers(mLayer);
	MoonInstance.AddToManagers(mLayer);
	TrashDummy.AddToManagers(mLayer);
	CannonBarrelInstance.AddToManagers(mLayer);
}
public virtual void ConvertToManuallyUpdated ()
{
	BackgroundFile.ConvertToManuallyUpdated();
	MoonInstance.ConvertToManuallyUpdated();
	for (int i = 0; i < TrashList.Count; i++)
	{
		TrashList[i].ConvertToManuallyUpdated();
	}
	CannonBarrelInstance.ConvertToManuallyUpdated();
}
public static void LoadStaticContent (string contentManagerName)
{
	#if DEBUG
	if (contentManagerName == FlatRedBallServices.GlobalContentManager)
	{
		HasBeenLoadedWithGlobalContentManager = true;
	}
	else if (HasBeenLoadedWithGlobalContentManager)
	{
		throw new Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
	}
	#endif
	Ourobits.Entities.Moon.LoadStaticContent(contentManagerName);
	Ourobits.Entities.CannonBarrel.LoadStaticContent(contentManagerName);
	CustomLoadStaticContent(contentManagerName);
}
object GetMember (string memberName)
{
	switch(memberName)
	{
	}
	return null;
}


	}
}
