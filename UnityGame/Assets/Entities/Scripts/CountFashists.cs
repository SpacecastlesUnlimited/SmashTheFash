using UnityEngine;
using System.Collections;

public class CountFashists : MonoBehaviour {

	public GameObject FashistFather;

	public GameObject WonPanel;

	private UnityEngine.UI.Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		var fashs = FashistFather.GetComponentsInChildren<FashNavigation> ();
		text.text = fashs.Length.ToString();
		if (fashs.Length <= 0)
			Won ();
	}

	public void Won() {
		WonPanel.SetActive (true);
		Time.timeScale = 0.01f;
	}
}
