using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {

	private Stack<string> levels {
		get {
			return Proxy.Current.manager.Levels;
		}
	}

	// Use this for initialization
	void Awake () {
	}

	void Update() {
		if (Input.GetButtonUp ("Cancel"))
			GoBackLevel ();
	}

	public void LoadLevel(string LevelName) {
		levels.Push (LevelName);
		Application.LoadLevel (LevelName);
		Time.timeScale = 1;
	}
	
	public void GoBackLevel() {
		var level = levels.Pop(); // current Level
		if (levels.Count < 1 || level == "Main") {
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit ();
			#endif
		} else {
			level = levels.Peek(); // previous Level
			Application.LoadLevel (level);
		}
	}
}
