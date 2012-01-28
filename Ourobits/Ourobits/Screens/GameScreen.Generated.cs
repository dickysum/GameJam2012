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
		private Ourobits.Entities.CannonBarrel CannonBarrelInstance;
		private Ourobits.Entities.CannonBase CannonBaseInstance;
		private PositionedObjectList<Trash2> TrashList2;
		private Ourobits.Entities.UserArrow UserArrowInstance;
		private Ourobits.Entities.Conveyor ConveyorInstance;
		private Ourobits.Entities.Orbit1 Orbit1Instance;

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
			CannonBarrelInstance = new Ourobits.Entities.CannonBarrel(ContentManagerName, false);
			CannonBarrelInstance.Name = "CannonBarrelInstance";
			CannonBaseInstance = new Ourobits.Entities.CannonBase(ContentManagerName, false);
			CannonBaseInstance.Name = "CannonBaseInstance";
			TrashList2 = new PositionedObjectList<Trash2>();
			UserArrowInstance = new Ourobits.Entities.UserArrow(ContentManagerName, false);
			UserArrowInstance.Name = "UserArrowInstance";
			ConveyorInstance = new Ourobits.Entities.Conveyor(ContentManagerName, false);
			ConveyorInstance.Name = "ConveyorInstance";
			Orbit1Instance = new Ourobits.Entities.Orbit1(ContentManagerName, false);
			Orbit1Instance.Name = "Orbit1Instance";
			
			
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
				CannonBaseInstance.Activity();
				for (int i = TrashList2.Count - 1; i > -1; i--)
				{
					if (i < TrashList2.Count)
					{
						// We do the extra if-check because activity could destroy any number of entities
						TrashList2[i].Activity();
					}
				}
				UserArrowInstance.Activity();
				ConveyorInstance.Activity();
				Orbit1Instance.Activity();
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
			if (CannonBaseInstance != null)
			{
				CannonBaseInstance.Destroy();
			}
			for (int i = TrashList2.Count - 1; i > -1; i--)
			{
				TrashList2[i].Destroy();
			}
			if (UserArrowInstance != null)
			{
				UserArrowInstance.Destroy();
			}
			if (ConveyorInstance != null)
			{
				ConveyorInstance.Destroy();
			}
			if (Orbit1Instance != null)
			{
				Orbit1Instance.Destroy();
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
	CannonBarrelInstance.AddToManagers(mLayer);
	CannonBaseInstance.AddToManagers(mLayer);
	UserArrowInstance.AddToManagers(mLayer);
	ConveyorInstance.AddToManagers(mLayer);
	Orbit1Instance.AddToManagers(mLayer);
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
	CannonBaseInstance.ConvertToManuallyUpdated();
	for (int i = 0; i < TrashList2.Count; i++)
	{
		TrashList2[i].ConvertToManuallyUpdated();
	}
	UserArrowInstance.ConvertToManuallyUpdated();
	ConveyorInstance.ConvertToManuallyUpdated();
	Orbit1Instance.ConvertToManuallyUpdated();
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
	Ourobits.Entities.CannonBase.LoadStaticContent(contentManagerName);
	Ourobits.Entities.UserArrow.LoadStaticContent(contentManagerName);
	Ourobits.Entities.Conveyor.LoadStaticContent(contentManagerName);
	Ourobits.Entities.Orbit1.LoadStaticContent(contentManagerName);
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
