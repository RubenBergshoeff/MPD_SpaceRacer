using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnEvent
{
	public float spawnTime;
	public Vector2 spawnPosition = new Vector2 (0, 12);
	public AstroidType astroidType;
}

[CreateAssetMenu (fileName = "AstroidWave", menuName = "Astroid Wave", order = 1)]
public class Wave : ScriptableObject
{
	public List<SpawnEvent> spawnEvents;
}