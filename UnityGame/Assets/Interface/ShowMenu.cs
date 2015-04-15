using UnityEngine;
using System.Collections;

public class ShowMenu : MonoBehaviour {

	public GameObject Menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Show() {
		Menu.SetActive (!Menu.activeSelf);
		if (!Menu.activeSelf)
			Time.timeScale = 1;
		else
			Time.timeScale = 0;
	}
}
