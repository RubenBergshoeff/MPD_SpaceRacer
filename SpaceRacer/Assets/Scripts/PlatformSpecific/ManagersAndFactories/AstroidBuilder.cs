using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AstroidType
{
	SMALL,
	LARGE
}

public class AstroidBuilder
{
	public static GameObject ProvideAstroidOfType (AstroidType astroidType)
	{
		GameObject astroidObject;
		#if UNITY_EDITOR || UNITY_STANDALONE_OSX
		switch (astroidType) {
		case AstroidType.SMALL:
			astroidObject = GameObject.Instantiate (Resources.Load ("PlatformSpecific/projectile") as GameObject);
			astroidObject.AddComponent <Astroid> ();
			return astroidObject;
		case AstroidType.LARGE:
			astroidObject = GameObject.Instantiate (Resources.Load ("PlatformSpecific/projectileLarge") as GameObject);
			astroidObject.AddComponent <Astroid> ();
			return astroidObject;
		default:
			astroidObject = GameObject.Instantiate (Resources.Load ("PlatformSpecific/projectile") as GameObject);
			astroidObject.AddComponent <Astroid> ();
			return astroidObject;
		}
		#elif UNITY_ANDROID
		switch (astroidType) {
		case AstroidType.SMALL:
			astroidObject = GameObject.Instantiate (Resources.Load ("PlatformSpecific/projectile") as GameObject);
			astroidObject.AddComponent <Astroid> ();
			return astroidObject;
		case AstroidType.LARGE:
			astroidObject = GameObject.Instantiate (Resources.Load ("PlatformSpecific/projectile") as GameObject);
			astroidObject.transform.localScale *= 1.5f;
			astroidObject.AddComponent <Astroid> ();
			return astroidObject;
		default:
			astroidObject = GameObject.Instantiate (Resources.Load ("PlatformSpecific/projectile") as GameObject);
			astroidObject.AddComponent <Astroid> ();
			return astroidObject;
		}
		#else
		switch (astroidType) {
		case AstroidType.SMALL:
		break;
		case AstroidType.LARGE:
		break;
		default:
		break;
		}
		#endif
	}
}
