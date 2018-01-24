using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputHandler
{
	float HorizontalAxis ();

	Vector2 AimDirection ();

	bool FirePressed ();
}
