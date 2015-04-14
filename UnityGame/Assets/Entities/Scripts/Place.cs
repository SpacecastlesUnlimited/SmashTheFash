﻿using UnityEngine;
using System.Collections;

public class Place : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
			RaycastHit hitInfo;
			var layerMask = 1 << LayerMask.NameToLayer ("Ground");
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
			if (Physics.Raycast (ray, out hitInfo,float.PositiveInfinity,layerMask)) {
				Debug.Log (hitInfo.point);
				//target.position = hitInfo.point; //new Vector3(hitInfo.point.x, 0.0f, hitInfo.point.z );
			}
		}
	}
}
