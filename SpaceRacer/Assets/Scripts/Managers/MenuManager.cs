using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		GameObject menuObj = Instantiate (Resources.Load ("PlatformSpecific/MenuCanvas") as GameObject);
		menuObj.GetComponent <SubMenuManager> ().Setup (this);
	}

	public void StartGame ()
	{
		SceneManager.LoadScene (1);
	}
}