using UnityEngine;
using System.Collections;

public class Proxy : MonoBehaviour {
	
	public GameObject prefab;
	private GameObject instantiated;
	public GameController manager {
		get {
			return instantiated.GetComponent<GameController>();
		}
	}
	public LevelLoader loader {
		get {
			return GetComponent<LevelLoader>();
		}
	}

	private static Proxy current;
	public static Proxy Current {
		get {
			return current;
		}
	}

	// Use this for initialization
	void Start () {
		current = this;
		instantiated = GameObject.FindWithTag ("GameController");
		if (instantiated == null) {
			instantiated = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
			instantiated.name = prefab.name;
			DontDestroyOnLoad(instantiated);
			loader.LoadLevel("Main");
		}
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
