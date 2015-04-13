using UnityEngine;
using System.Collections;

public class DontRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(90,0,0);
	}
}
