using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_InputHandler: IInputHandler
{
	public float HorizontalAxis ()
	{
		return Input.GetAxis ("Horizontal");
	}

	public Vector2 AimDirection ()
	{
		throw new System.NotImplementedException ();
	}

	public bool FirePressed ()
	{
		throw new System.NotImplementedException ();
	}
}
