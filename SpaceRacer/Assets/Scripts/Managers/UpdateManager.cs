using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{

	private static UpdateManager Instance {
		get {
			if (hiddenInstance == null) {
				hiddenInstance = new GameObject ("UpdateManager").AddComponent <UpdateManager> ();
				hiddenInstance.updateList = new List<IUpdatable> ();
				hiddenInstance.removedUpdates = new List<IUpdatable> ();
			}
			return hiddenInstance;
		}
	}

	private static UpdateManager hiddenInstance;

	private List<IUpdatable> updateList;
	private List<IUpdatable> removedUpdates;

	private void Update ()
	{
		for (int i = 0; i < updateList.Count; i++) {
			if (removedUpdates.Contains (updateList [i])) {
				RemoveUpdateable (updateList [i]);
				i--;
			}
		}
		foreach (var obj in updateList) {
			obj.MyUpdate ();
		}
	}

	public static void Subscribe (IUpdatable updatableObj)
	{
		if (!Instance.updateList.Contains (updatableObj)) {
			Instance.updateList.Add (updatableObj);
		}
	}

	public static void UnSubscribe (IUpdatable updatableObj)
	{
		if (Instance.updateList.Contains (updatableObj)) {
			Instance.removedUpdates.Add (updatableObj);
		}
	}

	private void RemoveUpdateable (IUpdatable updatable)
	{
		updateList.Remove (updatable);
		removedUpdates.Remove (updatable);
		if (updateList.Count == 0) {
			Destroy (gameObject); 
		}
	}
}
