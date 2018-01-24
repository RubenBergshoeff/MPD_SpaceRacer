using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using System.IO;
using System.Collections.Generic;

public class BuildMenuItems : IActiveBuildTargetChanged
{
	static string resourceFolder = "/Resources/PlatformSpecific";
	static string pcTemp = "/_PCFiles";
	static string dpcTemp = Application.dataPath + pcTemp;
	static string mTemp = "/_MFiles";
	static string dmTemp = Application.dataPath + mTemp;

	[MenuItem ("Platform/OSX")]
	public static void PerformSwitchOSX ()
	{
		if (!Directory.Exists (dpcTemp)) {
			throw new System.ArgumentException ("No directory exists at " + dpcTemp);
		}


		DirectoryInfo dir;
		FileInfo[] files;
		if (!Directory.Exists (Application.dataPath + resourceFolder)) {
			if (!Directory.Exists (Application.dataPath + "/Recources")) {
				AssetDatabase.CreateFolder ("Assets", "Resources");
			}
			AssetDatabase.CreateFolder ("Assets/Resources", "PlatformSpecific");
		} else {
			dir = new DirectoryInfo (Application.dataPath + resourceFolder);
			files = dir.GetFiles ();
			foreach (FileInfo file in files) {
				if (file.Name.EndsWith (".meta")) {
					continue;
				}
				bool status = AssetDatabase.DeleteAsset ("Assets" + resourceFolder + "/" + file.Name);

				if (!status) {
					Debug.Log ("failed " + file.Name);
				}
			}
		}


		dir = new DirectoryInfo (dpcTemp);
		files = dir.GetFiles ();
		foreach (FileInfo file in files) {
			if (file.Name.EndsWith (".meta")) {
				continue;
			}
			bool status = AssetDatabase.CopyAsset (
				              "Assets" + pcTemp + "/" + file.Name,
				              "Assets" + resourceFolder + "/" + file.Name);

			if (!status) {
				Debug.Log ("failed " + file.Name);
			}
		}
		AssetDatabase.Refresh ();
		Debug.Log ("Folders updated");
//		// Switch to OSX standalone build.

		EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTargetGroup.Standalone, BuildTarget.StandaloneOSXUniversal);

	}

	[MenuItem ("Platform/Android")]
	public static void PerformSwitchAndroid ()
	{
		if (!Directory.Exists (dmTemp)) {
			throw new System.ArgumentException ("No directory exists at " + dmTemp);
		}


		DirectoryInfo dir;
		FileInfo[] files;
		if (!Directory.Exists (Application.dataPath + resourceFolder)) {
			if (!Directory.Exists (Application.dataPath + "/Recources")) {
				AssetDatabase.CreateFolder ("Assets", "Resources");
			}
			AssetDatabase.CreateFolder ("Assets/Resources", "PlatformSpecific");
		} else {
			dir = new DirectoryInfo (Application.dataPath + resourceFolder);
			files = dir.GetFiles ();
			foreach (FileInfo file in files) {
				if (file.Name.EndsWith (".meta")) {
					continue;
				}
				bool status = AssetDatabase.DeleteAsset ("Assets" + resourceFolder + "/" + file.Name);

				if (!status) {
					Debug.Log ("failed " + file.Name);
				}
			}
		}


		dir = new DirectoryInfo (dmTemp);
		files = dir.GetFiles ();
		foreach (FileInfo file in files) {
			if (file.Name.EndsWith (".meta")) {
				continue;
			}
			bool status = AssetDatabase.CopyAsset (
				              "Assets" + mTemp + "/" + file.Name,
				              "Assets" + resourceFolder + "/" + file.Name);

			if (!status) {
				Debug.Log ("failed " + file.Name);
			}
		}
		AssetDatabase.Refresh ();
		Debug.Log ("Folders updated");
		// Switch to Android standalone build.
		EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTargetGroup.Android, BuildTarget.Android);
	}

	public int callbackOrder { get { return 0; } }

	public void OnActiveBuildTargetChanged (BuildTarget previousTarget, BuildTarget newTarget)
	{
		Debug.Log ("Active platform is now " + newTarget);
	}
}