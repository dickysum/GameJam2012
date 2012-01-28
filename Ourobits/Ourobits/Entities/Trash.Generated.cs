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
	public partial class Trash : PositionedObject, IDestroyable
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
private static Scene TrashFile1;

private Sprite mRealBody;
public Sprite RealBody
{
	get
	{
		return mRealBody;
	}
}
private Circle mCollisionCircle;
public Circle CollisionCircle
{
	get
	{
		return mCollisionCircle;
	}
}
public float RealBodyDrag
{
	get
	{
		return RealBody.Drag;
	}
	set
	{
		RealBody.Drag = value;
	}
}
public bool Attached = false;
public float CollisionCircleRadius
{
	get
	{
		return CollisionCircle.Radius;
	}
	set
	{
		CollisionCircle.Radius = value;
	}
}
public Color CollisionCircleColor
{
	get
	{
		return CollisionCircle.Color;
	}
	set
	{
		CollisionCircle.Color = value;
	}
}
public bool OnConveyor = false;
protected Layer LayerProvidedByContainer = null;

        public Trash(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public Trash(string contentManagerName, bool addToManagers) :
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
			mRealBody = TrashFile1.Sprites.FindByName("trash_1_ggj1").Clone();
			mCollisionCircle = new Circle();
			
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
			if (RealBody != null)
			{
				SpriteManager.RemoveSprite(RealBody);
			}
			if (CollisionCircle != null)
			{
				ShapeManager.Remove(CollisionCircle);
			}
			


			CustomDestroy();
		}

		// Generated Methods
public virtual void PostInitialize ()
{
	RealBodyDrag = 0.3f;
	Attached = false;
	CollisionCircleRadius = 10f;
	CollisionCircleColor = Color.Transparent;
	OnConveyor = false;
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
	SpriteManager.AddToLayer(mRealBody, layerToAddTo);
	if (mRealBody.Parent == null)
	{
		mRealBody.AttachTo(this, true);
	}
	ShapeManager.AddToLayer(mCollisionCircle, layerToAddTo);
	if (mCollisionCircle.Parent == null)
	{
		mCollisionCircle.AttachTo(this, true);
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
	SpriteManager.ConvertToManuallyUpdated(RealBody);
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
				FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("TrashStaticUnload", UnloadStaticContent);
				mHasRegisteredUnload = true;
			}
		}
		bool registerUnload = false;
		if (!FlatRedBallServices.IsLoaded<Scene>(@"content/realbody/trashfile1.scnx", ContentManagerName))
		{
			registerUnload = true;
		}
		TrashFile1 = FlatRedBallServices.Load<Scene>(@"content/realbody/trashfile1.scnx", ContentManagerName);
		if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
		{
			lock (mLockObject)
			{
				if (!mHasRegisteredUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
				{
					FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("TrashStaticUnload", UnloadStaticContent);
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
	if (TrashFile1 != null)
	{
		TrashFile1.RemoveFromManagers(ContentManagerName != "Global");
		TrashFile1= null;
	}
}
public static object GetStaticMember (string memberName)
{
	switch(memberName)
	{
		case  "TrashFile1":
			return TrashFile1;
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
	public static class TrashExtensionMethods
	{
	}
	
}
