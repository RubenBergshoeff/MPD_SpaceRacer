using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour, IUpdatable
{

	private float speed = 5;

	public void MyUpdate ()
	{
		transform.position += Vector3.down * speed * Time.deltaTime;
		if (transform.position.y < GameManager.bottomlimit) {
			DestroyThis ();
		}
	}


	public void DestroyThis ()
	{
		AstroidManager.AstroidDestroyed (this);
		Destroy (gameObject); 
	}
}
