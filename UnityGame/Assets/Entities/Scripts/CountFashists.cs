using UnityEngine;
using System.Collections;

public class CountFashists : MonoBehaviour {

	public GameObject FashistFather;

	private UnityEngine.UI.Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		var fashs = FashistFather.GetComponentsInChildren<FashNavigation> ();
		text.text = fashs.Length.ToString();
	}
}
