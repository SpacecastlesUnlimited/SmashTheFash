using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	
	private Stack<string> levels;
	public Stack<string> Levels {
		get {
			if (levels == null)
				levels = new Stack<string> ();
			return levels;
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
