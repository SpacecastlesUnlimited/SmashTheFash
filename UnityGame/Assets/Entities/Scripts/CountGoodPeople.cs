using UnityEngine;
using System.Collections;

public class CountGoodPeople : MonoBehaviour {
	
	public GameObject GoodPeopleFather;
	
	private UnityEngine.UI.Text text;
	
	// Use this for initialization
	void Start () {
		text = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		var gps = GoodPeopleFather.GetComponentsInChildren<GoodPeopleNavigation> ();
		text.text = gps.Length.ToString();
	}
}
