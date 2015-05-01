using UnityEngine;
using System.Collections;

public class LooseGame : MonoBehaviour {

	public GameObject LostPanel;
	public Transform FashFather;
	public float currentDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		var Fashs = FashFather.GetComponentsInChildren<FashNavigation> ();
		float currentDistance = float.PositiveInfinity;
		foreach (var f in Fashs){
			if (currentDistance > (transform.position - f.transform.position).magnitude){
				currentDistance = (transform.position - f.transform.position).magnitude;
			}
		}
		if (currentDistance <= 4){
			Loose();
		}
	}

	
	public void Loose() {
		LostPanel.SetActive (true);
		Time.timeScale = 0.01f;
	}
}
