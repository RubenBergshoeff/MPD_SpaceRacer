using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuManager : MonoBehaviour
{

	private MenuManager mManager;

	public void Setup (MenuManager manager)
	{
		mManager = manager;
	}

	public void StartGame ()
	{
		mManager.StartGame ();
	}
}
