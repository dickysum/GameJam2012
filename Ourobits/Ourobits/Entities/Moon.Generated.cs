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
using FlatRedBall.Math.Geometry;

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
	public partial class Moon : PositionedObject, IDestroyable
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
private static ShapeCollection MoonShapeCollectionFile;
private static Scene MoonFile;

private Scene mRealBody;
public Scene RealBody
{
	get
	{
		return mRealBody;
	}
}
private Sprite mMoonSprite;
public Sprite MoonSprite
{
	get
	{
		return mMoonSprite;
	}
}
protected Layer LayerProvidedByContainer = null;

        public Moon(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public Moon(string contentManagerName, bool addToManagers) :
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
			mRealBody = MoonFile.Clone();
			for (int i = 0; i < mRealBody.Texts.Count; i++)
			{
				mRealBody.Texts[i].AdjustPositionForPixelPerfectDrawing = true;
			}
			mMoonSprite = mRealBody.Sprites.FindByName("moon_21");
			
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
			RealBody.ManageAll();
			
			// After Custom Activity
		}

		public virtual void Destroy()
		{
			// Generated Destroy
			SpriteManager.RemovePositionedObject(this);
			if (RealBody != null)
			{
				RealBody.RemoveFromManagers(ContentManagerName != "Global");
			}
			if (MoonSprite != null)
			{
				SpriteManager.RemoveSprite(MoonSprite);
			}
			


			CustomDestroy();
		}

		// Generated Methods
public virtual void PostInitialize ()
{
	Y = 60f;
	RotationZVelocity = 0.5f;
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
	mRealBody.AddToManagers(layerToAddTo);
	mRealBody.AttachAllDetachedTo(this, true);
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
	RealBody.ConvertToManuallyUpdated();
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
				FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("MoonStaticUnload", UnloadStaticContent);
				mHasRegisteredUnload = true;
			}
		}
		bool registerUnload = false;
		if (!FlatRedBallServices.IsLoaded<ShapeCollection>(@"content/entities/moon/moonshapecollectionfile.shcx", ContentManagerName))
		{
			registerUnload = true;
		}
		MoonShapeCollectionFile = FlatRedBallServices.Load<ShapeCollection>(@"content/entities/moon/moonshapecollectionfile.shcx", ContentManagerName);
		if (!FlatRedBallServices.IsLoaded<Scene>(@"content/realbody/moonfile.scnx", ContentManagerName))
		{
			registerUnload = true;
		}
		MoonFile = FlatRedBallServices.Load<Scene>(@"content/realbody/moonfile.scnx", ContentManagerName);
		if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
		{
			lock (mLockObject)
			{
				if (!mHasRegisteredUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
				{
					FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("MoonStaticUnload", UnloadStaticContent);
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
	if (MoonShapeCollectionFile != null)
	{
		MoonShapeCollectionFile.RemoveFromManagers(ContentManagerName != "Global");
		MoonShapeCollectionFile= null;
	}
	if (MoonFile != null)
	{
		MoonFile.RemoveFromManagers(ContentManagerName != "Global");
		MoonFile= null;
	}
}
public static object GetStaticMember (string memberName)
{
	switch(memberName)
	{
		case  "MoonShapeCollectionFile":
			return MoonShapeCollectionFile;
		case  "MoonFile":
			return MoonFile;
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
	public static class MoonExtensionMethods
	{
	}
	
}
