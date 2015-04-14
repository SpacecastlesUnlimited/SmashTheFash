using UnityEngine;
using System.Collections;

public class FashSpawner : MonoBehaviour {

	public GameObject Fash;
	public Transform Target;
	public Transform SpawnPoint;
	public float SpawnEvery;
	public float SpawnFirstAfter;
	public float ReduceSpawnTimeByAfterSpawn;
	public float MinSpawnTime;

	private float SpawnNext;
	private float SpawnInterval;

	public void Spawn() {
		var newFash = (GameObject)Instantiate (Fash,SpawnPoint.position, SpawnPoint.rotation);
		newFash.name = Fash.name;
		newFash.transform.parent = transform;
		newFash.GetComponent<FashNavigation> ().target = Target;
	}

	// Use this for initialization
	void Start () {
		SpawnNext = Time.time + SpawnFirstAfter;
		SpawnInterval = SpawnEvery;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= SpawnNext) {
			Spawn();
			if ((SpawnInterval - ReduceSpawnTimeByAfterSpawn) > MinSpawnTime)
				SpawnInterval -= ReduceSpawnTimeByAfterSpawn;
			SpawnNext = Time.time + SpawnInterval;
		}
	}
}
