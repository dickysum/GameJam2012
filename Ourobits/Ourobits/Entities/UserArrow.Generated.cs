using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Model;

using FlatRedBall.Input;
using FlatRedBall.Utilities;

using FlatRedBall.Instructions;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
// Generated Usings
using Ourobits.Screens;
using Matrix = Microsoft.Xna.Framework.Matrix;
using FlatRedBall.Broadcasting;
using Ourobits.Entities;
using FlatRedBall;
using FlatRedBall.Graphics;
using FlatRedBall.Math;

#if XNA4
using Color = Microsoft.Xna.Framework.Color;
#else
using Color = Microsoft.Xna.Framework.Graphics.Color;
#endif

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
#endif

#if FRB_XNA
using Model = Microsoft.Xna.Framework.Graphics.Model;
#endif

namespace Ourobits.Entities
{
	public partial class UserArrow : PositionedObject, IDestroyable
	{
        // This is made global so that static lazy-loaded content can access it.
        public static string ContentManagerName
        {
            get;
            set;
        }

		// Generated Fields
#if DEBUG
static bool HasBeenLoadedWithGlobalContentManager = false;
#endif
static object mLockObject = new object();
static bool mHasRegisteredUnload = false;
static bool IsStaticContentLoaded = false;
private static Scene CursorFile;

private Sprite Cursor;
protected Layer LayerProvidedByContainer = null;

        public UserArrow(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public UserArrow(string contentManagerName, bool addToManagers) :
			base()
		{
			// Don't delete this:
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);

		}

		protected virtual void InitializeEntity(bool addToManagers)
		{
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			Cursor = CursorFile.Sprites.FindByName("cursor1").Clone();
			
			PostInitialize();
			if (addToManagers)
			{
				AddToManagers(null);
			}


		}

// Generated AddToManagers
		public virtual void AddToManagers (Layer layerToAddTo)
		{
			LayerProvidedByContainer = layerToAddTo;
			SpriteManager.AddPositionedObject(this);
			AddToManagersBottomUp(layerToAddTo);
			CustomInitialize();
		}

		public virtual void Activity()
		{
			// Generated Activity
			
			CustomActivity();
			
			// After Custom Activity
		}

		public virtual void Destroy()
		{
			// Generated Destroy
			SpriteManager.RemovePositionedObject(this);
			if (Cursor != null)
			{
				SpriteManager.RemoveSprite(Cursor);
			}
			


			CustomDestroy();
		}

		// Generated Methods
public virtual void PostInitialize ()
{
}
public virtual void AddToManagersBottomUp (Layer layerToAddTo)
{
	// We move this back to the origin and unrotate it so that anything attached to it can just use its absolute position
	float oldRotationX = RotationX;
	float oldRotationY = RotationY;
	float oldRotationZ = RotationZ;
	
	float oldX = X;
	float oldY = Y;
	float oldZ = Z;
	
	X = 0;
	Y = 0;
	Z = 0;
	RotationX = 0;
	RotationY = 0;
	RotationZ = 0;
	SpriteManager.AddToLayer(Cursor, layerToAddTo);
	if (Cursor.Parent == null)
	{
		Cursor.AttachTo(this, true);
	}
	X = oldX;
	Y = oldY;
	Z = oldZ;
	RotationX = oldRotationX;
	RotationY = oldRotationY;
	RotationZ = oldRotationZ;
}
public virtual void ConvertToManuallyUpdated ()
{
	this.ForceUpdateDependenciesDeep();
	SpriteManager.ConvertToManuallyUpdated(this);
	SpriteManager.ConvertToManuallyUpdated(Cursor);
}
public static void LoadStaticContent (string contentManagerName)
{
	ContentManagerName = contentManagerName;
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
	if (IsStaticContentLoaded == false)
	{
		IsStaticContentLoaded = true;
		lock (mLockObject)
		{
			if (!mHasRegisteredUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
			{
				FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("UserArrowStaticUnload", UnloadStaticContent);
				mHasRegisteredUnload = true;
			}
		}
		bool registerUnload = false;
		if (!FlatRedBallServices.IsLoaded<Scene>(@"content/cursor/cursorfile.scnx", ContentManagerName))
		{
			registerUnload = true;
		}
		CursorFile = FlatRedBallServices.Load<Scene>(@"content/cursor/cursorfile.scnx", ContentManagerName);
		if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
		{
			lock (mLockObject)
			{
				if (!mHasRegisteredUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
				{
					FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("UserArrowStaticUnload", UnloadStaticContent);
					mHasRegisteredUnload = true;
				}
			}
		}
		CustomLoadStaticContent(contentManagerName);
	}
}
public static void UnloadStaticContent ()
{
	IsStaticContentLoaded = false;
	mHasRegisteredUnload = false;
	if (CursorFile != null)
	{
		CursorFile.RemoveFromManagers(ContentManagerName != "Global");
		CursorFile= null;
	}
}
public static object GetStaticMember (string memberName)
{
	switch(memberName)
	{
		case  "CursorFile":
			return CursorFile;
	}
	return null;
}
object GetMember (string memberName)
{
	switch(memberName)
	{
	}
	return null;
}

    }
	
	
	// Extra classes
	public static class UserArrowExtensionMethods
	{
	}
	
}
