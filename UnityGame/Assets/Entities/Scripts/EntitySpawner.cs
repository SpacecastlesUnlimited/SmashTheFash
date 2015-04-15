using UnityEngine;
using System.Collections;

public class EntitySpawner : MonoBehaviour {

	public GameObject Entity;
	public Transform Target;
	public Transform SpawnPoint;
	public float SpawnEvery;
	public float SpawnFirstAfter;
	public float ReduceSpawnTimeByAfterSpawn;
	public float MinSpawnTime;

	private float SpawnNext;
	private float SpawnInterval;

	public void Spawn() {
		var newEntity = (GameObject)Instantiate (Entity,SpawnPoint.position, SpawnPoint.rotation);
		newEntity.name = Entity.name;
		newEntity.transform.parent = transform;
		if (Target != null) {
			if (newEntity.GetComponent<FashNavigation> () != null)
				newEntity.GetComponent<FashNavigation> ().target = Target;
			else 
				newEntity.GetComponent<GoodPeopleNavigation> ().target = Target;
		}
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
