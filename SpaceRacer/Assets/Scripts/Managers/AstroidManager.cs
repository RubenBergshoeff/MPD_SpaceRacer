using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidManager : MonoBehaviour, IUpdatable
{

	private static AstroidManager Instance {
		get {
			if (hiddenInstance == null) {
				hiddenInstance = new GameObject ("AstroidManager").AddComponent <AstroidManager> ();
				hiddenInstance.astroids = new List<Astroid> ();
				hiddenInstance.diedAstroids = new List<Astroid> ();
			}
			return hiddenInstance;
		}
	}

	private static AstroidManager hiddenInstance;

	private List<Astroid> astroids;
	private List<Astroid> diedAstroids;

	private void Start ()
	{
		UpdateManager.Subscribe (this);
	}

	public void MyUpdate ()
	{
		for (int i = 0; i < astroids.Count; i++) {
			if (diedAstroids.Contains (astroids [i])) {
				RemoveAstroid (astroids [i]);
				i--;
			}
		}
		foreach (var astroid in astroids) {
			astroid.MyUpdate ();
		}
	}

	public static void CreateAstroidAt (Vector3 position, AstroidType type)
	{
		GameObject astroidObject = AstroidBuilder.ProvideAstroidOfType (type);
		astroidObject.transform.position = position;
		Astroid astroid = astroidObject.GetComponent <Astroid> ();
		Instance.astroids.Add (astroid);
	}

	public static void AstroidDestroyed (Astroid astroid)
	{
		if (Instance.astroids.Contains (astroid)) {
			Instance.diedAstroids.Add (astroid);
		}
	}

	private void RemoveAstroid (Astroid astroid)
	{
		astroids.Remove (astroid);
		diedAstroids.Remove (astroid);
		if (astroids.Count == 0) {
			UpdateManager.UnSubscribe (this);
			Destroy (gameObject); 
		}
	}
}
