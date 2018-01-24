using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_InputHandler : IInputHandler
{
	private Gyroscope gyro {
		get {
			if (!Input.gyro.enabled) {
				Input.gyro.enabled = true;
			}
			return Input.gyro;
		}
	}

	public float HorizontalAxis ()
	{
		return Input.acceleration.x;
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
