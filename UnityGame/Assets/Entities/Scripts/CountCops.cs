using UnityEngine;
using System.Collections;

public class CountCops : MonoBehaviour {
	
	public GameObject CopsFather;
	
	private UnityEngine.UI.Text text;
	
	// Use this for initialization
	void Start () {
		text = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = CopsFather.transform.childCount.ToString();
	}
}
