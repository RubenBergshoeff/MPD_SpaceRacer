using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour, IUpdatable
{
	public delegate void PlayerViewEvent ();

	public PlayerViewEvent OnCollided;

	public float ShipRotation {
		get {
			return transform.rotation.eulerAngles.y;
		}
		set {
			if (value < 140) {
				value = 140;
			}
			if (value > 220) {
				value = 220;
			}
			transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.eulerAngles.x, value, transform.rotation.eulerAngles.z));
		}
	}

	public Vector2 ShipPosition {
		get {
			return transform.position;
		}
		set {
			transform.position = value;
		}
	}

	public void MyUpdate ()
	{
		
	}

	void OnCollisionEnter (Collision collision)
	{
//		Debug.Log (collision.collider.name);
		if (OnCollided != null) {
			OnCollided ();
		}
	}

}
