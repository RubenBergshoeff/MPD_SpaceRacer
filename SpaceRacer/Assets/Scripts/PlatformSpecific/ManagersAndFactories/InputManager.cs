using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public static class InputManager
{
	public static IInputHandler Instance {
		get {
			if (hiddenInstance == null) {
				hiddenInstance = CreateInstance ();
			}
			return hiddenInstance;
		}
	}

	private static IInputHandler hiddenInstance;

	private static IInputHandler CreateInstance ()
	{
		#if UNITY_EDITOR || UNITY_STANDALONE_OSX
		return new PC_InputHandler ();
		#elif UNITY_ANDROID
		return new M_InputHandler ();
		#else
		return new D_InputHandler ();
		#endif
	}
}
