using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public bool OnlyFashs = false;
	public float maxLifeTime = 3;

	float startTime;


	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ((startTime + maxLifeTime) < Time.time) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision other) {
		if (OnlyFashs){
			if (other.gameObject.GetComponent<FashNavigation>() != null) {
				Destroy (other.gameObject);
				Destroy (gameObject);
			}
		} else  {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
