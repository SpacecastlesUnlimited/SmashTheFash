using UnityEngine;
using System.Collections;

public class TurnLeftRight : MonoBehaviour {

	public Sprite left;
	public Sprite right;
	public SpriteRenderer image;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.forward.x < 0)
			image.sprite = left;
		else
			image.sprite = right;
	}
}
