using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {

	public string WebPlayerQuitUrl;

	private Stack<string> levels;

	// Use this for initialization
	void Start () {
		levels = new Stack<string> ();
	}

	void Update() {
		if (Input.GetButtonUp ("Cancel"))
			GoBackLevel ();
	}

	public void LoadLevel(string LevelName) {
		levels.Push (LevelName);
		Application.LoadLevel (LevelName);
	}
	
	public void GoBackLevel() {
		if (levels.Count <= 1) {
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit ();
#endif
		}
		else
			Application.LoadLevel (levels.Pop());
	}
}
