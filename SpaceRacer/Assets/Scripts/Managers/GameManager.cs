using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IUpdatable
{
	public static float bottomlimit = -12;
	public Vector3 playerSpawnPosition;
	public List<Wave> waves;

	private Quaternion upRotation = Quaternion.Euler (new Vector3 (90, 180, 0));
	private PlayerControl player;
	private float currentWaveStart;
	private int currentWave;
	private int currentWavePos;

	private float timeSinceLastWave = 0;

	// Use this for initialization
	void Awake ()
	{
//		DontDestroyOnLoad (gameObject);
		UpdateManager.Subscribe (this);
		SetupLevel ();
	}

	void Start ()
	{
		currentWaveStart = Time.time;
		currentWave = 0;
		currentWavePos = 0;
	}
	
	// Update is called once per frame
	public void MyUpdate ()
	{
		if (!player.IsAlive ()) {
			SceneManager.LoadScene (0);
		}
		if (currentWave >= waves.Count) {
			timeSinceLastWave += Time.deltaTime;
			if (timeSinceLastWave > 10) {
				SceneManager.LoadScene (0);
			}
			return;
		}
		if (currentWavePos >= waves [currentWave].spawnEvents.Count) {
			currentWaveStart = Time.time;
			currentWave++;
			currentWavePos = 0;
			return;
		}
		if (Time.time - currentWaveStart > waves [currentWave].spawnEvents [currentWavePos].spawnTime) {
			AstroidManager.CreateAstroidAt (waves [currentWave].spawnEvents [currentWavePos].spawnPosition, waves [currentWave].spawnEvents [currentWavePos].astroidType);
			currentWavePos++;
		}
	}

	private void SetupLevel ()
	{
		GameObject playerObject = Instantiate (Resources.Load ("PlatformSpecific/playerRocket") as GameObject, playerSpawnPosition, upRotation);
		PlayerView playerView = playerObject.AddComponent <PlayerView> ();
		PlayerModel playerModel = new PlayerModel ();
		player = new PlayerControl (playerView, playerModel, InputManager.Instance);
	}
}
